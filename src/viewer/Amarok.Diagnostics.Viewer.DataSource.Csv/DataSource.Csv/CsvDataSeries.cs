// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace Amarok.DataSource.Csv;


internal sealed class CsvDataSeries : IDataSeries
{
    public required String FullName { get; set; }
    
    public required String Category { get; set; }
    
    public required String Name { get; set; }
}
