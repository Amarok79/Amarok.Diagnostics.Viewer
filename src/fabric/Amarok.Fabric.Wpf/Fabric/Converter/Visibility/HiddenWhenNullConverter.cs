// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace Amarok.Fabric;


/// <summary>
///     Converts the given Object value to a Visibility value. :: Convert Null       ...  Hidden
///     Otherwise  ...  Visible :: ConvertBack Always  ...  DependencyProperty.UnsetValue
/// </summary>
[ValueConversion(typeof(Object), typeof(Visibility))]
public sealed class HiddenWhenNullConverter : MarkupExtensionValueConverter<HiddenWhenNullConverter, Object, Visibility>
{
    /// <summary></summary>
    protected override Object OnConvert(Object value, Type targetType, Object parameter, CultureInfo culture)
    {
        return value == null ? Visibility.Hidden : Visibility.Visible;
    }

    /// <summary></summary>
    public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }
}
