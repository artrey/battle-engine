using System.ComponentModel;
using BattleEngine.BattleEntities;

namespace BattleEngine.Actions
{
    [Description("Defence")]
    public class Defence : BattleAction
    {
        public override bool Available(Battle battle, UnitsStack stack) => true;

        public override bool Validate(Battle battle, UnitsStack stack, params UnitsStack[] stacks) => true;

        public override void Act(Battle battle, UnitsStack stack, params UnitsStack[] stacks) => 
            stack.AddModifier(new Modifiers.Defence(), 1);
    }
}