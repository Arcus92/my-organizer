using MyOrganizer.Notes.Ui.ViewModel;
using MyOrganizer.Storage;
using MyOrganizer.Storage.Ui;
using MyOrganizer.Storage.Ui.ViewModel;

namespace MyOrganizer.Notes.Ui;

/// <summary>
/// The ui controller for <see cref="NoteEntry"/>.
/// </summary>
public class NoteEntryUiController : NoteEntryController, IEntryUiController
{
    /// <inheritdoc />
    public IEntryViewModel? CreateViewModel(Entry entry, EntryViewType viewType)
    {
        if (entry is not NoteEntry noteEntry)
            return null;
        
        return viewType switch
        {
            EntryViewType.Item => new EntryItemViewModel(entry),
            EntryViewType.Detail => new NoteEntryDetailViewModel(noteEntry),
            _ => (IEntryViewModel?)null
        };
    }
}