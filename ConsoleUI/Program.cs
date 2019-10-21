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
                new UnitsStack(units["Invoker"], 24),
            });
            Console.WriteLine("=== MAP ARMY 1 ===");
            Console.WriteLine(a1);

            var a2 = new Army(new[]
            {
                new UnitsStack(units["Chaos Knight"], 10),
                new UnitsStack(units["Devil"], 12),
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

            var i = 0;
            
            // here battle
            var battle = new Battle(ba1, ba2);
            while (!battle.IsFinished)
            {
                Console.WriteLine($"{battle.Round} | {battle.CurrentRound} | {battle.Round + 1} | {battle.NextRound}");
                var stack = battle.CurrentUnitsStack;
                var army = battle.CurrentArmy;

                var actions = battle.CurrentAvailableActions.ToList();
                var action = i++ % 3 == 0 ? actions.Last() : actions.First();

                // TODO: select the enemy (enemies) if need
                var enemy = battle.CurrentRound.Stacks.Union(battle.NextRound.Stacks).First(s => battle.GetArmy(s) != army);

                if (battle.ActValid(action, stack, enemy))
                {
                    battle.Act(action, stack, enemy);
                }
                else
                {
                    throw new Exception("New action is required");
                }
            }
            
            Console.WriteLine("=== WINNER ===");
            Console.WriteLine(battle.Winner);

            if (ba1.HasUnits)
            {
                Console.WriteLine("=== MAP ARMY 1 (AFTER BATTLE) ===");
                Console.WriteLine(ba1.ToMapArmy());
            }
            if (ba2.HasUnits)
            {
                Console.WriteLine("=== MAP ARMY 2 (AFTER BATTLE) ===");
                Console.WriteLine(ba2.ToMapArmy());
            }
        }
    }
}
