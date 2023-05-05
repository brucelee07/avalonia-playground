using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Apps.Atlas.Gui.Views;

public partial class FirstPageView : UserControl
{
    public FirstPageView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}