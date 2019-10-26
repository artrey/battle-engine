namespace BattleEngine.Modifiers.Checkers
{
    public class SkyGuardModifierChecker : LinkedModifierChecker<SkyGuard>
    {
        public SkyGuardModifierChecker(IModifier modifier) : base(modifier)
        {
        }

        public override bool Expired => _modifier.DefenceHitPoints == 0;
        public override IModifierChecker Clone()
        {
            return new SkyGuardModifierChecker(_modifier);
        }
    }
}