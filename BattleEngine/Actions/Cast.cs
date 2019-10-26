using System.ComponentModel;
using System.Linq;
using BattleEngine.BattleEntities;
using BattleEngine.Modifiers;
using BattleEngine.Modifiers.Checkers;

namespace BattleEngine.Actions
{
    [Description("Cast")]
    public class Cast : BattleAction
    {
        public override bool Available(Battle battle, UnitsStack stack)
        {
            if (stack.Unit.Casts == null || !stack.Unit.Casts.Any()) return false;
            return stack.Unit.Casts.Any(
                cast => cast.Mass || battle.Stacks.Any(s => stack.Modifiers.All(m => m.CanCast(cast, s)) && 
                                                            s.Modifiers.All(m => m.CanBeCasted(cast))));
        }

        public override bool Validate(Battle battle, UnitsStack stack, params UnitsStack[] stacks)
        {
            throw new System.NotImplementedException();
        }

        public override void Act(Battle battle, UnitsStack stack, params UnitsStack[] stacks)
        {
            throw new System.NotImplementedException();
            stack.AddTemporaryModifier(new AlreadyAct(), new TurnModifierChecker(1));
        }
    }
}