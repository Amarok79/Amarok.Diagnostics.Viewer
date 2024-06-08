// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace Amarok.Fabric;


/// <summary>
///     Converts the given Boolean value to a configurable Object value. :: Convert True   ...
///     TrueValue property False  ...  FalseValue property :: ConvertBack equal to TrueValue   ... True
///     equal to FalseValue  ...  False Otherwise            ...  DefaultValue
/// </summary>
[ValueConversion(typeof(Boolean), typeof(Object))]
public sealed class BooleanToObjectConverter : ValueConverter<Boolean, Object>
{
    /// <summary>
    ///     Gets or sets the Object that is returned by Convert() when True is supplied. Defaults to True.
    /// </summary>
    public Object TrueValue { get; set; }

    /// <summary>
    ///     Gets or sets the Object that is returned by Convert() when False is supplied. Defaults to
    ///     False.
    /// </summary>
    public Object FalseValue { get; set; }

    /// <summary>
    ///     Gets or sets the Object that is returned by ConvertBack() when neither TrueValue nor FalseValue
    ///     are equal to the supplied value. Defaults to DependencyProperty.UnsetValue.
    /// </summary>
    public Object DefaultValue { get; set; }


    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    public BooleanToObjectConverter()
    {
        TrueValue    = true;
        FalseValue   = false;
        DefaultValue = DependencyProperty.UnsetValue;
    }


    /// <summary></summary>
    protected override Object OnConvert(Boolean value, Type targetType, Object parameter, CultureInfo culture)
    {
        return value ? TrueValue : FalseValue;
    }

    /// <summary></summary>
    protected override Object OnConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
    {
        if (Equals(value, TrueValue))
        {
            return true;
        }

        if (Equals(value, FalseValue))
        {
            return false;
        }

        return DefaultValue;
    }
}
