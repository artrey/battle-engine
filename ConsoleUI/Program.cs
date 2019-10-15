using System;
using System.Globalization;
using System.Linq;
using BattleEngine;
using BattleEngine.MapEntities;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Localizator.Localizator.Init(new CultureInfo("ru-RU"));
            var units = Loader.GetUnits().ToDictionary(u => u.Name, u => u);
            Console.WriteLine("=== UNITS ===");
            foreach (var unit in units)
            {
                Console.WriteLine(unit.Value);
            }

            var a1 = new Army(new[]
            {
                new UnitsStack(units["Angel"], 10),
                new UnitsStack(units["Devil"], 7),
                new UnitsStack(units["Goblin"], 159),
                new UnitsStack(units["Invoker"], 22),
            });
            Console.WriteLine("=== MAP ARMY 1 ===");
            Console.WriteLine(a1);

            var a2 = new Army(new[]
            {
                new UnitsStack(units["Chaos Knight"], 40),
                new UnitsStack(units["Devil"], 11),
                new UnitsStack(units["Archangel"], 6),
            });
            Console.WriteLine("=== MAP ARMY 2 ===");
            Console.WriteLine(a2);

            var ba1 = new BattleEngine.BattleEntities.Army(a1);
            Console.WriteLine("=== BATTLE ARMY 1 ===");
            Console.WriteLine(ba1);

            var ba2 = new BattleEngine.BattleEntities.Army(a2);
            Console.WriteLine("=== BATTLE ARMY 2 ===");
            Console.WriteLine(ba2);
            
            // here battle
            ba2.Stacks.First().Hit(ba1.Stacks.First());
            ba1.Stacks.First().Hit(ba2.Stacks.First());

            if (ba1.Count > 0)
            {
                Console.WriteLine("=== MAP ARMY 1 (AFTER BATTLE) ===");
                Console.WriteLine(ba1.ToMapArmy());
            }
            if (ba2.Count > 0)
            {
                Console.WriteLine("=== MAP ARMY 2 (AFTER BATTLE) ===");
                Console.WriteLine(ba2.ToMapArmy());
            }
        }
    }
}