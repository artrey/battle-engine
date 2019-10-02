using System;

namespace BattleEngine
{
  public class BattleUnitsStack : UnitsStack
  {
    protected uint StartCount { get; }
    public uint TotalHitPoints { get; private set; }

    public BattleUnitsStack(Unit unit, uint count) : base(unit, count)
    {
      if (count == 0)
      {
        throw new ArgumentException(nameof(count));
      }

      StartCount = count;
      TotalHitPoints = count * HitPoints;
    }

    public void Hit(BattleUnitsStack enemy)
    {
      var mult = 1 + 0.05 * Math.Abs(Attack - enemy.Defence);
      if (Attack < enemy.Defence)
      {
        mult = 1 / mult;
      }

      var damage = (uint)(Count * mult * new Random().Next((int)MinDamage, (int)MaxDamage + 1));
      
      enemy.Damage(damage);
    }

    public void Damage(uint damage)
    {
      if (TotalHitPoints < damage)
      {
        TotalHitPoints = 0;
      }
      else
      {
        TotalHitPoints -= damage;
      }
      Count = (uint)Math.Floor(1.0 * TotalHitPoints / HitPoints);
    }
  }
}