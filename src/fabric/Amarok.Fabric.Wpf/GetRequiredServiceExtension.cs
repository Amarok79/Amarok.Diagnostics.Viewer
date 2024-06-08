// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Windows.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;


namespace Amarok.Fabric;


[MarkupExtensionReturnType(typeof(Object))]
public sealed class GetRequiredServiceExtension : MarkupExtension
{
    private readonly Type mType;


    public GetRequiredServiceExtension(Type type)
    {
        mType = type;
    }


    public override Object ProvideValue(IServiceProvider serviceProvider)
    {
        return Ioc.Default.GetRequiredService(mType);
    }
}
