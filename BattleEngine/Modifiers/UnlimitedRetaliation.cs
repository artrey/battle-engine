using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class UnlimitedRetaliation : IModifier
    {
        public int Priority => 1000;
        public void Apply(UnitsStack self) => self.SetAbility("retaliate", true);
        public uint FixDamage(UnitsStack attacker, UnitsStack defender, uint damage) => damage;
    }
}
