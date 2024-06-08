// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace Amarok.DataSource;


/// <summary>
///     Represents a data source.
/// </summary>
public interface IDataSource
{
    /// <summary>
    ///     The name of the data source, e.g. the file name.
    /// </summary>
    String Name { get; }
    
    /// <summary>
    ///     Gets a list of data series that the data source provides.
    /// </summary>
    Task<IReadOnlyList<IDataSeries>> GetSeriesAsync();
    
    /// <summary>
    ///     Gets the data points for a single data series.
    /// </summary>
    Task<IReadOnlyList<DataPoint>> GetDataPointsAsync(IDataSeries dataSeries);
}
