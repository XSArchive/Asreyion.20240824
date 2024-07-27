using Asreyion.Framework.Enumerations;
using Asreyion.Framework.Shared.Interfaces;

namespace Asreyion.Framework.Shared;

public abstract class SharedModuleTheme : ISharedModuleTheme
{
    private readonly HashSet<string> executedFunctions = [];
    private bool disposedValue;

    public abstract Priority Priority { get; }

    ~SharedModuleTheme()
    {
        this.Dispose(disposing: false);
    }

    public virtual bool HasExecuted(string functionName) => this.executedFunctions.Contains(functionName);
    protected virtual void MarkAsExecuted(string functionName) => this.executedFunctions.Add(functionName);
    protected virtual void OnFreeUnmanagedResources() { }
    protected virtual void OnDispose() { }

    public void Dispose()
    {
        this.Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposedValue)
        {
            if (disposing)
            {
                this.OnDispose();
            }

            this.OnFreeUnmanagedResources();
            this.disposedValue = true;
        }
    }
}
