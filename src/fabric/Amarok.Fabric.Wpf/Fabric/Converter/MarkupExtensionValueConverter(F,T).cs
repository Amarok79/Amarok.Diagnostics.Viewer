// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace Amarok.Fabric;


/// <summary>
///     This type provides a base class for custom value converter implementations that can be used as
///     XAML markup extensions. This base class is only appropriate for state-less value converters,
///     which can be shared in multiple bindings at the same time.
/// </summary>
public abstract class MarkupExtensionValueConverter<TThis, TFrom, TTo> :
    MarkupExtensionValueConverter<TThis, TFrom, TTo, Object>
    where TThis : class, new()
{
}
