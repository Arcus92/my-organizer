using System.Security;

namespace MyOrganizer.Storage.Sources;

/// <summary>
/// The options used to load a <see cref="Vault"/> from a <see cref="IVaultSource"/>.
/// </summary>
public struct VaultLoadOptions
{
    /// <summary>
    /// Creates a vault load options.
    /// </summary>
    /// <param name="storageService"></param>
    public VaultLoadOptions(StorageService storageService)
    {
        StorageService = storageService;
    }
    
    /// <summary>
    /// Gets and sets the storage service.
    /// </summary>
    public StorageService StorageService { get; init; }

    /// <summary>
    /// Gets and sets the encryption key.
    /// </summary>
    public SecureString? EncryptionKey { get; set; }
}