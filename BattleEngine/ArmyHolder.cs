using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleEngine
{
  public abstract class ArmyHolder<T> : ICapacity where T : class
  {
    public abstract uint Capacity { get; }

    protected readonly List<T> stacks = new List<T>();

    public virtual IEnumerable<T> Stacks => stacks.ToArray();

    public uint Count => (uint)stacks.Count;

    protected ArmyHolder(IEnumerable<T> stacks)
    {
      if (stacks is null)
      {
        throw new ArgumentNullException(nameof(stacks));
      }
      foreach (var s in stacks)
      {
        AddStack(s);
      }

      if (Count == 0)
      {
        throw new ArgumentException(nameof(stacks));
      }
    }

    protected void AddStack(T stack)
    {
      if (stack is null)
      {
        throw new ArgumentNullException(nameof(stack));
      }
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

    protected void RemoveStack(T stack)
    {
      if (stack is null)
      {
        throw new ArgumentNullException(nameof(stack));
      }
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
