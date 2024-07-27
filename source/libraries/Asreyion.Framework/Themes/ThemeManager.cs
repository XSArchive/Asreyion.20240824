using Asreyion.Framework.Shared;
using Asreyion.Framework.Shared.Interfaces;

namespace Asreyion.Framework.Themes;

/// <summary>
/// Manages a collection of <see cref="Theme"/> objects and provides functionality to manage them.
/// </summary>
public class ThemeManager : SharedManager<Theme>
{
    /// <summary>
    /// Sorts the managed <see cref="Theme"/> objects by their priority in ascending order.
    /// </summary>
    /// <returns>
    /// The current instance of <see cref="ThemeManager"/>.
    /// </returns>
    public override ISharedManager<Theme> Sort()
    {
        // Sort the managed themes based on their priority
        this.managedObjects.Sort((x, y) => x.Priority.CompareTo(y.Priority));

        // Return the current instance.
        return this;
    }
}
