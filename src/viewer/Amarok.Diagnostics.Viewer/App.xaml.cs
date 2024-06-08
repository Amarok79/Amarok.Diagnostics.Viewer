// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Windows;
using Amarok.DataSource.Csv;
using Amarok.Services;
using Amarok.Services.DataSourceManager;
using Amarok.Services.ViewManager;
using Amarok.Views.Charts;
using Amarok.Views.Shell;
using Amarok.Views.Start;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Amarok;


public partial class App : Application
{
    private readonly IHost mHost;
    
    
    public new static App Current => (App)Application.Current;
    
    
    public App()
    {
        mHost = new HostBuilder().ConfigureServices(_ConfigureServices).Build();
        
        Ioc.Default.ConfigureServices(mHost.Services);
    }
    
    
    private static void _ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IViewManager, ViewManagerService>();
        services.AddSingleton<IDataSourceManager, DataSourceManagerService>();
        
        services.AddTransient<ShellWindowVm>();
        services.AddTransient<StartPageVm>();
        services.AddTransient<ChartsPageVm>();
        services.AddTransient<ChartVm>();
        
        services.WithCsvDataSource();
    }
    
    protected override void OnExit(ExitEventArgs e)
    {
        mHost.Dispose();
    }
}
