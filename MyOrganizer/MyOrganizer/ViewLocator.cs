using Avalonia.Controls;
using Avalonia.Controls.Templates;
using MyOrganizer.Common;

namespace MyOrganizer;

/// <summary>
/// The main view locator for <see cref="ViewModelBase"/>.
/// </summary>
public class ViewLocator : IDataTemplate
{
    /// <inheritdoc />
    public Control? Build(object? data)
    {
        if (data is not ViewModelBase viewModel)
            return null;

        return viewModel.Build();
    }

    /// <inheritdoc />
    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}