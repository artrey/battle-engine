using System.ComponentModel;

namespace BattleEngine
{
  public enum UnitType
  {
    [Description("Гоблин")]
    Goblin,
    [Description("Гном")]
    Dwarf,
    [Description("Лесной эльф")]
    Ranger,
    [Description("Дьявол")]
    Devil,
    [Description("Ангел")]
    Angel,
    [Description("Гидра")]
    Hydra,
  }
}