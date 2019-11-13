using System;
using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class DeathBreath : BaseModifier
    {
        public override int Priority => 500;

        public override void Apply(UnitsStack self)
        {
            self.DamageHandlers.Add((attacker, defender, damage) =>
                Math.Max(defender.LastUnitHitPoints, damage));
        }
    }
}