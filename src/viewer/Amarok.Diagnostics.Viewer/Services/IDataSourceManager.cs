// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.DataSource;


namespace Amarok.Services;


public interface IDataSourceManager
{
    IDataSource? DataSource { get; set; }
    
    
    Task<Boolean> LoadFile(String filePath);
}
