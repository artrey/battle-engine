using System.ComponentModel;
using System.Reflection;
using Localizator;

namespace BattleEngine
{
  public static class Extensions
  {
    public static string Description<T>(this T source)
    {
        var fi = source.GetType().GetField(source.ToString()) ?? (MemberInfo)source.GetType();

        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
            typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : source.ToString();
    }
    
    public static string VisualName<T>(this T source)
    {
        return source.Description().T();
    }
  }
}