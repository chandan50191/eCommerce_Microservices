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

3. What are the benefits of using the Repository pattern in a Clean Architecture?
4. How does the Repository pattern enhance testability in a .NET Core application?
5. What is Postman, and how is it used in API testing?
6. Explain the role of AutoMapper in an ASP.NET Core project.
7. How would you configure and use AutoMapper in ASP.NET Core?
8. How can you connect to a Postgres database using Dapper in ASP.NET Core?
9. What is the difference between Dapper’s ExecuteAsync and QueryAsync methods?
10. What is FluentValidation, and how does it integrate with ASP.NET Core?
11. How do you create a custom validator using FluentValidation?

# Questions for assignment : 6

12. What are some common use cases for FluentValidation in an ASP.NET Core project?
13. What are some basic Git commands every developer should know?
14. What is Swagger, and how does it benefit API development?
15. How do you add Swagger to an ASP.NET Core project?
16. How can Swagger be used to test API endpoints?