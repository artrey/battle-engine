using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class Invisible : AllowModifier
    {
        public override bool CanBeAttacked(UnitsStack enemy) => false;

        public override bool CanBeCasted(Cast cast) => cast.Mass;
    }
}
