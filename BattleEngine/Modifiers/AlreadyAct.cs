namespace BattleEngine.Modifiers
{
    public class AlreadyAct : AllowModifier
    {
        public override bool CanAct() => false;
    }
}
