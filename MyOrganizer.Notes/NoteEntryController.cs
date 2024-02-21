using MyOrganizer.Storage;

namespace MyOrganizer.Notes;

/// <summary>
/// The controller for <see cref="NoteEntry"/>.
/// </summary>
public class NoteEntryController : IEntryController
{
    /// <inheritdoc />
    string IEntryController.Identifier => Identifier;
    
    /// <inheritdoc cref="IEntryController.Identifier"/>
    public static string Identifier => "organizer.note";
}