namespace BattleEngine
{
    public interface IModifierChecker
    {
        bool Expired { get; }
        void Process();
        IModifierChecker Clone();
    }
}