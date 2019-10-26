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

        public override void Apply(UnitsStack self)
        {
        }
    }
}