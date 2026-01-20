using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using FluentValidation.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure services
builder.Services.AddInfrastructure(); 

// Add Core services
builder.Services.AddCore();

// Add Controllers
builder.Services.AddControllers().AddJsonOptions(options =>
{
 options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());   
});

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

// Fluent Validation
builder.Services.AddFluentValidationAutoValidation();

// Add API explorer services
builder.Services.AddEndpointsApiExplorer();

// Add swagger generation services to create swagger specification
builder.Services.AddSwaggerGen();

// Add Cors services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});


// Build the web application
var app = builder.Build();

// Add exception handling middelware
app.UseExceptionHandlingMiddleware();

// Enable Routing
app.UseRouting();

// Add Endpoint that can server the swagger.json
app.UseSwagger();

// Add swagger UI (Interactive page to explore and test API endpoints)
app.UseSwaggerUI();

// Add Cors
app.UseCors();

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Controllers routes
app.MapControllers();


app.Run();
