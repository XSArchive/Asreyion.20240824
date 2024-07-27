using Asreyion.Framework.Enumerations;

namespace Asreyion.Framework.Shared.Interfaces;

public interface ISharedModuleTheme : IDisposable
{
    Priority Priority { get; }

    bool HasExecuted(string functionName);
}