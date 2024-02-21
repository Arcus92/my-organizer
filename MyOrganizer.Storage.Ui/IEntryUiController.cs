using MyOrganizer.Storage.Ui.ViewModel;

namespace MyOrganizer.Storage.Ui;

/// <summary>
/// The interface for an entry ui controller. This separates the entry logic from the ui. It is used to create views
/// based on the entry type.
/// </summary>
public interface IEntryUiController : IEntryController
{
    /// <summary>
    /// Create the item view model for the given entry.
    /// </summary>
    /// <param name="entry">The entry.</param>
    /// <param name="viewType">The view type to create.</param>
    /// <returns>The created view model.</returns>
    IEntryViewModel? CreateViewModel(Entry entry, EntryViewType viewType);
}