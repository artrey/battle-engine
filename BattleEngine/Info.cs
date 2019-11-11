using System.Collections.Generic;
using BattleEngine.BattleEntities;

namespace BattleEngine
{
    public class Info
    {
        public bool NeedUserChoice { get; }
        public IEnumerable<UnitsStack> Stacks { get; }

        public Info(bool needUserChoice, IEnumerable<UnitsStack> stacks)
        {
            NeedUserChoice = needUserChoice;
            Stacks = stacks;
        }
    }

    public class NeedUserChoiceInfo : Info
    {
        public NeedUserChoiceInfo() : base(true, null) {}
    }

    public class PreparedInfo : Info
    {
        public PreparedInfo(IEnumerable<UnitsStack> stacks) : base(false, stacks) {}
    }
}
