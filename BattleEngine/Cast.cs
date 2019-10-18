namespace BattleEngine
{
    public abstract class Cast : Property
    {
        public bool ForFriends { get; }
        public bool ForEnemies { get; }
        public bool Mass { get; }
        
        protected Cast(bool forFriends, bool forEnemies, bool mass) : base(true)
        {
            ForFriends = forFriends;
            ForEnemies = forEnemies;
            Mass = mass;
        }
    }
}