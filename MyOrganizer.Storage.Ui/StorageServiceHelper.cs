using System.Diagnostics.CodeAnalysis;
using MyOrganizer.Storage.Ui.ViewModel;

namespace MyOrganizer.Storage.Ui;

/// <summary>
/// Static helper class that extends <see cref="StorageService"/> with ui methods.
/// </summary>
public static class StorageServiceHelper
{
    #region Controller
    
    /// <summary>
    /// Tries to get the entity ui controller with the given identifier.
    /// </summary>
    /// <param name="storageService">The storage service.</param>
    /// <param name="entityType">The entity type.</param>
    /// <param name="entryUiController">The found entity controller.</param>
    /// <returns>Returns <c>true</c> when an entity controller with the given id was found.</returns>
    public static bool TryGetEntityUiController(this StorageService storageService, Type entityType, 
        [MaybeNullWhen(false)] out IEntryUiController entryUiController)
    {
        if (storageService.TryGetEntityController(entityType, out var entryController) && entryController is IEntryUiController uiController)
        {
            entryUiController = uiController;
            return true;
        }

        entryUiController = null;
        return false;
    }
    
    /// <summary>
    /// Tries to get the entity ui controller with the given identifier.
    /// </summary>
    /// <param name="storageService">The storage service.</param>
    /// <param name="entryUiController">The found entity controller.</param>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <returns>Returns <c>true</c> when an entity controller with the given id was found.</returns>
    public static bool TryGetEntityUiController<T>(this StorageService storageService,
        [MaybeNullWhen(false)] out IEntryUiController entryUiController) where T : Entry
    {
        if (storageService.TryGetEntityController<T>(out var entryController) && entryController is IEntryUiController uiController)
        {
            entryUiController = uiController;
            return true;
        }

        entryUiController = null;
        return false;
    }
    
    /// <summary>
    /// Tries to get the entity ui controller with the given identifier.
    /// </summary>
    /// <param name="storageService">The storage service.</param>
    /// <param name="identifier">The entity controller identifier.</param>
    /// <param name="entryUiController">The found entity controller.</param>
    /// <returns>Returns <c>true</c> when an entity controller with the given id was found.</returns>
    public static bool TryGetEntityUiController(this StorageService storageService, string identifier, 
        [MaybeNullWhen(false)] out IEntryUiController entryUiController)
    {
        if (storageService.TryGetEntityController(identifier, out var entryController) && entryController is IEntryUiController uiController)
        {
            entryUiController = uiController;
            return true;
        }

        entryUiController = null;
        return false;
    }
    
    #endregion Controller
    
    #region View

    /// <summary>
    /// Tries to create the view model for the given entry.
    /// </summary>
    /// <param name="storageService">The storage service.</param>
    /// <param name="entry">The entry.</param>
    /// <param name="viewType">The view type to create.</param>
    /// <param name="viewModel">The created view model.</param>
    /// <returns></returns>
    public static bool TryCreateEntryViewModel(this StorageService storageService, Entry entry, EntryViewType viewType,
        [MaybeNullWhen(false)] out IEntryViewModel viewModel)
    {
        if (storageService.TryGetEntityUiController(entry.GetType(), out var entryUiController))
        {
            viewModel = entryUiController.CreateViewModel(entry, viewType);
            return viewModel is not null;
        }

        viewModel = null;
        return false;
    }
    
    #endregion View
}