using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class AlreadyAct : IModifier
    {
        public int Priority => 0;
        public void Apply(UnitsStack self) => self.SetAbility("act", false);
        public uint FixDamage(UnitsStack attacker, UnitsStack defender, uint damage) => damage;
    }
}
