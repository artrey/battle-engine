using System.ComponentModel;
using System.Reflection;
using Localizer;

namespace BattleEngine
{
  public static class Extensions
  {
    public static string Description<T>(this T source)
    {
        var attributes = (DescriptionAttribute[])source.GetType().GetCustomAttributes(
            typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : source.ToString();
    }
    
    public static string VisualName<T>(this T source)
    {
        return source.Description().T();
    }
  }
}