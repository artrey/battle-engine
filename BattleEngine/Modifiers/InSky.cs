using System;
using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class InSky : AllowModifier
    {
        public const double AttackMultiplier = 0.3;
        
        public override bool CanWait() => false;
        public override bool CanBeAttacked(UnitsStack enemy) => false;
        public override bool CanCast(Cast cast, UnitsStack target) => false;
        public override bool CanBeCasted(Cast cast) => false;
        public override bool CanRetaliate(UnitsStack enemy) => false;
        public override bool CanGotRetaliate(UnitsStack enemy) => false;

        public override void Apply(UnitsStack self) 
            => self.UpdateAttack((uint) Math.Round(self.Attack * AttackMultiplier));
    }
}
