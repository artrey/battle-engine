using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BattleEngine.BattleEntities;

namespace BattleEngine
{
  public class InitiativeScale : IEnumerable<UnitsStack>
  {
    public IEnumerable<UnitsStack> NextTurn { get; }
    public IEnumerable<UnitsStack> CurrentTurn { get; }
    public UnitsStack Current { get; }
    public bool IsFinished => Current == null && !CurrentTurn.Any();

    public InitiativeScale(IEnumerable<UnitsStack> allStacks, IEnumerable<UnitsStack> nextTurnStacks)
    {
      if (allStacks == null)
      {
        throw new ArgumentException(nameof(allStacks));
      }

//      var turnStacks = nextTurnStacks != null ? nextTurnStacks.ToList() : new List<UnitsStack>();
//      var currentStacks = allStacks.Except(turnStacks).OrderByDescending(s => s.Initiative).ToList();
//      if (currentStacks.Count != 0)
//      {
//        Current = currentStacks.First();
//        currentStacks.RemoveAt(0);
//      }
//      CurrentTurn = currentStacks;
//      NextTurn = turnStacks.OrderByDescending(s => s.Initiative).ToList();
    }
    
    public IEnumerator<UnitsStack> GetEnumerator()
    {
      yield return Current;
      foreach (var stack in CurrentTurn.Concat(NextTurn))
      {
        yield return stack;
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}
