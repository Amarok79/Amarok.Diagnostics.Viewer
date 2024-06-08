// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;


namespace Amarok.Fabric;


/// <summary>
///     Converts the given Int32 to the Object at the index position in the set Values collection. ::
///     Convert 0..n          ...  Object at the Index position Out-Of-Range  ...  DefaultValue ::
///     ConvertBack equal to Object at Index position   ...  Index not equal to any Object ...
///     DependencyProperty.Unset
/// </summary>
[ContentProperty("Values")]
[ValueConversion(typeof(Int32), typeof(Object))]
public sealed class IndexToObjectConverter : ValueConverter<Int32, Object>
{
    /// <summary>
    ///     Gets or sets a collection of Objects. The Convert() method uses this collection to return the
    ///     Object at the index that is represented by the supplied Int32 value. Defaults to an empty list.
    /// </summary>
    public List<Object> Values { get; set; }

    /// <summary>
    ///     Gets or sets the Object that is returned by the Convert() method when the supplied Int32 value
    ///     is outside of the list collection bounds. Defaults to DependencyProperty.UnsetValue.
    /// </summary>
    public Object DefaultValue { get; set; }

    /// <summary>
    ///     Gets or sets the Object that is returned by the ConvertBack() method when the supplied Object
    ///     is not equal to any of the Objects stored in the Values collection. Defaults to
    ///     DependencyProperty.UnsetValue.
    /// </summary>
    public Object DefaultIndex { get; set; }


    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    public IndexToObjectConverter()
    {
        Values       = new List<Object>();
        DefaultValue = DependencyProperty.UnsetValue;
        DefaultIndex = DependencyProperty.UnsetValue;
    }


    /// <summary></summary>
    protected override Object OnConvert(Int32 value, Type targetType, Object parameter, CultureInfo culture)
    {
        if (Values == null)
        {
            return DefaultValue;
        }

        if (value < 0 || value >= Values.Count)
        {
            return DefaultValue;
        }

        return Values[value];
    }

    /// <summary></summary>
    protected override Object OnConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
    {
        if (Values == null)
        {
            return DefaultIndex;
        }

        for (var i = 0; i < Values.Count; i++)
        {
            if (Equals(Values[i], value))
            {
                return i;
            }
        }

        return DefaultIndex;
    }
}
