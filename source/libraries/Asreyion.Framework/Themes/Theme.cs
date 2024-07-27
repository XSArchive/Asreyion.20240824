using Asreyion.Framework.Enumerations;
using Asreyion.Framework.Shared;

namespace Asreyion.Framework.Themes;

public abstract class Theme : SharedModuleTheme
{
    public override Priority Priority => Priority.Normal;
}
