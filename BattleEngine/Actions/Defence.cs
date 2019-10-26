using System.ComponentModel;
using BattleEngine.BattleEntities;
using BattleEngine.Modifiers.Checkers;

namespace BattleEngine.Actions
{
    [Description("Defence")]
    public class Defence : BattleAction
    {
        public override bool Available(Battle battle, UnitsStack stack) => true;

        public override bool Validate(Battle battle, UnitsStack stack, params UnitsStack[] stacks) => true;

        public override void Act(Battle battle, UnitsStack stack, params UnitsStack[] stacks) => 
            stack.AddTemporaryModifier(new Modifiers.Defence(), new TurnModifierChecker(1));
    }
}