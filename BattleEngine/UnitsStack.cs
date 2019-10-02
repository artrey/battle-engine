using System;

namespace BattleEngine
{
  public class UnitsStack : IEntity
  {
    protected static uint CAPACITY = 999999999;

    public Unit Unit { get; }
    public uint Count { get; protected set; }
    public bool IsAlive => Count > 0;

    public uint HitPoints { get; private set; }
    public uint Attack { get; private set; }
    public uint Defence { get; private set; }
    public uint MinDamage { get; private set; }
    public uint MaxDamage { get; private set; }
    public double Initiative { get; private set; }

    public UnitsStack(Unit unit, uint count = 0)
    {
      Unit = unit ?? throw new ArgumentException(nameof(unit));
      Count = count;
      HitPoints = unit.HitPoints;
      Attack = unit.Attack;
      Defence = unit.Defence;
      MinDamage = unit.MinDamage;
      MaxDamage = unit.MaxDamage;
      Initiative = unit.Initiative;
    }

    public void SetCount(uint count)
    {
      if (count > CAPACITY)
      {
        throw new ArgumentException(nameof(count));
      }
      Count = count;
    }

    public void Add(uint count)
    {
      SetCount(Count + count);
    }

    public void Decrease(uint count)
    {
      SetCount(Count - count);
    }

    public override string ToString()
    {
      return $@"<{Unit.Type.Description()} [{Count}]>";
    }
  }
}