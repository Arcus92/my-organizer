using MyOrganizer.Notes.Ui;
using MyOrganizer.Passwords.Ui;
using MyOrganizer.Storage;
using Splat;

namespace MyOrganizer;

/// <summary>
/// Bootstrapper class to init required services.
/// </summary>
public static class Bootstrapper
{
    /// <summary>
    /// Registers the storage service.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="resolver"></param>
    public static void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        services.Register(() =>
        {
            var storageService = new StorageService();
            storageService.RegisterController<NoteEntryUiController>();
            storageService.RegisterController<PasswordEntryUiController>();
            return storageService;
        });
    }
}