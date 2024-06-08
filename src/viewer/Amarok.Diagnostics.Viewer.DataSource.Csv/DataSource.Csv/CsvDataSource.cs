// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using nietras.SeparatedValues;


namespace Amarok.DataSource.Csv;


internal sealed class CsvDataSource : IDataSource
{
    private readonly String mFilePath;
    
    
    public CsvDataSource(String filePath)
    {
        mFilePath = filePath;
    }
    
    
    public String Name => mFilePath;
    
    
    public async Task<IReadOnlyList<IDataSeries>> GetSeriesAsync()
    {
        await Task.Delay(0);
        
        using var reader = Sep.Reader().FromFile(mFilePath);
        
        var series = reader.Header.ColNames.Where(x => !x.Contains("Timestamp"))
            .Select(
                x => {
                    var (category, name) = split(x);
                    
                    return new CsvDataSeries {
                        FullName = x,
                        Category = category,
                        Name     = name,
                    };
                }
            )
            .ToArray();
        
        return series;
        
        
        static (String, String) split(String fullName)
        {
            var parts = fullName.Split('_');
            
            return parts.Length == 2 ? (parts[0], parts[1]) : ("Unknown", parts[0]);
        }
    }
    
    public Task<IReadOnlyList<DataPoint>> GetDataPointsAsync(IDataSeries dataSeries)
    {
        var csvSeries = (CsvDataSeries)dataSeries;
        
        
        using var reader = Sep.Reader().FromFile(mFilePath);
        
        var timestampIndex = reader.Header.IndexOf("\"Timestamp\"");
        
        var valueIndex = reader.Header.IndexOf(csvSeries.FullName);
        
        
        var values = new List<DataPoint>();
        
        foreach (var row in reader)
        {
            var timestamp = row[timestampIndex].ToString();
            var value     = row[valueIndex].ToString();
            
            if (!String.IsNullOrEmpty(timestamp) && !String.IsNullOrEmpty(value))
            {
                var dt = DateTime.Parse(timestamp).ToUniversalTime();
                dt = new DateTime(dt.Ticks, DateTimeKind.Local);
                
                values.Add(new DataPoint(dt, String.IsNullOrWhiteSpace(value) ? 0.0 : Double.Parse(value)));
            }
        }
        
        return Task.FromResult<IReadOnlyList<DataPoint>>(values);
    }
}
