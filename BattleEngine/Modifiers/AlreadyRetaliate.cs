using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class AlreadyRetaliate : IModifier
    {
        public int Priority => 0;
        public void Apply(UnitsStack self) => self.SetAbility("retaliate", false);
        public uint FixDamage(UnitsStack attacker, UnitsStack defender, uint damage) => damage;
    }
}