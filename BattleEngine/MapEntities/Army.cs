using System.Collections.Generic;
using System.ComponentModel;

namespace BattleEngine.MapEntities
{
  [Description("Map army")]
  public class Army : AbstractArmy<UnitsStack>
  {
    public override uint Capacity => Constants.MAP_ARMY_MAX_CAPACITY;

    public Army(IEnumerable<UnitsStack> stacks) : base(stacks)
    {
    }
  }
}
