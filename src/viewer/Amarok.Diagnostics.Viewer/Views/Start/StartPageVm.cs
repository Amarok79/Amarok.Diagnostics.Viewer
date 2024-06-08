// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Services;
using Amarok.Views.Charts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;


namespace Amarok.Views.Start;


public partial class StartPageVm : ObservableObject
{
    private readonly IViewManager mViewManager;
    private readonly IDataSourceManager mDataSourceManager;
    
    
    public StartPageVm(IViewManager viewManager, IDataSourceManager dataSourceManager)
    {
        mViewManager       = viewManager;
        mDataSourceManager = dataSourceManager;
    }
    
    
    [RelayCommand]
    public async Task OpenFile()
    {
        var dialog = new OpenFileDialog {
            Multiselect = false,
            Filter      = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
        };
        
        if (dialog.ShowDialog(App.Current.MainWindow) == true)
        {
            if (await mDataSourceManager.LoadFile(dialog.FileName))
            {
                await mViewManager.GoToPage(new ChartsPage());
            }
        }
    }
}
