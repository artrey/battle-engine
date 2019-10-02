using System.Collections.Generic;

namespace BattleEngine
{
  public class Army : ArmyHolder<UnitsStack>
  {
    public override uint Capacity => 6;
    
    public Army() : base()
    {
    }

    public Army(IEnumerable<UnitsStack> stacks) : base(stacks)
    {
    }
  }
}
