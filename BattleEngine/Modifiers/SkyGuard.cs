using System;
using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class SkyGuard : AllowModifier
    {
        public uint DefenceHitPoints { get; private set; }
        
        public SkyGuard(uint defenceHitPoints)
        {
            DefenceHitPoints = defenceHitPoints;
        }

        public override uint FixDamage(UnitsStack attacker, UnitsStack defender, uint damage)
        {
            var absorption = Math.Min(DefenceHitPoints, damage / 2);
            DefenceHitPoints -= absorption;
            return damage - absorption;
        }
    }
}