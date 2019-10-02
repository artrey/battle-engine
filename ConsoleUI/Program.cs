using System;
using System.Linq;
using BattleEngine;
using BattleEngine.Units;
using Action = BattleEngine.Action;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
//            var u = new Angel();
//            var s = new UnitsStack(u, 10);
//            Console.WriteLine(s.Count);
//            s.SetCount(100);
//            Console.WriteLine(s.Count);
//            s.Add(10);
//            Console.WriteLine(s.Count);
//            s.Decrease(80);
//            Console.WriteLine(s.Count);
//            Console.WriteLine(s.IsAlive);
//            s.Decrease(30);
//            Console.WriteLine(s.Count);
//            Console.WriteLine(s.IsAlive);
//
//            Console.WriteLine(UnitType.Angel.Description());
//
//            var a = new Army(new [] {s});
//            Console.WriteLine(a.Count);
//            a.RemoveStack(s);
//            Console.WriteLine(a.Count);
//            a.AddStack(s);
//            Console.WriteLine(a.Count);
//
//            Console.WriteLine(Perk.ImmuneToFire.Description());
//
//            var scale = new InitiativeScale(new[] {new BattleUnitsStack(new Devil(), 10)}, new[] {new BattleUnitsStack(u, 5)});
//            foreach (var stack in scale)
//            {
//                Console.WriteLine(stack);
//            }
//            Console.WriteLine(scale.IsFinished);
//
//            var scale2 = new InitiativeScale(new[] {new BattleUnitsStack(new Devil(), 10), new BattleUnitsStack(u, 5)}, null);
//            foreach (var stack in scale2)
//            {
//                Console.WriteLine(stack);
//            }
//            Console.WriteLine(scale2.IsFinished);
            var army1 = new BattleArmy(new[]
                {new BattleUnitsStack(new Angel(), 5), new BattleUnitsStack(new Angel(), 30)});
            var army2 = new BattleArmy(new[]
                {new BattleUnitsStack(new Angel(), 4), new BattleUnitsStack(new Devil(), 41)});
            var battle = new Battle(army1, army2);
            
            while (!battle.IsFinished)
            {
                var s = battle.NextUnitsStack();
                foreach (var stack in battle.Left.Stacks.Concat(battle.Right.Stacks))
                {
                    if (!battle.PreviewAct(s, Action.Attack, stack)) continue;
                    battle.Act(s, Action.Attack, stack);
                    break;
                }
            }

            Console.WriteLine(battle.Winner);
        }
    }
}