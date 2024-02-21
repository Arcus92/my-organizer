using MyOrganizer.Passwords.Ui.ViewModel;
using MyOrganizer.Storage;
using MyOrganizer.Storage.Ui;
using MyOrganizer.Storage.Ui.ViewModel;

namespace MyOrganizer.Passwords.Ui;

/// <summary>
/// The ui controller for <see cref="PasswordEntry"/>.
/// </summary>
public class PasswordEntryUiController : PasswordEntryController, IEntryUiController
{
    /// <inheritdoc />
    public IEntryViewModel? CreateViewModel(Entry entry, EntryViewType viewType)
    {
        if (entry is not PasswordEntry passwordEntry)
            return null;
        
        return viewType switch
        {
            EntryViewType.Item => new EntryItemViewModel(entry),
            EntryViewType.Detail => new PasswordEntryDetailViewModel(passwordEntry),
            _ => (IEntryViewModel?)null
        };
    }
}