// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace Amarok.DataSource.Csv;


internal sealed class CsvDataSourceFactory : IDataSourceFactory
{
    public Task<Boolean> CanLoadAsync(String filePath)
    {
        var result = filePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase);
        
        return Task.FromResult(result);
    }
    
    public Task<IDataSource> LoadAsync(String filePath)
    {
        var source = new CsvDataSource(filePath);
        
        return Task.FromResult<IDataSource>(source);
    }
}
