using System;

namespace BattleEngine.BattleEntities
{
  public class UnitsStack : ParametersEntity, ICapacity
  {
    public uint Capacity => Constants.STACK_MAX_CAPACITY;
    public Unit Unit { get; }
    public uint Count => (uint)Math.Floor(1.0 * TotalHitPoints / HitPoints);
    protected uint StartCount { get; }
    public uint TotalHitPoints { get; private set; }

    public UnitsStack(MapEntities.UnitsStack stack) : base(stack.Unit)
    {
      Unit = stack.Unit;
      StartCount = stack.Count;
      TotalHitPoints = stack.Count * HitPoints;
    }

    public MapEntities.UnitsStack ToMapUnitsStack()
    {
      return new MapEntities.UnitsStack(Unit, Count);
    }

    public void Hit(UnitsStack enemy)
    {
      var mult = 1 + 0.05 * Math.Abs((int)Attack - enemy.Defence);
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
    }

    public override string ToString()
    {
      return $@"<{Unit.VisualName} [{Count}] ({HitPoints + TotalHitPoints - Count * HitPoints})>";
    }
  }
}