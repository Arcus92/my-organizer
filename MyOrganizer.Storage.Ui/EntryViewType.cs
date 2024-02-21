namespace MyOrganizer.Storage.Ui;

/// <summary>
/// Describes the view type for an entry. Used when a view for an entry is requested.
/// </summary>
public enum EntryViewType
{
    /// <summary>
    /// The view used in the entry list. Displays an small icon, a name and an optional subtitle.
    /// </summary>
    Item,
    
    /// <summary>
    /// The view used in the main area when the entry is selected.
    /// </summary>
    Detail,
    
    /// <summary>
    /// The view used in the main area when the entry is selected and edit-mode is enabled.
    /// </summary>
    Editor,
}