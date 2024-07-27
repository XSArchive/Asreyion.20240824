using Asreyion.Framework.Shared;
using Asreyion.Framework.Shared.Interfaces;

namespace Asreyion.Framework.Themes;

public class ThemeManager : SharedManager<Theme>
{
    public override ISharedManager<Theme> Sort()
    {
        this.managedObjects.Sort((x, y) => x.Priority.CompareTo(y.Priority));

        return this;
    }
}
