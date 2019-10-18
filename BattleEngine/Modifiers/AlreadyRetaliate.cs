using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class AlreadyRetaliate : AllowModifier
    {
        public override bool CanRetaliate(UnitsStack enemy) => false;
    }
}