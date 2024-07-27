using Asreyion.Framework.Shared.Interfaces;
using System.Reflection;

namespace Asreyion.Framework.Shared;

/// <summary>
/// Provides a base implementation for managing a collection of objects of type <typeparamref name="TManagedType"/>.
/// </summary>
/// <typeparam name="TManagedType">
/// The type of objects managed by this class. Must be a class.
/// </typeparam>
public abstract class SharedManager<TManagedType> : ISharedManager<TManagedType> where TManagedType : class
{
    /// <summary>
    /// The list of managed objects.
    /// </summary>
    protected readonly List<TManagedType> managedObjects = [];

    /// <summary>
    /// Defines a value for if the class has been disposed or not yet.
    /// </summary>
    private bool disposedValue;

    /// <summary>
    /// Finalizer to clean up resources if Dispose was not called.
    /// </summary>
    ~SharedManager()
    {
        // Call the dispose function.
        this.Dispose(disposing: false);
    }

    /// <summary>
    /// Called to free unmanaged resources. Override this method to release custom unmanaged resources.
    /// </summary>
    protected virtual void OnFreeUnmanagedResources() { }

    /// <summary>
    /// Called when the manager fails to create an instance of <see cref="TManagedType"/>.
    /// </summary>
    /// <param name="type">The type that failed to activate.</param>
    /// <param name="ex">The exception that was thrown while activating the type.</param>
    protected virtual void OnDiscoverFail(Type type, Exception ex) => Console.WriteLine($"Error instantiating type {type.FullName}: {ex.Message}");

    /// <summary>
    /// Called when the object is disposed. Override this method to release managed resources.
    /// </summary>
    protected virtual void OnDispose() { }

    /// <summary>
    /// Releases all resources used by the <see cref="SharedManager{TManagedType}"/>.
    /// </summary>
    public void Dispose()
    {
        // Call the dispose function and supress finalization.
        this.Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Discovers and initializes managed objects from the executing assembly and all referenced assemblies.
    /// </summary>
    /// <returns>
    /// The current instance of <see cref="ISharedManager{TManagedType}"/> with initialized objects.
    /// </returns>
    public virtual ISharedManager<TManagedType> Discover()
    {
        // Register managed managed objects from the executing assembly.
        _ = this.Discover(Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly());

        // Find all of the assemblies the executing assembly references.
        foreach (AssemblyName assembly in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
        {
            // Register managed managed objects from the referenced assembly.
            _ = this.Discover(Assembly.Load(assembly));
        }

        // Return the current instance.
        return this.Sort();
    }

    /// <summary>
    /// Discovers and initializes managed objects from a specific assembly.
    /// </summary>
    /// <param name="assembly">
    /// The <see cref="Assembly"/> to discover types from.
    /// </param>
    /// <returns>
    /// The current instance of <see cref="ISharedManager{TManagedType}"/> with initialized objects from the specified assembly.
    /// </returns>
    public virtual ISharedManager<TManagedType> Discover(Assembly assembly)
    {
        // Find all types in the assembly that are not abstract or an interface.
        List<Type> types = assembly.GetTypes()
            .Where(t => typeof(TManagedType).IsAssignableFrom(t)
                        && !t.IsAbstract
                        && !t.IsInterface)
            .ToList();

        // Loop through each type found.
        foreach (Type type in types)
        {
            try
            {
                // Check to see if the type has already been registered.
                if (!this.managedObjects.Any(t => t.GetType().Equals(type)))
                {
                    // Attempt to create an instace of the type.
                    if (Activator.CreateInstance(type) is TManagedType instance)
                    {
                        // Store the activated type in the collection.
                        this.managedObjects.Add(instance);
                    }
                }
            }
            catch (Exception ex)
            {
                this.OnDiscoverFail(type, ex);
            }
        }

        // Return the current instance.
        return this.Sort();
    }

    /// <summary>
    /// Disposes of resources used by the <see cref="SharedManager{TManagedType}"/>.
    /// </summary>
    /// <param name="disposing">
    /// <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
        // Check to see if the class has already been disposed.
        if (!this.disposedValue)
        {
            // Check to see if we are disposing managed resources.
            if (disposing)
            {
                // Call Free function to release the managed objects.
                _ = this.Free();

                // Call the OnDispose function to free managed resources.
                this.OnDispose();
            }

            // Call the OnFreeUnmanagedResources to free unmanaged resources.
            this.OnFreeUnmanagedResources();
            this.disposedValue = true;
        }
    }

    /// <summary>
    /// Executes a specified action on each managed object.
    /// </summary>
    /// <param name="action">
    /// The action to execute on each managed object.
    /// </param>
    /// <returns>
    /// The current instance of <see cref="ISharedManager{TManagedType}"/> after executing the action.
    /// </returns>
    public virtual ISharedManager<TManagedType> Execute(Action<TManagedType> action)
    {
        // Loop through the collection of objects.
        foreach (TManagedType obj in this.managedObjects)
        {
            // Execute the action on the object.
            action(obj);
        }

        // Return the current instance.
        return this;
    }

    /// <summary>
    /// Executes a specified action on each managed object with an additional parameter.
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
    public virtual ISharedManager<TManagedType> Execute<PType>(Action<TManagedType, PType> action, PType parameter)
    {
        // Loop through the collection of objects.
        foreach (TManagedType obj in this.managedObjects)
        {
            // Execute the action on the object.
            action(obj, parameter);
        }

        // Return the current instance.
        return this;
    }

    /// <summary>
    /// Executes a specified action on each managed object with two additional parameters.
    /// </summary>
    /// <typeparam name="ParameterType1">
    /// The type of the first additional parameter.
    /// </typeparam>
    /// <typeparam name="ParameterType2">
    /// The type of the second additional parameter.
    /// </typeparam>
    /// <param name="action">
    /// The action to execute on each managed object, which also takes two additional parameters.
    /// </param>
    /// <param name="parameter1">
    /// The first additional parameter to pass to the action.
    /// </param>
    /// <param name="parameter2">
    /// The second additional parameter to pass to the action.
    /// </param>
    /// <returns>
    /// The current instance of <see cref="ISharedManager{TManagedType}"/> after executing the action with the parameters.
    /// </returns>
    public virtual ISharedManager<TManagedType> Execute<ParameterType1, ParameterType2>(Action<TManagedType, ParameterType1, ParameterType2> action, ParameterType1 parameter1, ParameterType2 parameter2)
    {
        // Loop through the collection of objects.
        foreach (TManagedType obj in this.managedObjects)
        {
            // Execute the action on the object.
            action(obj, parameter1, parameter2);
        }

        // Return the current instance.
        return this;
    }

    /// <summary>
    /// Releases the managed objects and clears the list.
    /// </summary>
    /// <returns>
    /// The current instance of <see cref="ISharedManager{TManagedType}"/> after releasing resources.
    /// </returns>
    public virtual ISharedManager<TManagedType> Free()
    {
        // Loop through the collection of objects.
        foreach (TManagedType? managedObject in this.managedObjects)
        {
            // Check to see if the object is an IDisposable object.
            if (managedObject is IDisposable disposable)
            {
                // Dispose the object.
                disposable.Dispose();
            }
        }

        // Clear the list of all objects.
        this.managedObjects.Clear();

        // Return the current instance.
        return this;
    }

    /// <summary>
    /// Sorts the managed objects. This method must be implemented in derived classes.
    /// </summary>
    /// <returns>
    /// The current instance of <see cref="ISharedManager{TManagedType}"/> after sorting the objects.
    /// </returns>
    public abstract ISharedManager<TManagedType> Sort();
}
