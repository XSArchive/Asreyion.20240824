using Asreyion.Framework.Enumerations;
using Asreyion.Framework.Shared;
using Microsoft.AspNetCore.Builder;

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

    /// <summary>
    /// Registers controllers with the specified <see cref="WebApplicationBuilder"/>.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="WebApplicationBuilder"/> used to register controllers.
    /// </param>
    public virtual void RegisterControllers(WebApplicationBuilder builder) { }

    /// <summary>
    /// Configures the environment settings for the specified <see cref="WebApplication"/>.
    /// </summary>
    /// <param name="app">
    /// The <see cref="WebApplication"/> to configure the environment settings for.
    /// </param>
    public virtual void ConfigureEnvironment(WebApplication app) { }

    /// <summary>
    /// Configures the authorization settings for the specified <see cref="WebApplication"/>.
    /// </summary>
    /// <param name="app">
    /// The <see cref="WebApplication"/> to configure the authorization settings for.
    /// </param>
    public virtual void ConfigureAuthorization(WebApplication app) { }

    /// <summary>
    /// Configures the file handling settings for the specified <see cref="WebApplication"/>.
    /// </summary>
    /// <param name="app">
    /// The <see cref="WebApplication"/> to configure the file handling settings for.
    /// </param>
    public virtual void ConfigureFiles(WebApplication app) { }

    /// <summary>
    /// Configures HTTPS settings for the specified <see cref="WebApplication"/>.
    /// </summary>
    /// <param name="app">
    /// The <see cref="WebApplication"/> to configure HTTPS settings for.
    /// </param>
    public virtual void ConfigureHttps(WebApplication app) { }

    /// <summary>
    /// Configures routing settings for the specified <see cref="WebApplication"/>.
    /// </summary>
    /// <param name="app">
    /// The <see cref="WebApplication"/> to configure routing settings for.
    /// </param>
    public virtual void ConfigureRouting(WebApplication app) { }

    /// <summary>
    /// Maps routes for the specified <see cref="WebApplication"/>.
    /// </summary>
    /// <param name="app">
    /// The <see cref="WebApplication"/> to map routes for.
    /// </param>
    public virtual void MapRoutes(WebApplication app) { }
}
