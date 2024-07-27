namespace Asreyion.Framework.Shared.Interfaces;

public interface ISharedModuleTheme : IDisposable
{
    bool HasExecuted(string functionName);
}