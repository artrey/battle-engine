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

    public IEnumerable<UnitsStack> Stacks => Left.Stacks.Concat(Right.Stacks).ToList().AsReadOnly();
    
    public uint Round { get; private set; }
    public InitiativeScale CurrentRound { get; private set; }
    public InitiativeScale NextRound => new InitiativeScale(Stacks);

    public bool IsFinished => !Left.HasUnits || !Right.HasUnits || Surrendered != null;
    
    public UnitsStack CurrentUnitsStack => CurrentRound.Current;

    public IEnumerable<BattleAction> AvailableActions(UnitsStack stack) 
      => stack.AvailableActions(this);

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
      CurrentRound = new InitiativeScale(Stacks);
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

    public void EndTurn(BattleAction action)
    {
      action.OnEndTurn(this);
      
      CurrentRound.Refresh();

      if (!CurrentRound.IsFinished) return;
      foreach (var stack in NextRound.Stacks)
      {
        stack.Refresh(true);
      }
      CurrentRound = NextRound;
      ++Round;
    }
  }
}