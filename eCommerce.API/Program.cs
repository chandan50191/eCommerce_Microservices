using eCommerce.Infrastructure;
using eCommerce.Core;
var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure services
builder.Services.AddInfrastructure(); 

// Add Core services
builder.Services.AddCore();

// Add Controllers
builder.Services.AddControllers();

// Build the web application
var app = builder.Build();

// Enable Routing
app.UseRouting();

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Controllers routes
app.MapControllers();

app.Run();
