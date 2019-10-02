using System.ComponentModel;

namespace BattleEngine
{
  public enum Perk
  {
    [Description("Бесконечный отпор")]
    UnlimitedRetaliation,
    [Description("Сопротивление огню")]
    ImmuneToFire,
    [Description("Стрелок")]
    Shooter,
  }
}