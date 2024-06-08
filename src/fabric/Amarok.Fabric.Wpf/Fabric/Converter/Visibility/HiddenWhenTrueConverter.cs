﻿// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace Amarok.Fabric;


/// <summary>
///     Converts the given Boolean value to a Visibility value. :: Convert True   ...  Hidden False ...
///     Visible :: ConvertBack Visible    ...  False Collapsed  ...  True Hidden     ...  True
/// </summary>
[ValueConversion(typeof(Boolean), typeof(Visibility))]
public sealed class HiddenWhenTrueConverter : MarkupExtensionValueConverter<
    HiddenWhenTrueConverter, Boolean, Visibility>
{
    /// <summary></summary>
    protected override Object OnConvert(Boolean value, Type targetType, Object parameter, CultureInfo culture)
    {
        return value ? Visibility.Hidden : Visibility.Visible;
    }

    /// <summary></summary>
    protected override Object OnConvertBack(Visibility value, Type targetType, Object parameter, CultureInfo culture)
    {
        return value == Visibility.Visible ? false : true;
    }
}
