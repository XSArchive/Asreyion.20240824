using Asreyion.Framework.Modules;
using Asreyion.Framework.Themes;

ModuleManager moduleManager = new ModuleManager().Discover() as ModuleManager ?? throw new NullReferenceException();
ThemeManager themeManager = new ThemeManager().Discover() as ThemeManager ?? throw new NullReferenceException();

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

_ = moduleManager.Execute((module, builder) => module.RegisterControllers(builder), builder);

WebApplication app = builder.Build();

_ = moduleManager.Execute((module, app) => module.ConfigureEnvironment(app), app);

_ = moduleManager.Execute((module, app) => module.ConfigureHttps(app), app);

_ = moduleManager.Execute((module, app) => module.ConfigureFiles(app), app);

_ = moduleManager.Execute((module, app) => module.ConfigureRouting(app), app);

_ = moduleManager.Execute((module, app) => module.ConfigureAuthorization(app), app);

_ = moduleManager.Execute((module, app) => module.MapRoutes(app), app);

app.Run();
