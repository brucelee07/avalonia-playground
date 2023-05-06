using System;
using System.Threading.Tasks;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Apps.Atlas.Gui.ViewModels;

public partial class FirstPageViewModel: ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "First Page";

    public FirstPageViewModel()
    {
        // Dispatcher.UIThread.Post(() => LongRunningTask(), DispatcherPriority.Background);
        LongRunningTask().GetAwaiter();
        AnotherTask(9).GetAwaiter();
        AnotherTask(8).GetAwaiter();
    }
    
    async Task LongRunningTask()
    {
        while (true)
        {
           await Task.Delay(2000);
           Greeting = "start thread";
           await Task.Delay(2000);
           Greeting = "end thread";
        }
    }
    
    async Task AnotherTask(int idx)
    {
        while (true)
        {
           await Task.Delay(2000);
           Console.WriteLine($"{idx} first knock");
           await Task.Delay(2000);
           Console.WriteLine($"{idx} second knock");
        }
    }
    
}