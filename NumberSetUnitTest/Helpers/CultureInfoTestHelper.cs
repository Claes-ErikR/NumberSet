using System.Globalization;

namespace NumberSetUnitTest.Helpers;

internal static class CultureInfoTestHelper
{
    public static CultureInfo GetNumberCommaSeparatedCulture()
    {
        var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

        var culture = cultures.First(x => x.NumberFormat.NumberDecimalSeparator == ",");
        
        return culture;
    }
}
