// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Windows.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;


namespace Amarok.Fabric;


[MarkupExtensionReturnType(typeof(Object))]
public sealed class GetServiceExtension : MarkupExtension
{
    private readonly Type mType;


    public GetServiceExtension(Type type)
    {
        mType = type;
    }


    public override Object ProvideValue(IServiceProvider serviceProvider)
    {
        return Ioc.Default.GetService(mType);
    }
}
