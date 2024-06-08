// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Windows.Controls;


namespace Amarok.Views.Charts;


public partial class Chart : UserControl
{
    public Chart()
    {
        InitializeComponent();
        
        DataContextChanged += (_, _) => ((ChartVm)DataContext).Diagram = Diagram;
    }
}
