using Asreyion.Framework.Shared;
using Asreyion.Framework.Shared.Interfaces;

namespace Asreyion.Framework.Modules;

public class ModuleManager : SharedManager<Module>
{
    public override ISharedManager<Module> Sort()
    {
        this.managedObjects.Sort((x, y) => x.Priority.CompareTo(y.Priority));

        return this;
    }
}
