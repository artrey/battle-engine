using BattleEngine.BattleEntities;

namespace BattleEngine
{
    public abstract class Property : EqualityClass
    {
        public bool Active { get; }

        protected Property(bool active)
        {
            Active = active;
        }
        
        public abstract void Process(UnitsStack stack);
    }
}