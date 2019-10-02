using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleEngine
{
  public abstract class ArmyHolder<T> where T : UnitsStack
  {
    public abstract uint Capacity { get; }

    protected readonly List<T> stacks = new List<T>();

    public IEnumerable<T> Stacks => stacks.ToList();

    public uint Count => (uint)stacks.Count();

    public ArmyHolder() {}

    public ArmyHolder(IEnumerable<T> stacks)
    {
      foreach (var s in stacks)
      {
        AddStack(s);
      }
    }

    public void AddStack(T stack)
    {
      if (stacks.Count >= Capacity)
      {
        throw new OverflowException($"Max capacity is {Capacity}");
      }
      if (stacks.Contains(stack))
      {
        throw new ArgumentException(nameof(stack));
      }
      stacks.Add(stack);
    }

    public void RemoveStack(T stack)
    {
      if (!stacks.Contains(stack))
      {
        throw new ArgumentException(nameof(stack));
      }
      stacks.Remove(stack);
    }

    public override string ToString()
    {
      return $@"<ArmyHolder [{string.Join(", ", stacks.Select(s => s.ToString()))}]>";
    }
  }
}
