using MyOrganizer.Common;
using MyOrganizer.Storage.Ui.View;

namespace MyOrganizer.Storage.Ui.ViewModel;

/// <summary>
/// The view model for the generic <see cref="EntryItemView"/>.
/// </summary>
public class EntryItemViewModel : ViewModelBase<EntryItemView>, IEntryViewModel
{
    /// <inheritdoc />
    public EntryItemViewModel(Entry entry)
    {
        Entry = entry;
    }
    
    /// <inheritdoc />
    public Entry Entry { get; }

    /// <summary>
    /// Gets the name of the entry.
    /// </summary>
    public string DisplayName => Entry.Name;
}