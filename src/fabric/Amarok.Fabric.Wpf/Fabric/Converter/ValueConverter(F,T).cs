// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace Amarok.Fabric;


/// <summary>
///     This type provides a base class for custom value converter implementations. This base class is
///     appropriate for state-full value converters, which require a distinct instance per binding.
/// </summary>
public abstract class ValueConverter<TFrom, TTo> : ValueConverter<TFrom, TTo, Object>
{
}
