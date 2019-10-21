namespace BattleEngine
{
  public class InitiativeScaleBuilder
  {
    private readonly Battle _battle;
    
    public InitiativeScaleBuilder(Battle battle)
    {
      _battle = battle;
    }
    
    public InitiativeScale Build(int roundOffset)
    {
      return new InitiativeScale(_battle.Stacks);
    }
  }
}
