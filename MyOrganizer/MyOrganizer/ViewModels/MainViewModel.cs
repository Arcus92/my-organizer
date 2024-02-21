using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Threading.Tasks;
using MyOrganizer.Common;
using MyOrganizer.Notes;
using MyOrganizer.Notes.Ui;
using MyOrganizer.Passwords;
using MyOrganizer.Passwords.Ui;
using MyOrganizer.Storage;
using MyOrganizer.Storage.Sources;
using MyOrganizer.Storage.Ui;
using MyOrganizer.Storage.Ui.ViewModel;
using MyOrganizer.Views;
using ReactiveUI;

namespace MyOrganizer.ViewModels;

public class MainViewModel : ViewModelBase<MainView>
{
    private readonly StorageService _storageService;
    
    public MainViewModel()
    {
        _storageService = new StorageService();
        _storageService.RegisterController<NoteEntryUiController>();
        _storageService.RegisterController<PasswordEntryUiController>();

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
        
        EntryViewModels = new ObservableCollection<IEntryViewModel>();
        
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
                EntryViewModels.Add(viewModel);
            }
        }
    }

    public ObservableCollection<IEntryViewModel> EntryViewModels { get; }

    private IEntryViewModel? _selectedEntry;

    public IEntryViewModel? SelectedEntry
    {
        get => _selectedEntry;
        set => this.RaiseAndSetIfChanged(ref _selectedEntry, value);
    }
    

    private ViewModelBase? _mainContent;

    public ViewModelBase? MainContent
    {
        get => _mainContent;
        set => this.RaiseAndSetIfChanged(ref _mainContent, value);
    }
}