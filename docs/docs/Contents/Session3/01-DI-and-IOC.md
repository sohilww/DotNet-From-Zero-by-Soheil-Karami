---
title: Dependency Injection (DI) and Inversion of Control (IoC)
---

## Dependency Injection (DI) and Inversion of Control (IoC)

### What is a dependency?

In software development, a **dependency** is any object that another class needs to function.  
For example, a `ProductService` might need access to a `ProductRepository` to fetch data from the database.

If the service **creates** the repository directly, the classes become **tightly coupled**. This leads to:

- ❌ Hard to test (you cannot replace it with a mock easily)
- ❌ Hard to maintain (any change in repository requires changes in service)
- ❌ Hard to extend (adding logging, caching, or monitoring becomes painful)

---

### 🔹Inversion of Control (IoC)

By default, classes are in control of creating their own dependencies:

```csharp
public class ProductService
{
    private readonly ProductRepository _repository;

    public ProductService()
    {
        _repository = new ProductRepository(); // tightly coupled
    }
}
```

Here, the `ProductService` **decides** how to create the repository.  
**Inversion of Control (IoC)** means we _invert this control_:

- The class no longer creates its dependency.
- Instead, the dependency is **provided from outside** (injected).

---

### 🔹 Dependency Injection (DI)

**Dependency Injection (DI)** is the most common way to achieve IoC.  
Instead of constructing the dependency, we receive it through the constructor:

```csharp
public class ProductService
{
    private readonly IProductRepository _repository;

    // Dependency is injected via constructor
    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public void PrintProductName(int id)
    {
        var product = _repository.GetById(id);
        Console.WriteLine(product.Name);
    }
}
```

Now the `ProductService` does not care **how** the repository is created.  
We can inject a real repository, a fake one, or a mock — depending on the context.

---

### 🔹 IoC Container in .NET

ASP.NET Core provides a built-in **IoC Container** that manages dependencies for us.  
We register services inside `Program.cs` (or `Startup.cs` in older projects):

```csharp
var builder = WebApplication.CreateBuilder(args);

// Register dependencies
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

// Resolve dependency automatically when creating controller
app.MapGet("/products/{id}", (int id, ProductService service) =>
{
    service.PrintProductName(id);
    return Results.Ok();
});

app.Run();
```

---

### 🔹 Service Lifetimes

When registering services, we must choose their **lifetime**:

- **Transient**: a new instance every time it is requested.  
  Example: `builder.Services.AddTransient<IService, Service>();`
- **Scoped**: one instance per HTTP request (most common for web apps).  
  Example: `builder.Services.AddScoped<IService, Service>();`
- **Singleton**: one instance for the entire application lifetime.  
  Example: `builder.Services.AddSingleton<IService, Service>();`

---

🟨 **Questions for students**

- Why is tight coupling a problem in software design?
- What is the difference between IoC and DI?
- Which service lifetime would you use for a database context? Why?

---

🟦 **Practice**

- Refactor a class that creates its own dependencies into one that uses constructor injection.
- Register the dependency in the ASP.NET Core IoC container and resolve it in a controller.
- Experiment with different lifetimes (Transient, Scoped, Singleton) and observe the behavior.

---
