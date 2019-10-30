namespace BattleEngine.Modifiers.Checkers
{
    public class SkyGuardModifierChecker : LinkedModifierChecker<SkyGuard>
    {
        public SkyGuardModifierChecker(IModifier modifier) : base(modifier)
        {
        }

        public override bool Expired => Modifier.DefenceHitPoints == 0;
        public override IModifierChecker Clone()
            => new SkyGuardModifierChecker(Modifier);
    }
}