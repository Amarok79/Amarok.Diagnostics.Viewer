// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

#pragma warning disable IDE1006


using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;


namespace Amarok.Views.Charts;


public partial class ChartsPageVm : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ChartVm> charts = [ Ioc.Default.GetRequiredService<ChartVm>() ];
}
