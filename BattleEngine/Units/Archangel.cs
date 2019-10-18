using System.Collections.Generic;
using BattleEngine.Casts;

namespace BattleEngine.Units
{
  public class Archangel : Unit
  {
    public Archangel() : base("Archangel",220, 35, 35, 50, 50, 12.6, 1300)
    {
      Casts = new List<Cast> {new RaiseDead()};
    }
  }
}
