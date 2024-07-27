using Asreyion.Framework.Enumerations;
using Asreyion.Framework.Modules;

namespace Asreyion.Modules;

/// <summary>
/// Represents an ASP.NET Core module for configuring and setting up the ASP.NET Core application.
/// </summary>
public class AspNetCoreModule : Module
{
    /// <summary>
    /// Gets the execution priority level of the module.
    /// </summary>
    /// <value>
    /// The execution priority of the module, which is set to <see cref="Priority.Root"/>.
    /// </value>
    public override Priority Priority => Priority.Root;

    /// <summary>
    /// Registers controllers with views in the ASP.NET Core application.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="WebApplicationBuilder"/> used to register controllers and other services.
    /// </param>
    public override void RegisterControllers(WebApplicationBuilder builder)
    {
        // Add services to the container.
        _ = builder.Services.AddControllersWithViews();

        // Call the base function.
        base.RegisterControllers(builder);
    }

    /// <summary>
    /// Configures the environment settings for the ASP.NET Core application.
    /// </summary>
    /// <param name="app">
    /// The <see cref="WebApplication"/> to configure the environment settings for.
    /// </param>
    public override void ConfigureEnvironment(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            _ = app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            _ = app.UseHsts();
        }

        // Call the base function.
        base.ConfigureEnvironment(app);
    }

    /// <summary>
    /// Configures HTTPS redirection for the ASP.NET Core application.
    /// </summary>
    /// <param name="app">
    /// The <see cref="WebApplication"/> to configure HTTPS redirection for.
    /// </param>
    public override void ConfigureHttps(WebApplication app)
    {
        _ = app.UseHttpsRedirection();

        // Call the base function.
        base.ConfigureHttps(app);
    }

    /// <summary>
    /// Configures static file serving for the ASP.NET Core application.
    /// </summary>
    /// <param name="app">
    /// The <see cref="WebApplication"/> to configure static file serving for.
    /// </param>
    public override void ConfigureFiles(WebApplication app)
    {
        _ = app.UseStaticFiles();

        // Call the base function.
        base.ConfigureFiles(app);
    }

    /// <summary>
    /// Configures routing for the ASP.NET Core application.
    /// </summary>
    /// <param name="app">
    /// The <see cref="WebApplication"/> to configure routing for.
    /// </param>
    public override void ConfigureRouting(WebApplication app)
    {
        _ = app.UseRouting();

        // Call the base function.
        base.ConfigureRouting(app);
    }

    /// <summary>
    /// Configures authorization for the ASP.NET Core application.
    /// </summary>
    /// <param name="app">
    /// The <see cref="WebApplication"/> to configure authorization for.
    /// </param>
    public override void ConfigureAuthorization(WebApplication app)
    {
        _ = app.UseAuthorization();

        // Call the base function.
        base.ConfigureAuthorization(app);
    }

    /// <summary>
    /// Maps routes for the ASP.NET Core application.
    /// </summary>
    /// <param name="app">
    /// The <see cref="WebApplication"/> to map routes for.
    /// </param>
    public override void MapRoutes(WebApplication app)
    {
        _ = app.MapControllerRoute(name: "default",
                                   pattern: "{area=Home}/{controller=Home}/{action=Index}/{id?}");

        // Call the base function.
        base.MapRoutes(app);
    }
}
