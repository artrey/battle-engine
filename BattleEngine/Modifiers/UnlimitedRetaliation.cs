using BattleEngine.BattleEntities;

namespace BattleEngine.Modifiers
{
    public class UnlimitedRetaliation : AllowModifier
    {
        private const string Key = "CanRetaliate";

        public override void Apply(UnitsStack self)
        {
            self.Properties[Key] = true;
        }
    }
}
