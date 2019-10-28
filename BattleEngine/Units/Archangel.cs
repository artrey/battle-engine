using System.ComponentModel;
using BattleEngine.Casts;

namespace BattleEngine.Units
{
  [Description("Archangel")]
  public class Archangel : Unit
  {
    public Archangel() : base(220, 35, 35, 50, 50, 12.6, 1300)
    {
      Casts = new []
      {
        new RaiseDead()
      };
    }
  }
}
