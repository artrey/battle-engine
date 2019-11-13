using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class AlreadyAct : BaseModifier
    {
        public override void Apply(UnitsStack self) => self.SetAbility("act", false);
    }
}
