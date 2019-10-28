using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public abstract class AllowModifier : EqualityClass, IModifier
    {
        public virtual bool CanAct() => true;
        public virtual bool CanWait() => true;
        public virtual bool CanAttack(UnitsStack enemy) => true;
        public virtual bool CanBeAttacked(UnitsStack enemy) => true;
        public virtual bool CanCast(Cast cast, UnitsStack target) => true;
        public virtual bool CanBeCasted(Cast cast) => true;
        public virtual bool CanRetaliate(UnitsStack enemy) => true;
        public virtual bool CanGotRetaliate(UnitsStack enemy) => true;
        public virtual void Apply(UnitsStack self) {}
        public virtual uint FixDamage(UnitsStack attacker, UnitsStack defender, uint damage) => damage;
    }
}
