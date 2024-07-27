using Asreyion.Framework.Enumerations;
using Asreyion.Framework.Shared;

namespace Asreyion.Framework.Themes;

/// <summary>
/// Represents an abstract base class for a theme in Asreyion.
/// </summary>
public abstract class Theme : SharedModuleTheme
{
    /// <summary>
    /// Gets the execution priority level of the theme.
    /// </summary>
    /// <value>
    /// The execution priority of the theme, which is set to <see cref="Priority.Normal"/> by default.
    /// </value>
    public override Priority Priority => Priority.Normal;
}
