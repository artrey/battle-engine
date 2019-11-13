using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class AlreadyRetaliate : BaseModifier
    {
        public override void Apply(UnitsStack self) => self.SetAbility("retaliate", false);
    }
}