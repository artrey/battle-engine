namespace BattleEngine
{
    public class EqualityClass
    {
        public override bool Equals(object obj) => obj != null && GetType() == obj.GetType();

        public override int GetHashCode() => GetType().GetHashCode();
        
        public static bool operator ==(EqualityClass a, EqualityClass b)
        {
            return !(a is null) && a.Equals(b);
        }

        public static bool operator !=(EqualityClass a, EqualityClass b)
        {
            return !(a == b);
        }
    }
}