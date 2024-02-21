namespace MyOrganizer.Storage;

/// <summary>
/// A vault contains entities.
/// </summary>
public class Vault
{
    /// <summary>
    /// Gets and sets the name of the vault.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Gets the list of loaded entries.
    /// </summary>
    public List<Entry> Entries { get; } = [];
}