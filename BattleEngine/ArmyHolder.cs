using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleEngine
{
  public abstract class ArmyHolder<T> : ICapacity where T : ICapacity
  {
    public abstract uint Capacity { get; }

    protected readonly List<T> stacks = new List<T>();

    public IEnumerable<T> Stacks => stacks.AsReadOnly();
    public IEnumerable<T> AliveStacks => stacks.Where(s => s.Count > 0).ToList().AsReadOnly();

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
      if (stack == null)
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
      if (stack == null)
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
