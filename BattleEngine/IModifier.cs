using BattleEngine.BattleEntities;

namespace BattleEngine
{
    public interface IModifier
    {
        bool CanAttack(UnitsStack enemy);
        bool CanBeAttacked(UnitsStack enemy);

        bool CanWait();

        bool CanCast(Cast cast, UnitsStack target);
        bool CanBeCasted(Cast cast);

        bool CanRetaliate(UnitsStack enemy);

        void Apply(UnitsStack self);
    }
}