using MyOrganizer.Common;
using MyOrganizer.Notes.Ui.View;
using MyOrganizer.Storage;
using MyOrganizer.Storage.Ui.ViewModel;

namespace MyOrganizer.Notes.Ui.ViewModel;

/// <summary>
/// The view model for <see cref="NoteEntryDetailView"/>.
/// </summary>
public class NoteEntryDetailViewModel : ViewModelBase<NoteEntryDetailView>, IEntryViewModel
{
    /// <summary>
    /// Creates the entry view model.
    /// </summary>
    /// <param name="entry"></param>
    public NoteEntryDetailViewModel(NoteEntry entry)
    {
        Entry = entry;
    }
    
    /// <inheritdoc cref="IEntryViewModel.Entry"/>
    public NoteEntry Entry { get; }

    /// <inheritdoc />
    Entry IEntryViewModel.Entry => Entry;

    /// <summary>
    /// Gets the notes content.
    /// </summary>
    public string Content => Entry.Content;
}