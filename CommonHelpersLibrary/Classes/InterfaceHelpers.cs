using System.Reflection;
using System.Text.RegularExpressions;

namespace CommonHelpersLibrary;

/// <summary>
/// Provides utility methods for working with types, interfaces, and generic collections.
/// </summary>
/// <remarks>
/// https://dev.to/karenpayneoregon/working-with-interfaces-2pi7
/// </remarks>
public static partial class InterfaceHelpers
{
    /// <summary>
    /// Retrieves all public properties of a given type, including those inherited from interfaces.
    /// </summary>
    /// <param name="type">
    /// The <see cref="Type"/> whose public properties are to be retrieved.
    /// </param>
    /// <returns>
    /// An array of <see cref="PropertyInfo"/> objects representing the public properties of the specified type.
    /// </returns>
    /// <remarks>
    /// If the specified type is an interface, this method also includes properties from all inherited interfaces.
    /// </remarks>
    public static PropertyInfo[] GetPublicProperties(this Type type)
    {
        if (!type.IsInterface)
            return type.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);

        var propertyInfos = new List<PropertyInfo>();

        var considered = new List<Type>();
        var queue = new Queue<Type>();

        considered.Add(type);
        queue.Enqueue(type);

        while (queue.Count > 0)
        {
            var subType = queue.Dequeue();
            foreach (var subInterface in subType.GetInterfaces())
            {
                if (considered.Contains(subInterface)) continue;

                considered.Add(subInterface);
                queue.Enqueue(subInterface);
            }

            var typeProperties = subType.GetProperties(
                BindingFlags.FlattenHierarchy
                | BindingFlags.Public
                | BindingFlags.Instance);

            var newPropertyInfos = typeProperties.Where(x => !propertyInfos.Contains(x));

            propertyInfos.InsertRange(0, newPropertyInfos);
        }

        return propertyInfos.ToArray();

    }
    /// <summary>
    /// Retrieves the names of all entities that implement a specified interface type.
    /// </summary>
    /// <typeparam name="T">
    /// The interface type to search for. Must be a class type and an interface.
    /// </typeparam>
    /// <returns>
    /// A list of strings representing the names of all entities that implement the specified interface.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the specified type <typeparamref name="T"/> is not an interface.
    /// </exception>
    public static List<string> GetAllEntityNames<T>() where T : class
    {
        if (!typeof(T).IsInterface)
            throw new ArgumentException("T must be an interface.");

        return GetAllEntities<T>()
            .Select(x => x.Name)
            .ToList();
    }

    /// <summary>
    /// Retrieves all types that implement a specified interface type.
    /// </summary>
    /// <typeparam name="T">
    /// The interface type to search for. Must be a class type and an interface.
    /// </typeparam>
    /// <returns>
    /// A list of <see cref="Type"/> objects representing all types that implement the specified interface.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the specified type <typeparamref name="T"/> is not an interface.
    /// </exception>
    public static List<Type> GetAllEntities<T>() where T : class
    {
        if (!typeof(T).IsInterface)
            throw new ArgumentException("T must be an interface.");

        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(T).IsAssignableFrom(x) && x is { IsInterface: false, IsAbstract: false })
            .ToList();
    }
    /// <summary>
    /// Determines whether a specified type implements more than one of the provided interface types.
    /// </summary>
    /// <typeparam name="T">
    /// The type to check for interface implementation.
    /// </typeparam>
    /// <param name="interfaces">
    /// An array of interface types to check against.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the specified type implements more than one of the provided interfaces; otherwise, <see langword="false"/>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the <paramref name="interfaces"/> array is null, empty, or contains types that are not interfaces.
    /// </exception>
    public static bool ImplementsMoreThanOneInterface<T>(Type[] interfaces)
    {
        if (interfaces == null || interfaces.Length == 0)
            throw new ArgumentException("At least one interface type must be provided.");

        if (interfaces.Any(i => !i.IsInterface))
            throw new ArgumentException("All types provided must be interfaces.");

        var targetType = typeof(T);

        var implementedInterfaces = targetType.GetInterfaces();
        var matchCount = interfaces.Count(i => implementedInterfaces.Contains(i));

        return matchCount > 1;
    }

    /// <summary>
    /// Retrieves the generic type arguments of all <see cref="IEnumerable{T}"/> interfaces
    /// implemented by the specified object.
    /// </summary>
    /// <param name="sender">
    /// The object whose implemented <see cref="IEnumerable{T}"/> interfaces are to be inspected.
    /// </param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> of <see cref="Type"/> objects representing the generic type
    /// arguments of all <see cref="IEnumerable{T}"/> interfaces implemented by the specified object.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="sender"/> is <c>null</c>.
    /// </exception>
    public static IEnumerable<Type> GetGenericIEnumerable(object sender) =>
        sender
            .GetType()
            .GetInterfaces()
            .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            .Select(t => t.GetGenericArguments()[0]);


    [GeneratedRegex("[0-9]+$")]
    private static partial Regex TrailingNumberRegex();
}