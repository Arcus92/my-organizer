using Splat;

namespace MyOrganizer.Common;

/// <summary>
/// A helper class for the splat locator.
/// </summary>
public static class LocatorHelper
{
    /// <summary>
    /// Returns the requested service, but throws an exception it the service was not registered.
    /// </summary>
    /// <param name="resolver">The dependency resolver.</param>
    /// <typeparam name="T">The service type.</typeparam>
    /// <returns>Returns the service.</returns>
    /// <exception cref="InvalidOperationException">Is throws when the server wasn't registered.</exception>
    public static T GetRequiredService<T>(this IReadonlyDependencyResolver resolver)
    {
        var service = resolver.GetService<T>();
        if (service is null)
        {
            throw new InvalidOperationException($"Requested service '{typeof(T).Name}' wasn't registered!");
        }

        return service;
    }
}