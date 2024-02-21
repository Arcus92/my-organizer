namespace MyOrganizer.Storage.Ui.ViewModel;

/// <summary>
/// The base interface for any <see cref="Entry"/> view-model.
/// </summary>
public interface IEntryViewModel
{
    /// <summary>
    /// Gets the referenced entry.
    /// </summary>
    Entry Entry { get; }
}