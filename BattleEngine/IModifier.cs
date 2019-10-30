using BattleEngine.BattleEntities;

namespace BattleEngine
{
    public interface IModifier
    {
        int Priority { get; }
        
//        bool CanAct();
//
//        bool CanWait();
//        
//        bool CanAttack(UnitsStack enemy);
//        bool CanBeAttacked(UnitsStack enemy);
//
//        bool CanCast(Cast cast, UnitsStack target);
//        bool CanBeCasted(Cast cast);
//
//        bool CanRetaliate(UnitsStack enemy);
//        bool CanGotRetaliate(UnitsStack enemy);

        void Apply(UnitsStack self);
        
        uint FixDamage(UnitsStack attacker, UnitsStack defender, uint damage);
    }
}
