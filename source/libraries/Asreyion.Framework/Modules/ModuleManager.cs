using Asreyion.Framework.Shared;
using Asreyion.Framework.Shared.Interfaces;

namespace Asreyion.Framework.Modules;

/// <summary>
/// Manages a collection of <see cref="Module"/> objects and provides functionality to manage them.
/// </summary>
public class ModuleManager : SharedManager<Module>
{
    /// <summary>
    /// Sorts the managed <see cref="Module"/> objects by their priority in ascending order.
    /// </summary>
    /// <returns>
    /// The current instance of <see cref="ModuleManager"/>.
    /// </returns>
    public override ISharedManager<Module> Sort()
    {
        // Sort the managed modules based on their priority
        this.managedObjects.Sort((x, y) => x.Priority.CompareTo(y.Priority));

        // Return the current instance.
        return this;
    }
}
