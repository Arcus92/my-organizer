using Avalonia.ReactiveUI;
using MyOrganizer.Storage.Ui.ViewModel;

namespace MyOrganizer.Storage.Ui.View;

/// <summary>
/// A generic entry view. Can be overwritten by implementing your own <see cref="IEntryUiController"/>.
/// </summary>
public partial class EntryItemView : ReactiveUserControl<EntryItemViewModel>
{
    /// <inheritdoc />
    public EntryItemView()
    {
        InitializeComponent();
    }
}