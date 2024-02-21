namespace MyOrganizer.Passwords;

/// <summary>
/// A single field of a <see cref="PasswordEntry"/>.
/// </summary>
public class PasswordField
{
    /// <summary>
    /// Gets and sets the type of the field.
    /// </summary>
    public PasswordFieldType Type { get; set; }

    /// <summary>
    /// Gets and sets the fields name.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Gets and sets the fields value.
    /// </summary>
    public string Value { get; set; } = "";
}