using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BattleEngine.BattleEntities
{
  [Description("Battle army")]
  public class Army : AbstractArmy<UnitsStack>
  {
    public override uint Capacity => Constants.BATTLE_ARMY_MAX_CAPACITY;

    public IEnumerable<UnitsStack> AliveStacks => Stacks.Where(s => s.Count > 0);
    public bool HasUnits => AliveStacks.Any();

    public Army(MapEntities.Army army) : base(army.Stacks.Select(s => new UnitsStack(s)))
    {
    }

    public MapEntities.Army ToMapArmy() 
      => new MapEntities.Army(AliveStacks.Select(s => s.ToMapUnitsStack()));

    public new void AddStack(UnitsStack stack) => base.AddStack(stack);
    public new void RemoveStack(UnitsStack stack) => base.RemoveStack(stack);
  }
}
