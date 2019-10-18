using System;
using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class InSky : DenyModifier
    {
        public const double AttackMultiplier = 0.3;
        public override bool CanAttack(UnitsStack enemy) => true;

        public override void Apply(UnitsStack self) 
            => self.UpdateAttack((uint) Math.Round(self.Attack * AttackMultiplier));
    }
}
