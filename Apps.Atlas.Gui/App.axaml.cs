using Apps.Atlas.Gui.Data;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Apps.Atlas.Gui.ViewModels;
using Apps.Atlas.Gui.Views;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Apps.Atlas.Gui;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };

        }

        base.OnFrameworkInitializationCompleted();

        DatabaseFacade facade = new DatabaseFacade(new AtlasContext());
        facade.EnsureCreated();
    }
}