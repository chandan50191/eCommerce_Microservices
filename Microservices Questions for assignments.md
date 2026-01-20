# Questions for assignment : 5

1. What is Clean Architecture, and how does it help maintainability in large-scale systems?
Ans1. => a. Clean Architecture is a way of structuring your solution so that business logic is independent of frameworks, databases, UI, and external services.
b. Clean Architecture in .NET separates business logic from frameworks using inward dependencies, which improves maintainability, testability, and scalability in large systems.
c. Clean Architecture Improves Maintainability by protecting business logic like Framework changes don’t break core logic, Migrate from EF Core → Dapper → MongoDB (possible), Web API → gRPC → Background worker (possible).
d. Clean Architecture Easier to Modify & Extend, we can add New features = new use cases also Existing logic remains untouched.

2. What are the four layers in Clean Architecture, and how are dependencies managed between them?
Ans2. =>  a.The Four Layers of Clean Architecture are Domain,Application,Infrastructure and Presentation layer.
b. Domain Layer (Core / Enterprise Business Rules) contains Entities, Value objects, Domain Services, Business rules & invariants and It does not depend on any frameworks or libraries.
c. Application Layer contains Use cases like Commands / Queries, Application services, Interfaces (repositories, unit of work) and DTOs. It depends on domail layer only. 
d. Infrastructure Layer contains EF Core / Dapper, Database context, Repository implementations, Email, file system, cache, external APIs.It depends on Application layer, Domain layer.
f. Presentation Layer contains ASP.NET Core controllers, gRPC endpoints, MVC / Razor / Blazor UI, Request/response models. It depends on Application layer only.

3. What are the benefits of using the Repository pattern in a Clean Architecture?
Ans3. => The Repository pattern in Clean Architecture decouples business logic from data access, enforces dependency inversion, improves testability, and allows infrastructure to change without impacting core logic.

4. How does the Repository pattern enhance testability in a .NET Core application?
Ans4. => The Repository pattern enhances testability by abstracting data access behind interfaces, allowing business logic to be unit tested using mocks or in-memory implementations without relying on databases or EF Core.

5. What is Postman, and how is it used in API testing?
Ans5 => Postman is a popular tool used to test and interact with APIs. It allows developers to send HTTP requests (GET, POST, PUT, DELETE) and view responses easily. Postman is used to validate API functionality, test request headers, parameters, authentication, and response data. It also supports automated tests, environment variables, and collections, making API development, debugging, and testing faster and more reliable.

6. Explain the role of AutoMapper in an ASP.NET Core project.
Ans6. => AutoMapper is a library used in ASP.NET Core to automatically map data between objects, such as Domain models, DTOs, and ViewModels. It reduces repetitive manual mapping code, improves readability, and ensures consistent data transformation across the application. AutoMapper helps keep controllers and services clean by separating mapping logic from business logic.

7. How would you configure and use AutoMapper in ASP.NET Core?
And7. => a. dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
b. Create a mapping profile
```c#
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
    }
}
```
c. Register AutoMapper in Program.cs
```C#
    builder.Services.AddAutoMapper(typeof(UserProfile));
```
d. Use AutoMapper via DI
```C#
    public class UsersController
{
    private readonly IMapper _mapper;

    public UsersController(IMapper mapper)
    {
        _mapper = mapper;
    }

    public UserDto Get(User user)
        => _mapper.Map<UserDto>(user);
}
```

8. How can you connect to a Postgres database using Dapper in ASP.NET Core?
Ans8. => 
a. Install packages
```C#
    dotnet add package Dapper
    dotnet add package Npgsql
```
a. Add connection string in appsettings.json
```C#
    "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Port=5432;Database=MyDb;Username=postgres;Password=pass"
    }

```
a. Create a connection
```C#
    using Npgsql;
    using System.Data;

    IDbConnection db = new NpgsqlConnection(
        builder.Configuration.GetConnectionString("DefaultConnection"));
```
a. Use Dapper
```C#
    var users = await db.QueryAsync<User>(
    "SELECT * FROM users WHERE is_active = true");
```
9. What is the difference between Dapper’s ExecuteAsync and QueryAsync methods?
ExecuteAsync => 
Used for commands that do not return result sets, such as INSERT, UPDATE, or DELETE.
It returns the number of rows affected.
QueryAsync<T> => 
Used for commands that return data, such as SELECT queries.
It maps the result set to objects of type T and returns them as a collection.

10. What is FluentValidation, and how does it integrate with ASP.NET Core?
Ans10. => FluentValidation is a popular .NET library used to define validation rules using a fluent, strongly-typed API instead of data annotations. It keeps validation logic clean, testable, and separate from models.
Steps to integrate 
1. Install packages:
```C#
    dotnet add package FluentValidation
    dotnet add package FluentValidation.AspNetCore
```
2. Create a validator:
```C#
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
```
3. Register FluentValidation:
```C#
    builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();
```
11. How do you create a custom validator using FluentValidation?
1. Create a validator class by inheriting from AbstractValidator<T>:
```c#
public class UserValidator : AbstractValidator<UserDto>
{
    public UserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Age)
            .GreaterThan(18);
    }
}
```
2. Register the validator:
```js
    builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

```
# Questions for assignment : 6

12. What are some common use cases for FluentValidation in an ASP.NET Core project?
Common use cases for FluentValidation in an ASP.NET Core project include:
1. Validating API request DTOs (required fields, formats, ranges)
2. Enforcing business rules (age limits, password strength, uniqueness checks)
3. Replacing Data Annotations for cleaner, testable validation logic
4. Validating command/query models in CQRS
5. Centralizing validation instead of duplicating checks in controllers
6. Providing consistent validation error responses across APIs
7. FluentValidation keeps validation logic readable, reusable, and easy to maintain.

13. What are some basic Git commands every developer should know?
Some basic Git commands every developer should know are:
- git init – Initialize a new repository
- git clone – Copy a remote repository
- git status – Check file changes
- git add – Stage changes
- git commit – Save changes with a message
- git pull – Fetch and merge updates
- git push – Upload commits to remote
- git branch – Manage branches
- git checkout / git switch – Change branches
- git merge – Combine branches
- git log – View commit history

14. What is Swagger, and how does it benefit API development?
Swagger (OpenAPI) is a toolset for documenting, designing, and testing REST APIs. It automatically generates interactive API documentation from code, allowing developers to explore endpoints, request/response models, and try APIs in the browser.
It helps up to write: 
- Clear, up-to-date API documentation
- Faster frontend–backend collaboration
- Easy API testing and debugging
- Improved API consistency and maintainability

15. How do you add Swagger to an ASP.NET Core project?
- Install NuGet Package
```js
    dotnet add package Swashbuckle.AspNetCore
```
- Register Swagger Services in Program.cs
```js
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
```
- Enable Middleware
```js
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = string.Empty;
        });
    }
```
16. How can Swagger be used to test API endpoints?
Swagger provides an interactive UI to test API endpoints directly from the browser. In ASP.NET Core, once Swagger is enabled, you can navigate to /swagger to see all endpoints, their HTTP methods, parameters, and request/response schemas. You can select an endpoint, click “Try it out”, fill in query parameters or JSON request bodies, and execute the request. Swagger then displays the response status, headers, and body, making it easy to validate API behavior, debug issues, and test endpoints without external tools. It streamlines manual API testing during development and ensures endpoints behave as expected.