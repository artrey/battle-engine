using System.ComponentModel;

namespace BattleEngine.Units
{
    [Description("Goblin")]
    public class Goblin : Unit
    {
        public Goblin() : base(3, 2, 0, 1, 2,10 ,50)
        {
        }
    }
}
