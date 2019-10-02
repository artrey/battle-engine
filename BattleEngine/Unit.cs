namespace BattleEngine
{
  public abstract class Unit : IEntity
  {
    public UnitType Type { get; }
    public uint HitPoints { get; }
    public uint Attack { get; }
    public uint Defence { get; }
    public uint MinDamage { get; }
    public uint MaxDamage { get; }
    public double Initiative { get; }
    public uint Points { get; }

    public Unit(UnitType unitType, uint hitPoints, uint attack, uint defence, 
      uint minDamage, uint maxDamage, double initiative, uint points)
    {
      Type = unitType;
      HitPoints = hitPoints;
      Attack = attack;
      Defence = defence;
      MinDamage = minDamage;
      MaxDamage = maxDamage;
      Initiative = initiative;
      Points = points;
    }
  }
}