using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class AlreadyWait : BaseModifier
    {
        public override void Apply(UnitsStack self)
        {
            self.SetAbility("wait", false);
            self.UpdateInitiative(-self.Initiative);
        }
    }
}
