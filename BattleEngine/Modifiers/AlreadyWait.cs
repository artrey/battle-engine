using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class AlreadyWait : IModifier
    {
        public int Priority => 0;
        public void Apply(UnitsStack self)
        {
            self.SetAbility("wait", false);
            self.UpdateInitiative(-self.Initiative);
        }
        public uint FixDamage(UnitsStack attacker, UnitsStack defender, uint damage) => damage;
    }
}
