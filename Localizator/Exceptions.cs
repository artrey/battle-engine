using System;
using System.Globalization;

namespace Localizator
{
    public class LocalizatorException : Exception
    {
    }

    public class DoubleInitException : LocalizatorException
    {
        public override string ToString()
        {
            return "Localizator: try to init again";
        }
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
            return $"Localizator: localization for {CultureInfo} not found";
        }
    }
}