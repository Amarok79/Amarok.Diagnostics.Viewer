// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Microsoft.Extensions.DependencyInjection;


namespace Amarok.DataSource.Csv;


public static class CsvDataSourceServiceCollectionExtensions
{
    public static IServiceCollection WithCsvDataSource(this IServiceCollection services)
    {
        services.AddSingleton<IDataSourceFactory, CsvDataSourceFactory>();
        
        return services;
    }
}
