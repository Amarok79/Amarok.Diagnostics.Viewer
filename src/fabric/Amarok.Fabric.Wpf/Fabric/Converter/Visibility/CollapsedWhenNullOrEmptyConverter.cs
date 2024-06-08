// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace Amarok.Fabric;


/// <summary>
///     Converts the given String value to a Visibility value. :: Convert Null       ...  Collapsed ""
///     ...  Collapsed "  "       ...  Visible Otherwise  ...  Visible :: ConvertBack Always  ...
///     DependencyProperty.UnsetValue
/// </summary>
[ValueConversion(typeof(String), typeof(Visibility))]
public sealed class CollapsedWhenNullOrEmptyConverter : MarkupExtensionValueConverter<
    CollapsedWhenNullOrEmptyConverter, String, Visibility>
{
    /// <summary></summary>
    protected override Object OnConvert(String value, Type targetType, Object parameter, CultureInfo culture)
    {
        return String.IsNullOrEmpty(value) ? Visibility.Collapsed : Visibility.Visible;
    }

    /// <summary></summary>
    public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }
}
