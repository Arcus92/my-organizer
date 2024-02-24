using Avalonia.ReactiveUI;
using MyOrganizer.ViewModels;

namespace MyOrganizer.Views;

/// <summary>
/// The main application view hosted in the <see cref="MainWindow"/> or as main view for mobile / web apps.
/// </summary>
public partial class MainView : ReactiveUserControl<MainViewModel>
{
    /// <summary>
    /// Creates the main view.
    /// </summary>
    public MainView()
    {
        InitializeComponent();
    }
}