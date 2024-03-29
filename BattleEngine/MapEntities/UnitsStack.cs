using System;

namespace BattleEngine.MapEntities
{
  public class UnitsStack : ICapacity
  {
    public Unit Unit { get; }
    
    public uint Capacity => Constants.STACK_MAX_CAPACITY;
    public uint Count { get; }
    
    public UnitsStack(Unit unit, uint count)
    {
      Unit = unit ?? throw new ArgumentNullException(nameof(unit));
      if (count == 0 || count > Capacity) throw new ArgumentException(nameof(count));
      Count = count;
    }

    public override string ToString() => $@"<{Unit.VisualName()} [{Count}]>";
  }
}