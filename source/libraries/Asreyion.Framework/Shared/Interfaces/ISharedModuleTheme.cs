using Asreyion.Framework.Enumerations;

namespace Asreyion.Framework.Shared.Interfaces;

/// <summary>
/// Defines a contract for an Asreyion theme or module.
/// </summary>
public interface ISharedModuleTheme : IDisposable
{
    /// <summary>
    /// Gets the priority level of the theme or module.
    /// </summary>
    /// <value>
    /// The priority of the theme module as an instance of <see cref="Priority"/> enumeration.
    /// </value>
    Priority Priority { get; }

    /// <summary>
    /// Determines whether a specific function has been executed within the theme or module.
    /// </summary>
    /// <param name="functionName">
    /// The name of the function to check for execution status.
    /// </param>
    /// <returns>
    /// <c>true</c> if the function has been executed; otherwise, <c>false</c>.
    /// </returns>
    bool HasExecuted(string functionName);
}
