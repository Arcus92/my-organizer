namespace MyOrganizer.Storage;

/// <summary>
/// A generic entry for the organizer. It holds data for different elements.
/// </summary>
public abstract class Entry
{
    /// <summary>
    /// Gets and sets the id of the entry.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();
    
    /// <summary>
    /// Gets and sets the name of the entry
    /// </summary>
    public string Name { get; set; } = "";
    
    /// <summary>
    /// Gets and sets the path, without final name and separated by slashes "/".
    /// </summary>
    public string Path { get; set; } = "";

    /// <summary>
    /// Gets and sets the date the entry was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets and Sets the last date the entry was modified.
    /// </summary>
    public DateTime ModifiedAt { get; set; }
}