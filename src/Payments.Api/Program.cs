var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var configurationBuilder = new ConfigurationBuilder()
              .SetBasePath(AppContext.BaseDirectory)
              .AddJsonFile($"appsettings.json", optional: false)
              .AddEnvironmentVariables();

IConfiguration configuration = configurationBuilder.Build();

services.Configure(configuration);

var app = builder.Build();

app.Configure();

app.Run();
