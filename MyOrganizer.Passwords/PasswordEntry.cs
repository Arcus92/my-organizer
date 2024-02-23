using MyOrganizer.Storage;

namespace MyOrganizer.Passwords;

/// <summary>
/// A password entry. Stores multiple fields for a single login. For example username, password and used url.
/// </summary>
public class PasswordEntry : Entry
{
    /// <summary>
    /// Gets the list of fields for this password form.
    /// </summary>
    public List<PasswordField> Fields { get; } = [];
}