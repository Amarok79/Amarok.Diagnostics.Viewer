// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace Amarok.DataSource;


/// <summary>
///     Represents a data series.
/// </summary>
public interface IDataSeries
{
    /// <summary>
    ///     The category the data series belong to, e.g. ".NET CLR Memory".
    /// </summary>
    String Category { get; }
    
    /// <summary>
    ///     The name of the data series, e.g. "# Gen 0 Collections".
    /// </summary>
    String Name { get; }
}
