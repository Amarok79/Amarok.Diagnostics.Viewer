// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace Amarok.Fabric;


/// <summary>
///     Converts the given String value to a Boolean value. :: Convert Null       ...  False "" ...
///     False "  "       ...  True Otherwise  ...  True :: ConvertBack Always  ...
///     DependencyProperty.UnsetValue
/// </summary>
[ValueConversion(typeof(String), typeof(Boolean))]
public sealed class IsNotNullOrEmptyConverter : MarkupExtensionValueConverter<
    IsNotNullOrEmptyConverter, String, Boolean>
{
    /// <summary></summary>
    protected override Object OnConvert(String value, Type targetType, Object parameter, CultureInfo culture)
    {
        return !String.IsNullOrEmpty(value);
    }

    /// <summary></summary>
    public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }
}
