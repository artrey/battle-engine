namespace BattleEngine
{
    public abstract class ParametersEntity
    {
        public uint HitPoints { get; protected set; }
        public uint Attack { get; protected set; }
        public uint Defence { get; protected set; }
        public uint MinDamage { get; protected set; }
        public uint MaxDamage { get; protected set; }
        public double Initiative { get; protected set; }

        public ParametersEntity()
        {
        }

        public ParametersEntity(ParametersEntity other)
        {
            HitPoints = other.HitPoints;
            Attack = other.Attack;
            Defence = other.Defence;
            MinDamage = other.MinDamage;
            MaxDamage = other.MaxDamage;
            Initiative = other.Initiative;
        }
    }
}