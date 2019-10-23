using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using IniParser;
using IniParser.Model;

namespace Localizer
{
    public static class Localizer
    {
        private static readonly DirectoryInfo AssemblyDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory;
        private static readonly Dictionary<string, IniData> Locales = new Dictionary<string, IniData>();
        private static IniData _currentLocale;
        
        public static void SetupLocale(CultureInfo cultureInfo)
        {
            if (cultureInfo == null) throw new ArgumentNullException(nameof(cultureInfo));
            var key = cultureInfo.ToString().ToLower();

            if (Locales.TryGetValue(key, out _currentLocale)) return;
            
            var locFile = AssemblyDirectory.GetFiles($"*{key}*.ini").FirstOrDefault();
            if (locFile == null) throw new LocalizationNotFoundException(cultureInfo);

            _currentLocale = new FileIniDataParser().ReadFile(locFile.FullName, Encoding.UTF8);
            Locales.Add(key, _currentLocale);
        }

        public static string T(this string str)
        {
            if (_currentLocale == null) return str;
            try
            {
                return _currentLocale.TryGetKey(str, out var tr) ? tr : str;
            }
            catch (ArgumentException)
            {
                return str;
            }
        }
    }
}
