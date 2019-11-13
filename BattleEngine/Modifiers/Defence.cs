using System;
using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class Defence : BaseModifier
    {
        public const double DefenceMultiplier = 0.3;

        public override void Apply(UnitsStack self) 
            =>self.UpdateDefence((uint) Math.Round(self.Defence * DefenceMultiplier));
    }
}
