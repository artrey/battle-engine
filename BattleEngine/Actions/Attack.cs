using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using BattleEngine.BattleEntities;
using BattleEngine.Modifiers;

namespace BattleEngine.Actions
{
    [Description("Attack")]
    public class Attack : BattleAction
    {
        private static bool CanHit(UnitsStack current, UnitsStack enemy) => 
            current.Modifiers().All(m => m.CanAttack(enemy)) && 
            enemy.Modifiers().All(m => m.CanBeAttacked(current));
        
        private static bool CanRetaliate(UnitsStack current, UnitsStack enemy) => 
            enemy.Modifiers().All(m => m.CanRetaliate(current));

        private static void Hit(UnitsStack current, UnitsStack enemy)
        {
            var mult = 1 + 0.05 * Math.Abs((int)current.Attack - (int)enemy.Defence);
            if (current.Attack < enemy.Defence)
            {
                mult = 1 / mult;
            }

            var damage = (uint) (current.Count * mult * Utils.GetURandom(current.MinDamage, current.MaxDamage));
      
            enemy.Damage(damage);
        }
        
        public override bool Available(Battle battle, UnitsStack stack)
        {
            return battle.GetOppositeArmy(stack).AliveStacks.Any(enemy => CanHit(stack, enemy));
        }
        
        public override bool Validate(Battle battle, UnitsStack stack, params UnitsStack[] stacks)
        {
            if (stacks is null) throw new ArgumentNullException(nameof(stacks));
            if (stacks.Length == 0) throw new ArgumentException("Need targets", nameof(stacks));
            
            return stacks.All(enemy => CanHit(stack, enemy));
        }

        public override void Act(Battle battle, UnitsStack stack, params UnitsStack[] stacks)
        {
            if (!Validate(battle, stack, stacks)) throw new InvalidDataException("Not allowed action");
            
            foreach (var enemy in stacks)
            {
                Hit(stack, enemy);
            }
            
            foreach (var enemy in stacks.Where(enemy => CanRetaliate(stack, enemy)))
            {
                Hit(enemy, stack);
                enemy.AddModifier(new AlreadyRetaliate(), 1);
            }
        }
    }
}