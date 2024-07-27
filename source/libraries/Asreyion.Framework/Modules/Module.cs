using Asreyion.Framework.Enumerations;
using Asreyion.Framework.Shared;

namespace Asreyion.Framework.Modules;

/// <summary>
/// Represents an abstract base class for a module in Asreyion.
/// </summary>
public abstract class Module : SharedModuleTheme
{
    /// <summary>
    /// Gets the execution priority level of the module.
    /// </summary>
    /// <value>
    /// The execution priority of the module, which is set to <see cref="Priority.Normal"/> by default.
    /// </value>
    public override Priority Priority => Priority.Normal;
}
