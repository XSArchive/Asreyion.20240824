using Asreyion.Framework.Enumerations;
using Asreyion.Framework.Shared.Interfaces;

namespace Asreyion.Framework.Shared;

/// <summary>
/// Provides an abstract base class for an Asreyion module or theme.
/// </summary>
public abstract class SharedModuleTheme : ISharedModuleTheme
{
    /// <summary>
    /// Defines a collection of executed function names.
    /// </summary>
    private readonly HashSet<string> executedFunctions = [];
    /// <summary>
    /// Defines a value for if the class has been disposed or not yet.
    /// </summary>
    private bool disposedValue;

    /// <summary>
    /// Gets the code execution priority level of the module or theme.
    /// </summary>
    /// <value>
    /// The priority of the module theme as an instance of <see cref="Priority"/> enumeration.
    /// </value>
    public abstract Priority Priority { get; }

    /// <summary>
    /// Finalizer to clean up resources if Dispose was not called.
    /// </summary>
    ~SharedModuleTheme()
    {
        // Call the dispose function.
        this.Dispose(disposing: false);
    }

    /// <summary>
    /// Determines whether a specific function has been executed within the module or theme.
    /// </summary>
    /// <param name="functionName">
    /// The name of the function to check for execution status.
    /// </param>
    /// <returns>
    /// <c>true</c> if the function has been executed; otherwise, <c>false</c>.
    /// </returns>
    public virtual bool HasExecuted(string functionName) => this.executedFunctions.Contains(functionName);

    /// <summary>
    /// Marks a function as executed within the module or theme.
    /// </summary>
    /// <param name="functionName">
    /// The name of the function to mark as executed.
    /// </param>
    protected virtual void MarkAsExecuted(string functionName) => this.executedFunctions.Add(functionName);

    /// <summary>
    /// Called to free unmanaged resources. Override this method to release custom unmanaged resources.
    /// </summary>
    protected virtual void OnFreeUnmanagedResources() { }

    /// <summary>
    /// Called when the object is disposed. Override this method to release managed resources.
    /// </summary>
    protected virtual void OnDispose() { }

    /// <summary>
    /// Releases all resources used by the <see cref="SharedModuleTheme"/>.
    /// </summary>
    public void Dispose()
    {
        // Call the dispose function and supress finalization.
        this.Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes of resources used by the <see cref="SharedModuleTheme"/>.
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
                // Call the OnDispose function to free managed resources.
                this.OnDispose();
            }

            // Call the OnFreeUnmanagedResources to free unmanaged resources.
            this.OnFreeUnmanagedResources();
            this.disposedValue = true;
        }
    }
}
