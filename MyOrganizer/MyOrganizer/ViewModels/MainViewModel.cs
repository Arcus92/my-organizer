using System;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;
using MyOrganizer.Common;
using MyOrganizer.Storage;
using MyOrganizer.Storage.Sources;
using MyOrganizer.Storage.Ui;
using MyOrganizer.Storage.Ui.ViewModel;
using MyOrganizer.Views;
using ReactiveUI;
using Splat;

namespace MyOrganizer.ViewModels;

/// <summary>
/// The view model for <see cref="MainView"/>. This hosts the entire applications content.
/// </summary>
public class MainViewModel : ViewModelBase<MainView>
{
    private readonly StorageService _storageService;
    
    /// <summary>
    /// Create the main view model.
    /// </summary>
    public MainViewModel()
    {
        _storageService = Locator.Current.GetRequiredService<StorageService>();

        this.WhenAnyValue(x => x.SelectedEntry)
            .Subscribe(viewModel =>
            {
                if (viewModel is null)
                {
                    MainContent = null;
                    return;
                }
                
                if (_storageService.TryCreateEntryViewModel(viewModel.Entry, EntryViewType.Detail, out var detailViewModel))
                {
                    MainContent = detailViewModel as ViewModelBase;
                }
                
            });
        
        Entries = new ObservableCollection<IEntryViewModel>();
        
        RxApp.MainThreadScheduler.Schedule(LoadVaults);
    }
    
    private async void LoadVaults()
    {
        var vaultSource = new VaultDemoSource();
        var options = new VaultLoadOptions(_storageService);
        var vault = await vaultSource.LoadAsync(options);
        foreach (var entry in vault.Entries)
        {
            if (_storageService.TryCreateEntryViewModel(entry, EntryViewType.Item, out var viewModel))
            {
                Entries.Add(viewModel);
            }
        }
    }

    /// <summary>
    /// Gets the list of entries.
    /// </summary>
    public ObservableCollection<IEntryViewModel> Entries { get; }

    private IEntryViewModel? _selectedEntry;

    /// <summary>
    /// Gets and sets the selected entry.
    /// </summary>
    public IEntryViewModel? SelectedEntry
    {
        get => _selectedEntry;
        set => this.RaiseAndSetIfChanged(ref _selectedEntry, value);
    }
    

    private ViewModelBase? _mainContent;

    /// <summary>
    /// Gets the main content view model to display.
    /// </summary>
    public ViewModelBase? MainContent
    {
        get => _mainContent;
        private set => this.RaiseAndSetIfChanged(ref _mainContent, value);
    }
}