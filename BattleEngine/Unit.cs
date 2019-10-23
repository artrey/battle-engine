using System.Collections.Generic;

namespace BattleEngine
{
  public abstract class Unit : EqualityClass, IParametersEntity
  {
    public uint HitPoints { get; }
    public uint Attack { get; }
    public uint Defence { get; }
    public uint MinDamage { get; }
    public uint MaxDamage { get; }
    public double Initiative { get; }
    public uint Price { get; }

    public IEnumerable<Perk> Perks { get; protected set; } = new Perk[0];
    public IEnumerable<Cast> Casts { get; protected set; } = new Cast[0];
    
    public Unit(uint hitPoints, uint attack, uint defence,
      uint minDamage, uint maxDamage, double initiative, uint price)
    {
      HitPoints = hitPoints;
      Attack = attack;
      Defence = defence;
      MinDamage = minDamage;
      MaxDamage = maxDamage;
      Initiative = initiative;
      Price = price;
    }

    public override string ToString()
    {
      return
        $"<{this.VisualName()} [HP: {HitPoints} / A: {Attack} / D: {Defence} / Dmg: {MinDamage}-{MaxDamage} / I: {Initiative}]>";
    }
  }
}