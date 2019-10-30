namespace BattleEngine
{
    public interface IModifiable
    {
        bool TryGetAbility(string type, out bool value);
        bool GetAbility(string type, bool defaultValue);
        void SetAbility(string type, bool value);
    }
}
