using asp_Servicios;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder, builder.Services); //Aqui sale un error asociado al controller

var app = builder.Build();
startup.Configure(app, app.Environment);
app.MapGet("/", () => "asp_servicios"); //Agregado, necesario para que encuentre la "KEY" o algo asi
app.Run();
