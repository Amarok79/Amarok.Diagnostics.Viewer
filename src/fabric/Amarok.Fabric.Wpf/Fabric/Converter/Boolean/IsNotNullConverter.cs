// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace Amarok.Fabric;


/// <summary>
///     Converts the given Object value to a Boolean value. :: Convert Null       ...  False Otherwise
///     ...  True :: ConvertBack Always  ...  DependencyProperty.UnsetValue
/// </summary>
[ValueConversion(typeof(Object), typeof(Boolean))]
public sealed class IsNotNullConverter : MarkupExtensionValueConverter<IsNotNullConverter, Object, Boolean>
{
    /// <summary></summary>
    protected override Object OnConvert(Object value, Type targetType, Object parameter, CultureInfo culture)
    {
        return value != null;
    }

    /// <summary></summary>
    public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }
}
