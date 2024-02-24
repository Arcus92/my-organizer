using Avalonia.ReactiveUI;
using MyOrganizer.ViewModels;

namespace MyOrganizer.Views;

/// <summary>
/// The main application window for the Desktop.
/// </summary>
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    /// <summary>
    /// Create the main window.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
    }
}