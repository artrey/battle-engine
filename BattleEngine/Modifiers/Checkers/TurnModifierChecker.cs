namespace BattleEngine.Modifiers.Checkers
{
    public class TurnModifierChecker : IModifierChecker
    {
        public uint Turns { get; private set; }
        public TurnModifierChecker(uint turns)
        {
            Turns = turns;
        }

        public bool Expired => Turns == 0;
        public void Process() => Turns -= 1;
        public IModifierChecker Clone() => new TurnModifierChecker(Turns);
    }
}