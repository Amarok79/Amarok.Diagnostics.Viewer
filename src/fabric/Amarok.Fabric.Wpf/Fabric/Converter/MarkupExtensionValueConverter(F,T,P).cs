﻿// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;


namespace Amarok.Fabric;


/// <summary>
///     This type provides a base class for custom value converter implementations that can be used as
///     XAML markup extensions. This base class is only appropriate for state-less value converters,
///     which can be shared in multiple bindings at the same time.
/// </summary>
public abstract class MarkupExtensionValueConverter<TThis, TFrom, TTo, TParameter> : MarkupExtension,
    IValueConverter
    where TThis : class, new()
{
    // static data
    private static TThis sSingleton;


    #region ++ Public Static Interface ++

    /// <summary>
    ///     Gets a reference to the singleton instance of this value converter.
    /// </summary>
    public static TThis Instance
    {
        get
        {
            if (sSingleton == null)
            {
                sSingleton = new TThis();
            }

            return sSingleton;
        }
    }

    #endregion

    #region ++ Public Interface ++

    /// <summary>
    ///     Returns an object that is provided as the value of the target property for this markup
    ///     extension.
    /// </summary>
    /// <param name="serviceProvider">
    ///     A service provider helper that can provide services for the markup extension.
    /// </param>
    /// <returns>
    ///     The object value to set on the property where the extension is applied.
    /// </returns>
    public sealed override Object ProvideValue(IServiceProvider serviceProvider)
    {
        return Instance;
    }


    /// <summary>
    ///     The data binding engine calls this method when it propagates a value from the binding source to
    ///     the binding target.
    /// </summary>
    /// <param name="value">
    ///     The value produced by the binding source.
    /// </param>
    /// <param name="targetType">
    ///     The type of the binding target property.
    /// </param>
    /// <param name="parameter">
    ///     The converter parameter to use.
    /// </param>
    /// <param name="culture">
    ///     The culture to use in the converter.
    /// </param>
    /// <returns>
    ///     A converted value. If the method returns null, the valid null value is used. A return value of
    ///     DependencyProperty.UnsetValue indicates that the converter produced no value and that the
    ///     binding uses the FallbackValue, if available, or the default value instead. A return value of
    ///     Binding.DoNothing indicates that the binding does not transfer the value and does not use the
    ///     FallbackValue or the default value. In case of casting exceptions the original value is
    ///     returned.
    /// </returns>
    public virtual Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
    {
        var castsSuccessful = false;

        try
        {
            var castValue     = (TFrom)value;
            var castParameter = (TParameter)parameter;

            castsSuccessful = true;

            return OnConvert(
                castValue,
                targetType,
                castParameter,
                culture
            );
        }
        catch (Exception)
        {
            if (castsSuccessful == false)
            {
                return value;
            }

            throw;
        }
    }

    /// <summary>
    ///     The data binding engine calls this method when it propagates a value from the binding target to
    ///     the binding source.
    /// </summary>
    /// <param name="value">
    ///     The value that is produced by the binding target.
    /// </param>
    /// <param name="targetType">
    ///     The type to convert to.
    /// </param>
    /// <param name="parameter">
    ///     The converter parameter to use.
    /// </param>
    /// <param name="culture">
    ///     The culture to use in the converter.
    /// </param>
    /// <returns>
    ///     A converted value. If the method returns null, the valid null value is used. A return value of
    ///     DependencyProperty.UnsetValue indicates that the converter produced no value and that the
    ///     binding uses the FallbackValue, if available, or the default value instead. A return value of
    ///     Binding.DoNothing indicates that the binding does not transfer the value and does not use the
    ///     FallbackValue or the default value. In case of casting exceptions the original value is
    ///     returned.
    /// </returns>
    public virtual Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
    {
        var castsSuccessful = false;

        try
        {
            var castValue     = (TTo)value;
            var castParameter = (TParameter)parameter;

            castsSuccessful = true;

            return OnConvertBack(
                castValue,
                targetType,
                castParameter,
                culture
            );
        }
        catch (Exception)
        {
            if (castsSuccessful == false)
            {
                return value;
            }

            throw;
        }
    }

    #endregion

    #region ## Overridable Methods ##

    /// <summary>
    ///     The data binding engine calls this method when it propagates a value from the binding source to
    ///     the binding target.
    /// </summary>
    /// <param name="value">
    ///     The value produced by the binding source.
    /// </param>
    /// <param name="targetType">
    ///     The type of the binding target property.
    /// </param>
    /// <param name="parameter">
    ///     The converter parameter to use.
    /// </param>
    /// <param name="culture">
    ///     The culture to use in the converter.
    /// </param>
    /// <returns>
    ///     A converted value. If the method returns null, the valid null value is used. A return value of
    ///     DependencyProperty.UnsetValue indicates that the converter produced no value and that the
    ///     binding uses the FallbackValue, if available, or the default value instead. A return value of
    ///     Binding.DoNothing indicates that the binding does not transfer the value and does not use the
    ///     FallbackValue or the default value.
    /// </returns>
    protected virtual Object OnConvert(TFrom value, Type targetType, TParameter parameter, CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }

    /// <summary>
    ///     The data binding engine calls this method when it propagates a value from the binding target to
    ///     the binding source.
    /// </summary>
    /// <param name="value">
    ///     The value that is produced by the binding target.
    /// </param>
    /// <param name="targetType">
    ///     The type to convert to.
    /// </param>
    /// <param name="parameter">
    ///     The converter parameter to use.
    /// </param>
    /// <param name="culture">
    ///     The culture to use in the converter.
    /// </param>
    /// <returns>
    ///     A converted value. If the method returns null, the valid null value is used. A return value of
    ///     DependencyProperty.UnsetValue indicates that the converter produced no value and that the
    ///     binding uses the FallbackValue, if available, or the default value instead. A return value of
    ///     Binding.DoNothing indicates that the binding does not transfer the value and does not use the
    ///     FallbackValue or the default value.
    /// </returns>
    protected virtual Object OnConvertBack(TTo value, Type targetType, TParameter parameter, CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }

    #endregion
}
