using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class AlreadyWait : AllowModifier
    {
        public override bool CanWait() => false;
        public override void Apply(UnitsStack self) => self.UpdateInitiative(-self.Initiative);
    }
}
