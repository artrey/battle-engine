using System.Collections.Generic;
using System.Linq;
using BattleEngine.BattleEntities;

namespace BattleEngine
{
  public class InitiativeScale
  {
    private class UnitsStackComparer : IComparer<UnitsStack>
    {
      public int Compare(UnitsStack x, UnitsStack y)
      {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;
        
        var result = x.Initiative.CompareTo(y.Initiative);
        if (result == 0) result = y.Count.CompareTo(x.Count);
        if (result == 0) result = x.HitPoints.CompareTo(y.HitPoints);
        if (result == 0) result = x.LastUnitHitPoints.CompareTo(y.LastUnitHitPoints);
        return result;
      }
    }
    
    private readonly IEnumerable<UnitsStack> _stacks;
    public IEnumerable<UnitsStack> Stacks => _stacks.ToArray();
    public UnitsStack Current => _stacks.FirstOrDefault();
    public bool IsFinished => Current == null;

    public InitiativeScale(IEnumerable<UnitsStack> stacks = null, uint roundOffset = 0)
    {
      _stacks = stacks == null ? new List<UnitsStack>() : Build(stacks, roundOffset);
    }

    private static List<UnitsStack> Build(IEnumerable<UnitsStack> stacks, uint roundOffset)
    {
      if (roundOffset == 0)
      {
        return stacks.Where(s => s.Modifiers.All(m => m.CanAct()))
          .OrderByDescending(s => s, new UnitsStackComparer()).ToList();
      }

      return stacks.ToDictionary(s => s, s => s.ForecastClone(roundOffset))
        .OrderByDescending(s => s.Value, new UnitsStackComparer())
        .Select(p => p.Key).ToList();
    }

    public override string ToString() => string.Join(" -> ", _stacks);
  }
}
