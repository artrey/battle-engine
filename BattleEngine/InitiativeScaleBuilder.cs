using System.Linq;

namespace BattleEngine
{
  public class InitiativeScaleBuilder
  {
    private readonly Battle _battle;
    
    public InitiativeScaleBuilder(Battle battle)
    {
      _battle = battle;
    }
    
    public InitiativeScale Build(uint roundOffset) 
      => new InitiativeScale(_battle.Left.AliveStacks.Concat(_battle.Right.AliveStacks), roundOffset);
  }
}
