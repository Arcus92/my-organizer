using MyOrganizer.Common;
using MyOrganizer.Passwords.Ui.View;
using MyOrganizer.Storage;
using MyOrganizer.Storage.Ui.ViewModel;

namespace MyOrganizer.Passwords.Ui.ViewModel;

/// <summary>
/// The view model for <see cref="PasswordEntryDetailView"/>.
/// </summary>
public class PasswordEntryDetailViewModel : ViewModelBase<PasswordEntryDetailView>, IEntryViewModel
{
    /// <summary>
    /// Creates the entry view model.
    /// </summary>
    /// <param name="entry"></param>
    public PasswordEntryDetailViewModel(PasswordEntry entry)
    {
        Entry = entry;
    }
    
    /// <inheritdoc cref="IEntryViewModel.Entry"/>
    public PasswordEntry Entry { get; }

    /// <inheritdoc />
    Entry IEntryViewModel.Entry => Entry;
}