// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Globalization;
using System.Windows.Data;


namespace Amarok.Fabric;


/// <summary>
///     Converts the given Boolean value to the negated Boolean value. :: Convert True   ...  False
///     False  ...  True :: ConvertBack True   ...  False False  ...  True
/// </summary>
[ValueConversion(typeof(Boolean), typeof(Boolean))]
public sealed class NotConverter : MarkupExtensionValueConverter<NotConverter, Boolean, Boolean>
{
    /// <summary></summary>
    protected override Object OnConvert(Boolean value, Type targetType, Object parameter, CultureInfo culture)
    {
        return !value;
    }

    /// <summary></summary>
    protected override Object OnConvertBack(Boolean value, Type targetType, Object parameter, CultureInfo culture)
    {
        return !value;
    }
}
