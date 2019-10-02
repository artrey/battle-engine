using System.ComponentModel;

namespace BattleEngine
{
  public enum Action
  {
    [Description("Атаковать")]
    Attack,
    [Description("Применить способноть")]
    Ability,
    [Description("Ожидать")]
    Await,
    [Description("Обороняться")]
    Defend,
  }
}