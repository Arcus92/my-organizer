namespace MyOrganizer.Storage;

/// <summary>
/// An interface for handling different <see cref="Entry"/> types.
/// </summary>
public interface IEntryController
{
    /// <summary>
    /// Gets the identifier of the entity controller.
    /// </summary>
    string Identifier { get; }
}