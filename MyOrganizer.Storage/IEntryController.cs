namespace MyOrganizer.Storage;

/// <summary>
/// An interface for handling different <see cref="Entry"/> types.
/// </summary>
public interface IEntryController
{
    /// <summary>
    /// Gets the type of the managed entry.
    /// </summary>
    Type EntryType { get; }

    /// <summary>
    /// Gets the identifier of the entity controller.
    /// </summary>
    string Identifier { get; }

    /// <summary>
    /// Creates a new entry from the given controller.
    /// </summary>
    /// <returns></returns>
    Entry Create();
}

/// <summary>
/// An interface for handling different <see cref="Entry"/> types.
/// </summary>
/// <typeparam name="T">The entry type.</typeparam>
public interface IEntryController<T> : IEntryController where T : Entry, new()
{
    /// <inheritdoc />
    Type IEntryController.EntryType => typeof(T);
    
    /// <inheritdoc />
    Entry IEntryController.Create() => new T();
}