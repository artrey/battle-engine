namespace BattleEngine
{
    public interface IParametersEntity
    {
        uint HitPoints { get; }
        uint Attack { get; }
        uint Defence { get; }
        uint MinDamage { get; }
        uint MaxDamage { get; }
        double Initiative { get; }
    }
}