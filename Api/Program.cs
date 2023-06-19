using Api.Startup;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.RegisterApplicationServices(configuration);

var app = builder.Build();
app.ConfigureMiddleware();


app.Run();
