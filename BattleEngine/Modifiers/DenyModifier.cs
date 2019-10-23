using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public abstract class DenyModifier : AllowModifier
    {
        public override bool CanAct() => false;
        
        public override bool CanAttack(UnitsStack enemy) => false;

        public override bool CanBeAttacked(UnitsStack enemy) => false;

        public override bool CanWait() => false;

        public override bool CanCast(Cast cast, UnitsStack target) => false;

        public override bool CanBeCasted(Cast cast) => false;

        public override bool CanRetaliate(UnitsStack enemy) => false;
    }
}
