namespace BattleEngine
{
    public class ActionExecutor
    {
        protected Battle _battle; 
        
        public ActionExecutor(Battle battle)
        {
            _battle = battle;
        }
        
        public bool CanExecute => false;

        public void Execute(Battle battle)
        {
        }
    }
}