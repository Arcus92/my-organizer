using Avalonia.Controls;
using ReactiveUI;

namespace MyOrganizer.Common;

/// <summary>
/// The base class for any view model in the organizer.
/// </summary>
public abstract class ViewModelBase : ReactiveObject
{
    /// <summary>
    /// Builds the control view element for the view model.
    /// </summary>
    /// <returns>Returns the created user control.</returns>
    public abstract Control Build();
}

/// <summary>
/// The base class for any view model in the organizer.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ViewModelBase<T> : ViewModelBase where T : Control, new()
{
    /// <inheritdoc />
    public override Control Build()
    {
        return new T();
    }
}