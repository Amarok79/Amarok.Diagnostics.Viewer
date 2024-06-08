// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Windows.Controls;
using Amarok.Events;


namespace Amarok.Services;


public interface IViewManager
{
    Event<Page> PageChanged { get; }
    
    Task GoToPage(Page page);
}
