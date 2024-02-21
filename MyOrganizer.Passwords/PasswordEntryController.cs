using MyOrganizer.Storage;

namespace MyOrganizer.Passwords;

/// <summary>
/// The controller for <see cref="PasswordEntry"/>.
/// </summary>
public class PasswordEntryController : IEntryController
{
    /// <inheritdoc />
    string IEntryController.Identifier => Identifier;
    
    /// <inheritdoc cref="IEntryController.Identifier"/>
    public static string Identifier => "organizer.password";
}