using System.Reflection;

namespace Asreyion.Framework.Shared.Interfaces;

/// <summary>
/// Defines a contract for managing a collection of objects of type <typeparamref name="TManagedType"/>.
/// </summary>
/// <typeparam name="TManagedType">
/// The type of objects managed by this interface. Must be a class.
/// </typeparam>
public interface ISharedManager<TManagedType> : IDisposable where TManagedType : class
{
    /// <summary>
    /// Discovers and initializes the managed objects from the currently executing assembly and all of it's references.
    /// </summary>
    /// <returns>
    /// The current instance of <see cref="ISharedManager{TManagedType}"/> with initialized objects.
    /// </returns>
    ISharedManager<TManagedType> Discover();

    /// <summary>
    /// Discovers and initializes the managed objects from a specific assembly.
    /// </summary>
    /// <param name="assembly">
    /// The <see cref="Assembly"/> to discover types from.
    /// </param>
    /// <returns>
    /// The current instance of <see cref="ISharedManager{TManagedType}"/> with initialized objects from the specified assembly.
    /// </returns>
    ISharedManager<TManagedType> Discover(Assembly assembly);

    /// <summary>
    /// Executes a specified action on each managed object.
    /// </summary>
    /// <param name="action">
    /// The action to execute on each managed object.
    /// </param>
    /// <returns>
    /// The current instance of <see cref="ISharedManager{TManagedType}"/> after executing the action.
    /// </returns>
    ISharedManager<TManagedType> Execute(Action<TManagedType> action);

    /// <summary>
    /// Executes a specified action on each managed object with two additional parameters.
    /// </summary>
    /// <typeparam name="ParameterType1">
    /// The type of the first parameter.
    /// </typeparam>
    /// <typeparam name="ParameterType2">
    /// The type of the second parameter.
    /// </typeparam>
    /// <param name="action">
    /// The action to execute on each managed object, which also takes two additional parameters.
    /// </param>
    /// <param name="parameter1">
    /// The first parameter to pass to the action.
    /// </param>
    /// <param name="parameter2">
    /// The second parameter to pass to the action.
    /// </param>
    /// <returns>
    /// The current instance of <see cref="ISharedManager{TManagedType}"/> after executing the action with parameters.
    /// </returns>
    ISharedManager<TManagedType> Execute<ParameterType1, ParameterType2>(Action<TManagedType, ParameterType1, ParameterType2> action, ParameterType1 parameter1, ParameterType2 parameter2);

    /// <summary>
    /// Executes a specified action on each managed object with one additional parameter.
    /// </summary>
    /// <typeparam name="PType">
    /// The type of the additional parameter.
    /// </typeparam>
    /// <param name="action">
    /// The action to execute on each managed object, which also takes an additional parameter.
    /// </param>
    /// <param name="parameter">
    /// The additional parameter to pass to the action.
    /// </param>
    /// <returns>
    /// The current instance of <see cref="ISharedManager{TManagedType}"/> after executing the action with the parameter.
    /// </returns>
    ISharedManager<TManagedType> Execute<PType>(Action<TManagedType, PType> action, PType parameter);

    /// <summary>
    /// Releases and performs cleanup for the managed objects.
    /// </summary>
    /// <returns>
    /// The current instance of <see cref="ISharedManager{TManagedType}"/> after releasing the objects.
    /// </returns>
    ISharedManager<TManagedType> Free();

    /// <summary>
    /// Sorts the managed objects according to a predefined order.
    /// </summary>
    /// <returns>
    /// The current instance of <see cref="ISharedManager{TManagedType}"/> after sorting the objects.
    /// </returns>
    ISharedManager<TManagedType> Sort();
}
