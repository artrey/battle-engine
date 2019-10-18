using System.ComponentModel;
using BattleEngine.BattleEntities;

namespace BattleEngine.Actions
{
    [Description("Give up")]
    public class GiveUp : BattleAction
    {
        public override bool Available(Battle battle, UnitsStack stack) => true;

        public override bool Validate(Battle battle, UnitsStack stack, params UnitsStack[] stacks) => true;

        public override void Act(Battle battle, UnitsStack stack, params UnitsStack[] stacks) => battle.GiveUp(stack);
    }
}