using System;
using System.IO;
using System.Linq;

namespace BattleEngine
{
  public class Battle
  {
    public BattleArmy Left { get; }
    public BattleArmy Right { get; }
    
    public InitiativeScale Scale { get; private set; }

    public bool IsFinished => Left.Count == 0 || Right.Count == 0;
    
    public BattleArmy Winner
    {
      get
      { 
        if (!IsFinished)
        {
          throw new InvalidDataException("Not finished yet");
        }
        return Left.Count == 0 ? Right : Left;
      }
    }


    public Battle(BattleArmy left, BattleArmy right)
    {
      Left = left ?? throw new ArgumentException(nameof(left));
      Right = right ?? throw new ArgumentException(nameof(right));
      Scale = new InitiativeScale(Left.Stacks.Concat(Right.Stacks), null);
    }

    public BattleUnitsStack NextUnitsStack()
    {
      return Scale.Current;
    }

    protected BattleArmy GetArmy(BattleUnitsStack stack)
    {
      if (Left.Stacks.Any(unitsStack => unitsStack == stack)) return Left;
      if (Right.Stacks.Any(unitsStack => unitsStack == stack)) return Right;
      throw new ArgumentException(nameof(stack));
    }

    public bool PreviewAct(BattleUnitsStack active, Action action, BattleUnitsStack target)
    {
      switch (action)
      {
        case Action.Attack:
          return GetArmy(active) != GetArmy(target);
        
        case Action.Ability:
          // TODO
          return false;
        
        default:
          return false;
      }
    }

    public void Act(BattleUnitsStack active, Action action, BattleUnitsStack target)
    {
      if (!PreviewAct(active, action, target))
      {
        throw new InvalidOperationException("Not allowed action");
      }
      
      switch (action)
      {
        case Action.Attack:
          active.Hit(target);
          if (target.TotalHitPoints == 0)
          {
            GetArmy(target).RemoveStack(target);
          }
          break;
        
        case Action.Ability:
          // TODO
          break;
        
        default:
          throw new InvalidDataException(nameof(action));
      }

      Scale = new InitiativeScale(Left.Stacks.Concat(Right.Stacks), Scale.NextTurn.Append(Scale.Current));
      if (Scale.IsFinished)
      {
        Scale = new InitiativeScale(Left.Stacks.Concat(Right.Stacks), null);
      }
    }
  }
}