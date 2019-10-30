using System;

namespace BattleEngine.Modifiers.Checkers
{
    public abstract class LinkedModifierChecker<T> : IModifierChecker where T : IModifier
    {
        protected readonly T Modifier;
        
        protected LinkedModifierChecker(IModifier modifier)
        {
            if (modifier is T validModifier)
            {
                Modifier = validModifier;
            }
            else
            {
                throw new ArgumentException(nameof(modifier));
            }
        }

        public abstract bool Expired { get; }

        public virtual void Process()
        {
        }

        public abstract IModifierChecker Clone();
    }
}