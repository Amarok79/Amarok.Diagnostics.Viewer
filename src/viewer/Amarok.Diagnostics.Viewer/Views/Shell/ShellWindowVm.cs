// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

#pragma warning disable IDE1006

using System.IO;
using System.Windows.Controls;
using Amarok.Services;
using Amarok.Views.Charts;
using Amarok.Views.Start;
using CommunityToolkit.Mvvm.ComponentModel;


namespace Amarok.Views.Shell;


public partial class ShellWindowVm : ObservableObject
{
    private readonly IViewManager mViewManager;
    private readonly IDataSourceManager mDataSourceManager;
    
    [ObservableProperty]
    private Page? _CurrentPage;
    
    
    public ShellWindowVm(IViewManager viewManager, IDataSourceManager dataSourceManager)
    {
        mViewManager       = viewManager;
        mDataSourceManager = dataSourceManager;
        viewManager.PageChanged.Subscribe(_HandlePageChanged);
        
        _ = _LoadFile();
    }
    
    
    private async Task _LoadFile()
    {
        var args = Environment.GetCommandLineArgs();
        
        if (args.Length > 1)
        {
            var filePath = args[1];
            
            if (File.Exists(filePath))
            {
                await mDataSourceManager.LoadFile(filePath);
                
                await mViewManager.GoToPage(new ChartsPage());
                
                return;
            }
        }
        
        await mViewManager.GoToPage(new StartPage());
    }
    
    
    private void _HandlePageChanged(Page page)
    {
        CurrentPage = page;
    }
}
