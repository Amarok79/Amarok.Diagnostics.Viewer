// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace Amarok.Fabric;


/// <summary>
///     This type provides a base class for custom value converter implementations. This base class is
///     appropriate for state-full value converters, which require a distinct instance per binding.
/// </summary>
public abstract class ValueConverter<TFrom, TTo, TParameter> : IValueConverter
{
    #region ++ Public Interface ++

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
