using System.Collections.Generic;

namespace BattleEngine.MapEntities
{
  public class Army : ArmyHolder<UnitsStack>
  {
    public override uint Capacity => Constants.MAP_ARMY_MAX_CAPACITY;

    public Army(IEnumerable<UnitsStack> stacks) : base(stacks)
    {
    }
  }
}
