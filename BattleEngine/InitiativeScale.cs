using System.Collections.Generic;
using System.IO;
using System.Linq;
using BattleEngine.BattleEntities;

namespace BattleEngine
{
  public class InitiativeScale
  {
    private Queue<UnitsStack> _stacks;
    public IEnumerable<UnitsStack> Stacks => _stacks.ToArray();
    public UnitsStack Current => _stacks.FirstOrDefault();
    public bool IsFinished => Current == null;

    public InitiativeScale(IEnumerable<UnitsStack> stacks = null)
    {
      _stacks = stacks == null ? new Queue<UnitsStack>() : Build(stacks);
    }

    public UnitsStack Dequeue()
    {
      if (IsFinished)
      {
        throw new InvalidDataException("Scale already is empty");
      }

      return _stacks.Dequeue();
    }

    public void Enqueue(UnitsStack stack) => _stacks.Enqueue(stack);

    private static Queue<UnitsStack> Build(IEnumerable<UnitsStack> stacks) 
      => new Queue<UnitsStack>(stacks.OrderByDescending(s => s.Initiative));

    public void Refresh() => _stacks = Build(_stacks.Where(s => s.Count > 0));

    public override string ToString() => string.Join(" -> ", _stacks);
  }
}
