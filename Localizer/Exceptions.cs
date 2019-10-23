using System;
using System.Globalization;

namespace Localizer
{
    public class LocalizatorException : Exception
    {
    }

    public class LocalizationNotFoundException : LocalizatorException
    {
        public CultureInfo CultureInfo { get; }
        
        public LocalizationNotFoundException(CultureInfo cultureInfo)
        {
            CultureInfo = cultureInfo;
        }
        
        public override string ToString()
        {
            return $"Localizer: localization for {CultureInfo} not found";
        }
    }
}