using System.ComponentModel;

namespace BattleEngine.Units
{
  [Description("Angel")]
  public class Angel : Unit
  {
    public Angel() : base(200, 25, 25, 50, 50, 12.4, 1000)
    {
    }
  }
}
