﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Apps.Atlas.Gui.Data;
using Apps.Atlas.Gui.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace Apps.Atlas.Gui.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{

    private ViewModelBase _firstView = new FirstPageViewModel();
    private ViewModelBase _secondView = new SecondPageViewModel();
    
    public MainWindowViewModel()
    {
        CurrentPage = _firstView;

        // using (AtlasContext context = new AtlasContext())
        // {
        //     int id = 3;
        //     string name = "third entry";
        //     context.Products.Add(new Product() { ProductId = id, Name = name});
        //     context.SaveChanges();
        // }
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ToFirstPageCommand))]
    [NotifyCanExecuteChangedFor(nameof(ToSecondPageCommand))]
    private ViewModelBase _currentPage;
    
    [RelayCommand(CanExecute = nameof(CanToFirstPage))]
    private void ToFirstPage()
    {
        CurrentPage = _firstView;
    }
    
    
    [RelayCommand(CanExecute = nameof(CanToSecondPage))]
    private void ToSecondPage()
    {
        CurrentPage = _secondView;
        
        using (AtlasContext context = new AtlasContext())
        {
            var products = context.Products.ToList();
            Console.WriteLine(products[0].Name);
        }
        
        // Dispatcher.UIThread.Post(() => LongRunningTask(), DispatcherPriority.Background);
    }

    
    [RelayCommand]
    private async Task GetFilePath()
    {
        var dlg = new OpenFileDialog();
        
        dlg.AllowMultiple = true;
        dlg.Filters!.Add(new FileDialogFilter() { Name = "WAV Files", Extensions = { "wav" } });
        dlg.Filters.Add(new FileDialogFilter() { Name = "All Files", Extensions = { "*" } }); 

        if (Application.Current!.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var result = await dlg.ShowAsync(desktop.MainWindow);
            if(result != null)
                Console.WriteLine(result[0]);
        }
    }

    private bool CanToSecondPage()
    {
        return CurrentPage is not SecondPageViewModel;
    }
    
    private bool CanToFirstPage()
    {
        return CurrentPage is not FirstPageViewModel;
    }

    private void update(int id)
    {
        
        using (AtlasContext context = new AtlasContext())
        {
            Product product = context.Products.Find(id);
            product.Name = "New Name";
            context.SaveChanges();
        }
        
    }
    
    private void delete(int id)
    {
        
        using (AtlasContext context = new AtlasContext())
        {
            Product product = context.Products.Find(id);
            context.Remove(product);
            context.SaveChanges();
        }
        
    }

    async Task LongRunningTask()
    {
       // update properties 
       Console.WriteLine("start task");
       await Task.Delay(1000);
       Console.WriteLine("end task");
    }
    
    
    
    
    
}