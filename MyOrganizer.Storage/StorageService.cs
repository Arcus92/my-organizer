using System.Diagnostics.CodeAnalysis;

namespace MyOrganizer.Storage;

/// <summary>
/// A service to manage loaded storage container.
/// </summary>
public class StorageService
{
    #region Entry

    /// <summary>
    /// Creates a new entry for the given identifier.
    /// </summary>
    /// <param name="identifier">The entity controller identifier.</param>
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
    /// A map of all registered entity controller.
    /// </summary>
    private readonly Dictionary<string, IEntryController> _controllerMap = new();

    /// <summary>
    /// Registers a new entity controller.
    /// </summary>
    /// <param name="entryController">The entity controller to register.</param>
    public void RegisterController(IEntryController entryController)
    {
        _controllerMap.Add(entryController.Identifier, entryController);
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
    /// Tries to get the entity controller with the given identifier.
    /// </summary>
    /// <param name="identifier">The entity controller identifier.</param>
    /// <param name="entryController">The found entity controller.</param>
    /// <returns>Returns <c>true</c> when an entity controller with the given id was found.</returns>
    public bool TryGetEntityController(string identifier, [MaybeNullWhen(false)] out IEntryController entryController)
    {
        return _controllerMap.TryGetValue(identifier, out entryController);
    }

    #endregion Controllers
}