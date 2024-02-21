using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using MyOrganizer.Common;
using MyOrganizer.Notes;
using MyOrganizer.Notes.Ui;
using MyOrganizer.Passwords;
using MyOrganizer.Passwords.Ui;
using MyOrganizer.Storage;
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
        
        var vault = new Vault()
        {
            Name = "Notes",
            Entries =
            {
                new NoteEntry
                {
                    Name = "Test note #1",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    Content = "Remember"
                },
                new NoteEntry()
                {
                    Name = "Test note #2",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    Content = "Remember"
                },
                new PasswordEntry()
                {
                    Name = "Test password #1",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                }
            }
        };


        EntryViewModels = new ObservableCollection<IEntryViewModel>();
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