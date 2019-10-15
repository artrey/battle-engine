using Localizator;

namespace BattleEngine
{
  public abstract class Unit : ParametersEntity
  {
    public string Name { get; }
    public string VisualName { get; }
    public uint Points { get; }

    public Unit(string name, uint hitPoints, uint attack, uint defence,
      uint minDamage, uint maxDamage, double initiative, uint points)
    {
      Name = name;
      VisualName = name.T();
      HitPoints = hitPoints;
      Attack = attack;
      Defence = defence;
      MinDamage = minDamage;
      MaxDamage = maxDamage;
      Initiative = initiative;
      Points = points;
    }

    public override string ToString()
    {
      return
        $"<{VisualName} [HP: {HitPoints} / A: {Attack} / D: {Defence} / Dmg: {MinDamage}-{MaxDamage} / I: {Initiative}]>";
    }
  }
}