using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure services
builder.Services.AddInfrastructure(); 

// Add Core services
builder.Services.AddCore();

// Add Controllers
builder.Services.AddControllers();

// Build the web application
var app = builder.Build();

// Add exception handling middelware
app.UseExceptionHandlingMiddleware();

// Enable Routing
app.UseRouting();

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Controllers routes
app.MapControllers();

app.Run();
