using Asreyion.Framework.Enumerations;
using Asreyion.Framework.Shared;

namespace Asreyion.Framework.Modules;

public abstract class Module : SharedModuleTheme
{
    public override Priority Priority => Priority.Normal;
}
