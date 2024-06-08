// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.DataSource;


namespace Amarok.Services.DataSourceManager;


internal sealed class DataSourceManagerService : IDataSourceManager
{
    private readonly IEnumerable<IDataSourceFactory> mDataSourceFactories;
    
    
    public IDataSource? DataSource { get; set; }
    
    
    public DataSourceManagerService(IEnumerable<IDataSourceFactory> dataSourceFactories)
    {
        mDataSourceFactories = dataSourceFactories;
    }
    
    
    public async Task<Boolean> LoadFile(String filePath)
    {
        IDataSourceFactory? factory = null;
        
        foreach (var candidate in mDataSourceFactories)
        {
            if (await candidate.CanLoadAsync(filePath))
            {
                factory = candidate;
                
                break;
            }
        }
        
        if (factory != null)
        {
            var dataSource = await factory.LoadAsync(filePath);
            
            DataSource = dataSource;
            
            return true;
        }
        
        return false;
    }
}
