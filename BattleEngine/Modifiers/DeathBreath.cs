using System;
using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class DeathBreath : AllowModifier
    {
        public override uint FixDamage(UnitsStack attacker, UnitsStack defender, uint damage)
        {
            return Math.Max(defender.LastUnitHitPoints, damage);
        }
    }
}