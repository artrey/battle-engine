using System.Reflection;
using System.ComponentModel;

namespace BattleEngine
{
  public static class Extensions
  {
    public static string Description<T>(this T source)
    {
        FieldInfo fi = source.GetType().GetField(source.ToString());

        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
            typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : source.ToString();
    }
  }
}
