using System.Collections.Generic;

namespace BattleEngine
{
  public class BattleArmy : ArmyHolder<BattleUnitsStack>
  {
    public override uint Capacity => 12;

    public BattleArmy(IEnumerable<BattleUnitsStack> stacks) : base(stacks)
    {
    }
  }
}
