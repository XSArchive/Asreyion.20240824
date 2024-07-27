using System.Reflection;

namespace Asreyion.Framework.Shared.Interfaces;
public interface ISharedManager<TManagedType> : IDisposable where TManagedType : class
{
    ISharedManager<TManagedType> Discover();
    ISharedManager<TManagedType> Discover(Assembly assembly);
    ISharedManager<TManagedType> Execute(Action<TManagedType> action);
    ISharedManager<TManagedType> Execute<ParameterType1, ParameterType2>(Action<TManagedType, ParameterType1, ParameterType2> action, ParameterType1 parameter1, ParameterType2 parameter2);
    ISharedManager<TManagedType> Execute<PType>(Action<TManagedType, PType> action, PType parameter);
    ISharedManager<TManagedType> Free();
}