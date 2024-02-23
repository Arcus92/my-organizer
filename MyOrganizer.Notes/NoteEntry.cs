using MyOrganizer.Storage;

namespace MyOrganizer.Notes;

/// <summary>
/// An entry for a note.
/// </summary>
public class NoteEntry : Entry
{
    /// <summary>
    /// Gets and sets the notes content.
    /// </summary>
    public string Content { get; set; } = "";
}