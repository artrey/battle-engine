using BattleEngine.BattleEntities;

namespace BattleEngine.Perks
{
    public class DeathBreath : Perk
    {
        public override void Process(UnitsStack stack)
        {
            stack.AddPermanentModifier(new Modifiers.DeathBreath());
        }
    }
}