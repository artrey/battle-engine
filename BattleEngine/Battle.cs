using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BattleEngine.BattleEntities;

namespace BattleEngine
{
  public class Battle
  {
    public Army Left { get; }
    public Army Right { get; }
    public Army Surrendered { get; private set; }
    public bool IsFinished => !Left.HasUnits || !Right.HasUnits || Surrendered != null;

    public uint Round { get; private set; }

    private readonly InitiativeScaleBuilder _initiativeScaleBuilder;
    public InitiativeScale CurrentRound { get; private set; }
    public InitiativeScale NextRound { get; private set; }

    public UnitsStack CurrentUnitsStack => CurrentRound.Current;

    public IEnumerable<BattleAction> AvailableActions(UnitsStack stack) 
      => stack.AvailableActions(this);
    
    public IEnumerable<BattleAction> CurrentAvailableActions 
      => AvailableActions(CurrentUnitsStack);
    
    public IEnumerable<UnitsStack> Stacks => Left.Stacks.Concat(Right.Stacks);

    public Army Winner
    {
      get
      { 
        if (!IsFinished)
        {
          throw new InvalidDataException("Not finished yet");
        }

        if (Surrendered != null)
        {
          return Surrendered == Left ? Right : Left;
        }
        return Left.HasUnits ? Left : Right.HasUnits ? Right : null;
      }
    }
    
    public Battle(Army left, Army right)
    {
      Left = left ?? throw new ArgumentException(nameof(left));
      Right = right ?? throw new ArgumentException(nameof(right));
      Round = 1;
      _initiativeScaleBuilder = new InitiativeScaleBuilder(this);
      UpdateInitiativeScales();
    }

    private void UpdateInitiativeScales()
    {
      CurrentRound = _initiativeScaleBuilder.Build(0);
      NextRound = _initiativeScaleBuilder.Build(1);
    }

    public Army GetArmy(UnitsStack stack)
    {
      if (Left.Stacks.Any(unitsStack => unitsStack == stack)) return Left;
      if (Right.Stacks.Any(unitsStack => unitsStack == stack)) return Right;
      throw new ArgumentException(nameof(stack));
    }
    public Army GetOppositeArmy(UnitsStack stack) => GetArmy(stack) == Left ? Right : Left;

    public Army CurrentArmy => GetArmy(CurrentUnitsStack);
    public Army CurrentOppositeArmy => GetOppositeArmy(CurrentUnitsStack);

    public void GiveUp(UnitsStack stack) => Surrendered = GetArmy(stack);
    public void GiveUp() => GiveUp(CurrentUnitsStack);

    public bool ActValid(BattleAction action, UnitsStack stack, params UnitsStack[] stacks)
    {
      return action.Validate(this, stack, stacks);
    }

    public void Act(BattleAction action, UnitsStack stack, params UnitsStack[] stacks)
    {
      action.Act(this, stack, stacks);
      stack.Refresh();
      foreach (var s in stacks)
      {
        s.Refresh();
      }
      UpdateInitiativeScales();
      
      if (!CurrentRound.IsFinished) return;
      
      ++Round;
      foreach (var s in Stacks)
      {
        s.UpdateModifiers();
        s.Refresh();
      }
      UpdateInitiativeScales();
    }
  }
}