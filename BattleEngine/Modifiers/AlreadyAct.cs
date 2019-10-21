using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class AlreadyAct : AllowModifier
    {
        public override bool CanAttack(UnitsStack enemy) => false;
        public override bool CanCast(Cast cast, UnitsStack target) => false;
        public override bool CanWait() => false;

        public override void Apply(UnitsStack self) => self.UpdateInitiative(-self.Initiative);
    }
}
