using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BattleEngine
{
  public class InitiativeScale : IEnumerable<BattleUnitsStack>
  {
    public IEnumerable<BattleUnitsStack> NextTurn { get; }
    public IEnumerable<BattleUnitsStack> CurrentTurn { get; }
    public BattleUnitsStack Current { get; }
    public bool IsFinished => Current == null && !CurrentTurn.Any();

    public InitiativeScale(IEnumerable<BattleUnitsStack> allStacks, IEnumerable<BattleUnitsStack> nextTurnStacks)
    {
      if (allStacks == null)
      {
        throw new ArgumentException(nameof(allStacks));
      }

      var turnStacks = nextTurnStacks != null ? nextTurnStacks.ToList() : new List<BattleUnitsStack>();
      var currentStacks = allStacks.Except(turnStacks).OrderByDescending(s => s.Initiative).ToList();
      if (currentStacks.Count != 0)
      {
        Current = currentStacks.First();
        currentStacks.RemoveAt(0);
      }
      CurrentTurn = currentStacks;
      NextTurn = turnStacks.OrderByDescending(s => s.Initiative).ToList();
    }
    
    public IEnumerator<BattleUnitsStack> GetEnumerator()
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
