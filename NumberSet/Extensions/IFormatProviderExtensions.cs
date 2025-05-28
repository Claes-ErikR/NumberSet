using System.Globalization;

namespace Utte.NumberSet.Extensions;

internal static class IFormatProviderExtensions
{
    public static char GetNumberSetElementSeparator(this IFormatProvider? formatProvider)
    {
        CultureInfo cultureInfo = (formatProvider == null || !(formatProvider is CultureInfo)) ? CultureInfo.CurrentCulture : (CultureInfo)formatProvider;
        if (cultureInfo.NumberFormat.NumberDecimalSeparator == ".") return ',';
        if (cultureInfo.NumberFormat.NumberDecimalSeparator == ",") return ';';

        return ',';
    }
}
