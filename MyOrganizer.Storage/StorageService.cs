using System.Diagnostics.CodeAnalysis;

namespace MyOrganizer.Storage;

/// <summary>
/// A service to manage loaded storage container.
/// </summary>
public class StorageService
{
    #region Entry

    /// <summary>
    /// Creates a new entry for the given type.
    /// </summary>
    /// <param name="entryType">The entity type of the controller.</param>
    /// <param name="entry">Returns the entry.</param>
    /// <returns>Returns if the controller was found and the entry was created.</returns>
    public bool TryCreateEntry(Type entryType, [MaybeNullWhen(false)] out Entry entry)
    {
        if (!TryGetEntityController(entryType, out var controller))
        {
            entry = null;
            return false;
        }

        entry = controller.Create();
        return true;
    }
    
    /// <summary>
    /// Creates a new entry for the given type.
    /// </summary>
    /// <param name="entry">Returns the entry.</param>
    /// <typeparam name="T">The entity type of the controller</typeparam>
    /// <returns>Returns if the controller was found and the entry was created.</returns>
    public bool TryCreateEntry<T>([MaybeNullWhen(false)] out Entry entry) where T : Entry
    {
        return TryCreateEntry(typeof(T), out entry);
    }
    
    /// <summary>
    /// Creates a new entry for the given identifier.
    /// </summary>
    /// <param name="identifier">The identifier of the entity controller.</param>
    /// <param name="entry">Returns the entry.</param>
    /// <returns>Returns if the controller was found and the entry was created.</returns>
    public bool TryCreateEntry(string identifier, [MaybeNullWhen(false)] out Entry entry)
    {
        if (!TryGetEntityController(identifier, out var controller))
        {
            entry = null;
            return false;
        }

        entry = controller.Create();
        return true;
    }
    
    #endregion Entry
    
    #region Controllers

    /// <summary>
    /// A map of all registered entity controller byte entity type.
    /// </summary>
    private readonly Dictionary<Type, IEntryController> _typeToController = new();
    
    /// <summary>
    /// A map of all registered entity controller by controller identifier.
    /// </summary>
    private readonly Dictionary<string, IEntryController> _identifierToController = new();

    /// <summary>
    /// Registers a new entity controller.
    /// </summary>
    /// <param name="entryController">The entity controller to register.</param>
    public void RegisterController(IEntryController entryController)
    {
        _typeToController.Add(entryController.EntryType, entryController);
        _identifierToController.Add(entryController.Identifier, entryController);
    }
    
    /// <summary>
    /// Registers a new entity controller.
    /// </summary>
    /// <typeparam name="T">The controller type.</typeparam>
    public void RegisterController<T>() where T : IEntryController, new()
    {
        RegisterController(new T());
    }

    
    /// <summary>
    /// Tries to get the entity controller with the given entity type.
    /// </summary>
    /// <param name="entryType">The entity type of the controller.</param>
    /// <param name="entryController">The found entity controller.</param>
    /// <returns>Returns <c>true</c> when an entity controller with the given id was found.</returns>
    public bool TryGetEntityController(Type entryType, [MaybeNullWhen(false)] out IEntryController entryController)
    {
        return _typeToController.TryGetValue(entryType, out entryController);
    }
    
    /// <summary>
    /// Tries to get the entity controller with the given entity type.
    /// </summary>
    /// <param name="entryController">The found entity controller.</param>
    /// <typeparam name="T">The entity type of the controller.</typeparam>
    /// <returns>Returns <c>true</c> when an entity controller with the given id was found.</returns>
    public bool TryGetEntityController<T>([MaybeNullWhen(false)] out IEntryController entryController) where T : Entry
    {
        return TryGetEntityController(typeof(T), out entryController);
    }
    
    /// <summary>
    /// Tries to get the entity controller with the given identifier.
    /// </summary>
    /// <param name="identifier">The identifier of the entity controller.</param>
    /// <param name="entryController">The found entity controller.</param>
    /// <returns>Returns <c>true</c> when an entity controller with the given id was found.</returns>
    public bool TryGetEntityController(string identifier, [MaybeNullWhen(false)] out IEntryController entryController)
    {
        return _identifierToController.TryGetValue(identifier, out entryController);
    }

    #endregion Controllers
}