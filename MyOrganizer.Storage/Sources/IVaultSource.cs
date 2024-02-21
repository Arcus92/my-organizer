namespace MyOrganizer.Storage.Sources;

/// <summary>
/// The interface to load a <see cref="Vault"/>.
/// </summary>
public interface IVaultSource
{
    /// <summary>
    /// Gets the name of the vault.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets if this vault is encrypted.
    /// </summary>
    bool IsEncrypted { get; }

    /// <summary>
    /// Loads and returns the vault.
    /// </summary>
    /// <param name="options">The vault options.</param>
    /// <returns>The loaded vault.</returns>
    Task<Vault> LoadAsync(VaultLoadOptions options);
}