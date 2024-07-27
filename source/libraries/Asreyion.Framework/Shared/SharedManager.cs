using Asreyion.Framework.Shared.Interfaces;
using System.Reflection;

namespace Asreyion.Framework.Shared;

public abstract class SharedManager<TManagedType> : ISharedManager<TManagedType> where TManagedType : class
{
    protected readonly List<TManagedType> managedObjects = [];
    private bool disposedValue;

    ~SharedManager()
    {
        this.Dispose(disposing: false);
    }

    protected virtual void OnFreeUnmanagedResources() { }
    protected virtual void OnDispose() { }

    public void Dispose()
    {
        this.Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public virtual ISharedManager<TManagedType> Discover()
    {
        _ = this.Discover(Assembly.GetExecutingAssembly());

        foreach (AssemblyName assembly in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
        {
            _ = this.Discover(Assembly.Load(assembly));
        }

        return this.Sort();
    }

    public virtual ISharedManager<TManagedType> Discover(Assembly assembly)
    {
        List<Type> types = assembly.GetTypes()
            .Where(t => typeof(TManagedType).IsAssignableFrom(t)
                        && !t.IsAbstract
                        && !t.IsInterface)
            .ToList();

        foreach (Type type in types)
        {
            try
            {
                if (Activator.CreateInstance(type) is TManagedType instance)
                {
                    this.managedObjects.Add(instance);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error instantiating type {type.FullName}: {ex.Message}");
            }
        }

        return this.Sort();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposedValue)
        {
            if (disposing)
            {
                _ = this.Free();
                this.OnDispose();
            }

            this.OnFreeUnmanagedResources();
            this.disposedValue = true;
        }
    }

    public virtual ISharedManager<TManagedType> Execute(Action<TManagedType> action)
    {
        foreach (TManagedType obj in this.managedObjects)
        {
            action(obj);
        }

        return this;
    }

    public virtual ISharedManager<TManagedType> Execute<PType>(Action<TManagedType, PType> action, PType parameter)
    {
        foreach (TManagedType obj in this.managedObjects)
        {
            action(obj, parameter);
        }

        return this;
    }

    public virtual ISharedManager<TManagedType> Execute<ParameterType1, ParameterType2>(Action<TManagedType, ParameterType1, ParameterType2> action, ParameterType1 parameter1, ParameterType2 parameter2)
    {
        foreach (TManagedType obj in this.managedObjects)
        {
            action(obj, parameter1, parameter2);
        }

        return this;
    }

    public virtual ISharedManager<TManagedType> Free()
    {
        foreach (TManagedType? managedObject in this.managedObjects)
        {
            if (managedObject is IDisposable)
            {
                (managedObject as IDisposable)?.Dispose();
            }
        }
        this.managedObjects.Clear();

        return this;
    }

    public abstract ISharedManager<TManagedType> Sort();
}
