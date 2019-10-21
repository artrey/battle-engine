using System.ComponentModel;
using System.Linq;
using BattleEngine.BattleEntities;

namespace BattleEngine.Actions
{
    [Description("Wait")]
    public class Wait : BattleAction
    {
        public override bool Available(Battle battle, UnitsStack stack)
            => stack.Modifiers.All(m => m.CanWait());

        public override bool Validate(Battle battle, UnitsStack stack, params UnitsStack[] stacks)
            => Available(battle, stack);

        public override void Act(Battle battle, UnitsStack stack, params UnitsStack[] stacks) 
            => stack.AddModifier(new Modifiers.AlreadyWait(), 1);

//        public override void OnEndTurn(Battle battle) => battle.CurrentUnitsStack.Refresh(false);
    }
}