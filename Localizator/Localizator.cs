using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using IniParser;
using IniParser.Model;

namespace Localizator
{
    public static class Localizator
    {
        private static readonly DirectoryInfo AssemblyDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory;
        private static IniData _loc;
        
        public static void Init(CultureInfo cultureInfo)
        {
            if (_loc != null) throw new DoubleInitException();
            
            var locFile = AssemblyDirectory.GetFiles($"*{cultureInfo.ToString().ToLower()}*.ini").FirstOrDefault();
            if (locFile == null) throw new LocalizationNotFoundException(cultureInfo);

            _loc = new FileIniDataParser().ReadFile(locFile.FullName, Encoding.UTF8);
        }

        public static string T(this string str)
        {
            if (_loc == null) return str;
            return _loc.TryGetKey(str, out var tr) ? tr : str;
        }
    }
}
