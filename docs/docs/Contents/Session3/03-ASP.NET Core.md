---
title: ASP.NET Core Web API and Request Life Cycle
---

### 🔹 Web API Core vs Web API (Old)

ASP.NET Web API (old, on .NET Framework) and ASP.NET Core Web API are both frameworks for building HTTP services, but they are different in architecture and capabilities.

Key differences:

- **Cross-platform**: ASP.NET Core runs on Windows, Linux, and macOS, while old Web API was Windows-only.
- **Unified model**: In Core, Web API and MVC are merged into one framework.
- **Middleware-based pipeline**: Core is fully modular and request processing is built on a middleware pipeline.
- **Built-in Dependency Injection**: ASP.NET Core provides DI out of the box, unlike old Web API.
- **Performance**: ASP.NET Core is faster and lighter due to its redesigned runtime.

🟨 Questions for students

- What are the main advantages of ASP.NET Core Web API compared to old Web API?
- Why do you think Microsoft decided to unify MVC and Web API in ASP.NET Core?

---

🟦 Practice

- Create a new ASP.NET Core Web API project using the `dotnet new webapi` command.
- Inspect the project structure and compare it with an old Web API (if available).

---

### 🔹 Web Servers in ASP.NET Core

A web server is responsible for listening to HTTP requests and forwarding them to the application. ASP.NET Core uses **Kestrel** as its default web server.

**Kestrel Server**

- Default web server for ASP.NET Core applications.
- Cross-platform, lightweight, and very fast.
- Built-in and requires no external installation.
- Optimized for asynchronous I/O operations.

**Why Kestrel?**

- High performance compared to IIS or System.Web.
- Simplicity: can run as a standalone server during development.
- Flexibility: integrates well with reverse proxies.

**Alternatives / Reverse Proxy setups**

- **IIS (Windows)**: Often used in production together with Kestrel.
- **Nginx (Linux)**: Used as a reverse proxy to provide SSL termination, load balancing, and extra security.
- **Apache (Linux)**: Another common reverse proxy option.

**Production setup**

- Development: Kestrel alone is usually enough.
- Production: Kestrel + Reverse Proxy (IIS, Nginx, or Apache) for better security, stability, and scalability.

🟨 Questions for students

- Why is Kestrel often combined with IIS or Nginx in production?
- What advantages does a reverse proxy add in front of Kestrel?

---

🟦 Practice

- Run a Web API project directly with `dotnet run` (Kestrel).
- Configure the same project to run behind IIS or Nginx and compare the behavior.

---

### 🔹 Request Life Cycle in ASP.NET Core Web API

Understanding the request life cycle helps developers know how a request flows through the system.

**Steps of the request life cycle:**

1. **Kestrel receives the HTTP request**.
2. The request enters the **Middleware Pipeline**. Each middleware can handle, modify, or short-circuit the request.
   - Examples: Authentication, Logging, Exception Handling.
3. **Routing Middleware** selects the appropriate controller and action.
4. **Model Binding and Validation** occurs, mapping HTTP request data to .NET objects.
5. **Filters (Action Filters, Authorization Filters)** can execute before or after the controller action.
6. The **Controller Action** executes application logic.
7. The result is returned, usually as JSON, through **Formatters**.
8. The response passes back through middleware and is sent by Kestrel to the client.

**Simplified diagram:**

`Request → Kestrel → Middleware → Routing → Controller → Action → Response`

🟨 Questions for students

- What role does middleware play in the request life cycle?
- At what stage does Model Binding occur?
- Why is understanding the request pipeline important when debugging?

---

🟦 Practice

- Add a simple custom middleware that logs every request path.
- Inspect how the middleware is executed before the controller action.

```csharp
public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
        await _next(context);
    }
}

// In Program.cs
app.UseMiddleware<LoggingMiddleware>();
```
