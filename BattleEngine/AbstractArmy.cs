using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleEngine
{
  public abstract class AbstractArmy<T> : ICapacity
  {
    private readonly List<T> _stacks = new List<T>();
    public IEnumerable<T> Stacks => _stacks.AsReadOnly();
    
    public abstract uint Capacity { get; }
    public uint Count => (uint)_stacks.Count;

    protected AbstractArmy(IEnumerable<T> stacks)
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
      if (Count >= Capacity)
      {
        throw new OverflowException($"Max capacity is {Capacity}");
      }
      if (_stacks.Contains(stack))
      {
        throw new ArgumentException(nameof(stack));
      }
      _stacks.Add(stack);
    }

    protected void RemoveStack(T stack)
    {
      if (stack == null)
      {
        throw new ArgumentNullException(nameof(stack));
      }
      if (!_stacks.Contains(stack))
      {
        throw new ArgumentException(nameof(stack));
      }
      _stacks.Remove(stack);
    }

    public override string ToString() 
      => $@"<{this.VisualName()}: [{string.Join(", ", _stacks.Select(s => s.ToString()))}]>";
  }
}
