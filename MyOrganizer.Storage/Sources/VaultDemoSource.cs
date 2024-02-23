namespace MyOrganizer.Storage.Sources;

/// <summary>
/// A implementation of <see cref="IVaultSource"/> to load a demo-vault.
/// </summary>
public class VaultDemoSource : IVaultSource
{
    /// <inheritdoc />
    public Guid Id => new("9ad87240-0c2a-46d9-b1c7-d77cc1617974");
    
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
            entry.CreatedAt = DateTime.Now;
            entry.ModifiedAt = DateTime.Now;
            vault.Entries.Add(entry);
        }
        
        if (options.StorageService.TryCreateEntry("organizer.note", out entry))
        {
            entry.Name = "My note";
            entry.CreatedAt = DateTime.Now;
            entry.ModifiedAt = DateTime.Now;
            vault.Entries.Add(entry);
        }
        
        return Task.FromResult(vault);
    }
}