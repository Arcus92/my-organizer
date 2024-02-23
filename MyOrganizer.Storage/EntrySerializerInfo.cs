namespace MyOrganizer.Storage;

/// <summary>
/// The serializer info for an <see cref="Entry"/> is used to find the correct serializer / deserializer.
/// </summary>
public struct EntrySerializerInfo
{
    /// <summary>
    /// Gets and sets the <see cref="IEntryController.Identifier"/> for this entry type.
    /// </summary>
    public string Identifier { get; set; }
    
    /// <summary>
    /// Gets and sets the data version. Can be used when serializing / deserializing the data from an older vault.
    /// </summary>
    public int Version { get; set; }
}