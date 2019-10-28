using System;
using System.ComponentModel;
using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    [Description("Berserk")]
    public class Berserk : AllowModifier
    {
        public double AttackMultiplier { get; } 
        
        public Berserk(double attackMultiplier = 1.0)
        {
            AttackMultiplier = attackMultiplier;
        }
        
        public override bool CanWait() => false;
        public override bool CanCast(Cast cast, UnitsStack target) => false;
        public override void Apply(UnitsStack self) 
            => self.UpdateAttack((uint) Math.Round(self.Attack * AttackMultiplier));
    }
}
