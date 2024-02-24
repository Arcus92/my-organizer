using MyOrganizer.Views;

namespace MyOrganizer.ViewModels;

/// <summary>
/// The view model for <see cref="MainWindow"/>.
/// Only used for Desktop applications.
/// </summary>
public class MainWindowViewModel
{
    /// <summary>
    /// Gets the view model of the main view.
    /// </summary>
    public MainViewModel MainViewModel { get; } = new();
}