// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.DataSource;


namespace Amarok.Views.Charts;


public record class Counter(String Name, IDataSeries Series)
{
    public override String ToString()
    {
        return Name;
    }
}
