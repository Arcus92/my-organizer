using Avalonia.ReactiveUI;
using MyOrganizer.Notes.Ui.ViewModel;

namespace MyOrganizer.Notes.Ui.View;

/// <summary>
/// The detail view for an <see cref="NoteEntry"/>.
/// </summary>
public partial class NoteEntryDetailView : ReactiveUserControl<NoteEntryDetailViewModel>
{
    /// <inheritdoc />
    public NoteEntryDetailView()
    {
        InitializeComponent();
    }
}