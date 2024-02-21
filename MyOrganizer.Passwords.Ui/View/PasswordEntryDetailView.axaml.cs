using Avalonia.ReactiveUI;
using MyOrganizer.Passwords.Ui.ViewModel;

namespace MyOrganizer.Passwords.Ui.View;

/// <summary>
/// The detail view for an <see cref="PasswordEntry"/>.
/// </summary>
public partial class PasswordEntryDetailView : ReactiveUserControl<PasswordEntryDetailViewModel>
{
    /// <inheritdoc />
    public PasswordEntryDetailView()
    {
        InitializeComponent();
    }
}