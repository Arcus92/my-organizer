namespace MyOrganizer.Storage.Sources;

/// <summary>
/// A implementation of <see cref="IVaultSource"/> to load a demo-vault.
/// </summary>
public class VaultDemoSource : IVaultSource
{
    /// <inheritdoc />
    public string Name => "Demo";

    /// <inheritdoc />
    public bool IsEncrypted => false;
    
    /// <inheritdoc />
    public Task<Vault> LoadAsync(VaultLoadOptions options)
    {
        var vault = new Vault();

        if (options.StorageService.TryCreateEntry("organizer.password", out var entry))
        {
            entry.Name = "My password";
            vault.Entries.Add(entry);
        }
        
        if (options.StorageService.TryCreateEntry("organizer.note", out entry))
        {
            entry.Name = "My note";
            vault.Entries.Add(entry);
        }
        
        return Task.FromResult(vault);
    }
}