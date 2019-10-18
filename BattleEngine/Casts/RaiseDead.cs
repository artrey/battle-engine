using BattleEngine.BattleEntities;

namespace BattleEngine.Casts
{
    public class RaiseDead : Cast
    {
        public RaiseDead() : base(true, true, false)
        {
        }

        public override void Process(UnitsStack stack)
        {
            throw new System.NotImplementedException();
        }
    }
}