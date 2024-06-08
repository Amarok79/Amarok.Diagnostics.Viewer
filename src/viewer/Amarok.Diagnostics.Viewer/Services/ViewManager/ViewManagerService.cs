// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Windows.Controls;
using Amarok.Events;


namespace Amarok.Services.ViewManager;


internal sealed class ViewManagerService : IViewManager
{
    private readonly EventSource<Page> mPageChangedSource = new();
    
    
    public Event<Page> PageChanged => mPageChangedSource.Event;
    
    
    public async Task GoToPage(Page page)
    {
        await mPageChangedSource.InvokeAsync(page);
    }
}
