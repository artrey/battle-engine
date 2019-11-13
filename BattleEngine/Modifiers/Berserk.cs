using System;
using System.ComponentModel;
using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    [Description("Berserk")]
    public class Berserk : BaseModifier
    {
        public override int Priority => 1000;
        
        public double AttackMultiplier { get; } 
        
        public Berserk(double attackMultiplier = 1.0)
        {
            AttackMultiplier = attackMultiplier;
        }

        public override void Apply(UnitsStack self)
        {
            self.SetAbility("wait", false);
            self.SetAbility("cast", false);
            self.UpdateAttack((uint) Math.Round(self.Attack * AttackMultiplier));
        }
    }
}
