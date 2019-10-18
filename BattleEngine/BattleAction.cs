using System.Collections.Generic;
using BattleEngine.BattleEntities;

namespace BattleEngine
{
    public abstract class BattleAction : EqualityClass
    {
        public static readonly IEnumerable<BattleAction> AllActions = Loader.GetTypesFromLocalAssemblies<BattleAction>();

        public abstract bool Available(Battle battle, UnitsStack stack);
        
        public abstract bool Validate(Battle battle, UnitsStack stack, params UnitsStack[] stacks);

        public abstract void Act(Battle battle, UnitsStack stack, params UnitsStack[] stacks);
        
        public virtual void OnEndTurn(Battle battle) => battle.NextRound.Enqueue(battle.CurrentRound.Dequeue());
    }
}
