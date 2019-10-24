using System.Collections.Generic;
using System.Linq;
using BattleEngine.BattleEntities;
using BattleEngine.Modifiers;

namespace BattleEngine
{
  public class InitiativeScale
  {
    private class UnitsStackComparer : IComparer<UnitsStack>
    {
      private uint _roundOffset;

      public UnitsStackComparer(uint roundOffset)
      {
        _roundOffset = roundOffset;
      }
      
      int IComparer<UnitsStack>.Compare(UnitsStack x, UnitsStack y)
      {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;
        
        // TODO: here check contains with roundOffset 
        var xIni = x.Initiative * (x.Modifiers(_roundOffset).Contains(new AlreadyWait()) ? -1 : 1);
        var yIni = y.Initiative * (y.Modifiers(_roundOffset).Contains(new AlreadyWait()) ? -1 : 1);
        var result = xIni.CompareTo(yIni);
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
      return new List<UnitsStack>(stacks.Where(s => s.Modifiers(roundOffset).All(m => m.CanAct()))
        .OrderByDescending(s => s, new UnitsStackComparer(roundOffset)));
    }

    public override string ToString() => string.Join(" -> ", _stacks);
  }
}
