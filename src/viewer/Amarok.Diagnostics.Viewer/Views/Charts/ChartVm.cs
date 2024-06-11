// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

#pragma warning disable IDE1006

using System.Collections.ObjectModel;
using System.Windows;
using Amarok.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScottPlot;
using ScottPlot.TickGenerators;
using ScottPlot.WPF;


namespace Amarok.Views.Charts;


public partial class ChartVm : ObservableObject
{
    private readonly IDataSourceManager mDataSourceManager;
    
    
    [ObservableProperty]
    private WpfPlot _Diagram = null!;
    
    [ObservableProperty]
    private Boolean _IsLoading = true;
    
    [ObservableProperty]
    private ObservableCollection<Counter> _Counters = new();
    
    [ObservableProperty]
    private Counter? _SelectedCounter;
    
    [ObservableProperty]
    private String _CurrentValue = String.Empty;
    
    
    
    public ChartVm(IDataSourceManager dataSourceManager)
    {
        mDataSourceManager = dataSourceManager;
        
        _ = _LoadData();
    }
    
    
    partial void OnDiagramChanged(WpfPlot value)
    {
        Diagram.Plot.Style.DarkMode();
        Diagram.Plot.FigureBackground.Color = Color.FromHex("#2b2b2b");
        Diagram.Plot.ScaleFactor            = Diagram.DisplayScale;
        Diagram.Refresh();
        
        Diagram.MouseMove += (_, args) => _HandleMouseMove(args.GetPosition(Diagram));
    }
    
    private void _HandleMouseMove(Point position)
    {
        if (IsLoading || SelectedCounter == null)
        {
            return;
        }
        
        var px = new Pixel(position.X * Diagram.DisplayScale, position.Y * Diagram.DisplayScale);
        var xy = Diagram.Plot.GetCoordinates(px);
        
        var dt = DateTime.FromOADate(xy.X);
        
        CurrentValue = $"{NumericAutomatic.DefaultLabelFormatter(xy.Y)} @ {dt:D} {dt:T}";
    }
    
    
    private async Task _LoadData()
    {
        IsLoading = true;
        
        var series = await mDataSourceManager.DataSource!.GetSeriesAsync();
        
        Counters = new ObservableCollection<Counter>(
            series.Select(x => new Counter($"{x.Category}  ―  {x.Name}", x)).OrderBy(x => x.Name)
        );
        
        IsLoading = false;
    }
    
    async partial void OnSelectedCounterChanged(Counter? value)
    {
        if (value == null)
        {
            return;
        }
        
        
        IsLoading = true;
        
        var dataPoints = await mDataSourceManager.DataSource!.GetDataPointsAsync(value.Series);
        
        Diagram.Plot.Clear();
        
        var xs = dataPoints.Select(x => x.Timestamp).ToArray();
        var ys = dataPoints.Select(x => x.Value).ToArray();
        
        var scatter = Diagram.Plot.Add.SignalXY(xs, ys);
        
        scatter.LineWidth    = 1.0f;
        scatter.ConnectStyle = ConnectStyle.Straight;
        scatter.MarkerShape  = MarkerShape.None;
        
        Diagram.Plot.Axes.DateTimeTicksBottom();
        
        Diagram.Plot.Style.DarkMode();
        Diagram.Plot.FigureBackground.Color = Color.FromHex("#2b2b2b");
        
        Diagram.Refresh();
        
        IsLoading = false;
    }
    
    
    [RelayCommand]
    public void ResetZoom()
    {
        Diagram.Plot.Axes.AutoScale();
        Diagram.Refresh();
    }
}
