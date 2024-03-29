using BattleEngine.BattleEntities;
using BattleEngine.Modifiers;

namespace BattleEngine.Perks
{
    public class UnlimitedRetalitation : Perk
    {
        public override void Process(UnitsStack stack)
        {
            stack.AddPermanentModifier(new UnlimitedRetaliation());
        }
    }
}
