namespace MyOrganizer.Passwords;

/// <summary>
/// Describes the input method and the role of a <see cref="PasswordField"/>.
/// </summary>
public enum PasswordFieldType
{
    /// <summary>
    /// A simple text field.
    /// </summary>
    Text,
    
    /// <summary>
    /// A multi-line text field.
    /// </summary>
    TextBox,
    
    /// <summary>
    /// A text field for a username.
    /// </summary>
    Username,
    
    /// <summary>
    /// A text field for an email address.
    /// </summary>
    Email,
    
    /// <summary>
    /// The ssid / name of a wifi network.
    /// </summary>
    WifiSsid,
    
    /// <summary>
    /// A secure password.
    /// </summary>
    Password,
    
    /// <summary>
    /// A secure pin (digits only).
    /// </summary>
    Pin
}