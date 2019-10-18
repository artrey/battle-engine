using System.Linq;

namespace BattleEngine.BattleEntities
{
  public class Army : ArmyHolder<UnitsStack>
  {
    public override uint Capacity => Constants.BATTLE_ARMY_MAX_CAPACITY;

    public bool HasUnits => Stacks.Any(s => s.Count != 0);

    public Army(MapEntities.Army army) : base(army.Stacks.Select(s => new UnitsStack(s)))
    {
    }

    public MapEntities.Army ToMapArmy()
    {
      return new MapEntities.Army(Stacks.Where(s => s.Count > 0).Select(s => s.ToMapUnitsStack()));
    }

    public new void AddStack(UnitsStack stack)
    {
      base.AddStack(stack);
    }

    public new void RemoveStack(UnitsStack stack)
    {
      base.RemoveStack(stack);
    }
  }
}
