namespace MyOrganizer.Storage;

/// <summary>
/// A vault contains entities.
/// </summary>
public class Vault
{
    /// <summary>
    /// Gets the list of entries.
    /// </summary>
    public List<Entry> Entries { get; } = [];
}