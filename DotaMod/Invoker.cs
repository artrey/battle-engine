using System.ComponentModel;
using BattleEngine;
using BattleEngine.Perks;

namespace DotaMod
{
    [Description("Invoker")]
    public class Invoker : Unit
    {
        public Invoker() : base( 80, 10, 8, 10, 20,11 ,400)
        {
            Perks = new[] {new DeathBreath()};
        }
    }
}
