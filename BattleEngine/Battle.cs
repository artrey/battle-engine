//using System;
//using System.IO;
//using System.Linq;
//using BattleEngine.BattleEntities;
//
//namespace BattleEngine
//{
//  public class Battle
//  {
//    public Army Left { get; }
//    public Army Right { get; }
//    
//    public InitiativeScale Scale { get; private set; }
//
//    public bool IsFinished => Left.Count == 0 || Right.Count == 0;
//    
//    public Army Winner
//    {
//      get
//      { 
//        if (!IsFinished)
//        {
//          throw new InvalidDataException("Not finished yet");
//        }
//        return Left.Count == 0 ? Right : Left;
//      }
//    }
//
//
//    public Battle(Army left, Army right)
//    {
//      Left = left ?? throw new ArgumentException(nameof(left));
//      Right = right ?? throw new ArgumentException(nameof(right));
//      Scale = new InitiativeScale(Left.Stacks.Concat(Right.Stacks), null);
//    }
//
//    public UnitsStack NextUnitsStack()
//    {
//      return Scale.Current;
//    }
//
//    protected Army GetArmy(UnitsStack stack)
//    {
//      if (Left.Stacks.Any(unitsStack => unitsStack == stack)) return Left;
//      if (Right.Stacks.Any(unitsStack => unitsStack == stack)) return Right;
//      throw new ArgumentException(nameof(stack));
//    }
//
//    public bool PreviewAct(UnitsStack active, Action action, UnitsStack target)
//    {
//      switch (action)
//      {
//        case Action.Attack:
//          return GetArmy(active) != GetArmy(target);
//        
//        case Action.Ability:
//          // TODO
//          return false;
//        
//        default:
//          return false;
//      }
//    }
//
//    public void Act(UnitsStack active, Action action, UnitsStack target)
//    {
//      if (!PreviewAct(active, action, target))
//      {
//        throw new InvalidOperationException("Not allowed action");
//      }
//      
//      switch (action)
//      {
//        case Action.Attack:
////          active.Hit(target);
//          if (target.TotalHitPoints == 0)
//          {
//            GetArmy(target).RemoveStack(target);
//          }
//          break;
//        
//        case Action.Ability:
//          // TODO
//          break;
//        
//        default:
//          throw new InvalidDataException(nameof(action));
//      }
//
//      Scale = new InitiativeScale(Left.Stacks.Concat(Right.Stacks), Scale.NextTurn.Append(Scale.Current));
//      if (Scale.IsFinished)
//      {
//        Scale = new InitiativeScale(Left.Stacks.Concat(Right.Stacks), null);
//      }
//    }
//  }
//}