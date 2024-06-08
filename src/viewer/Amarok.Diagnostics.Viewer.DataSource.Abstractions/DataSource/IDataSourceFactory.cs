// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace Amarok.DataSource;


/// <summary>
///     Represents a factory of a specific kind of data source.
/// </summary>
public interface IDataSourceFactory
{
    /// <summary>
    ///     Determines whether the data source can load the given file.
    /// </summary>
    /// <returns></returns>
    Task<Boolean> CanLoadAsync(String filePath);
    
    /// <summary>
    ///     Returns a data source for the given file.
    /// </summary>
    Task<IDataSource> LoadAsync(String filePath);
}
