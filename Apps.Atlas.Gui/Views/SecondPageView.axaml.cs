using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Apps.Atlas.Gui.Views;

public partial class SecondPageView : UserControl
{
    public SecondPageView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}