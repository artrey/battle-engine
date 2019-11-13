using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class Invisible : BaseModifier
    {
        public override bool CanBeAttacked(UnitsStack enemy) => false;

        public override bool CanBeCasted(Cast cast) => cast.Mass;
    }
}
