---
title: Consistent Responses, Middleware, AOP, and API Testing
---

### 🔹 Consistent Response Structure with ApiResponse

In APIs, consistency in response format helps clients consume data more easily. Instead of returning raw objects or strings, you can define a standard response wrapper.

**Benefits of a consistent response format**

- Easier error handling on the client side.
- Predictable structure for success and failure responses.
- Easier debugging and logging.

**Common ApiResponse design**

- success: indicates whether the request was successful.
- message: human-readable information.
- data: actual response data.
- errors: optional details about validation or exceptions.

```csharp
public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public object Errors { get; set; }

    public static ApiResponse<T> SuccessResponse(T data, string message = "")
        => new ApiResponse<T> { Success = true, Data = data, Message = message };

    public static ApiResponse<T> FailureResponse(string message, object errors = null)
        => new ApiResponse<T> { Success = false, Message = message, Errors = errors };
}
```

🟨 Questions for students

- Why is it beneficial to standardize API responses?
- How would you extend ApiResponse to include pagination info?

---

🟦 Practice

- Modify an existing controller action to return ApiResponse<T> instead of raw data.
- Send a request in Postman and inspect the consistent response structure.

---

### 🔹 Middleware for Logging and Error Handling

**What is Middleware?**  
Middleware components are executed in sequence during the request pipeline. They can inspect, modify, or short-circuit requests and responses.

**Logging Middleware**

- Logs incoming requests and outgoing responses.
- Helps in monitoring and debugging.

**Error Handling Middleware**

- Catches unhandled exceptions.
- Returns a structured error response (e.g., with ApiResponse).
- Prevents leaking stack traces to clients.

```csharp
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            var response = ApiResponse<string>.FailureResponse("An error occurred", ex.Message);
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}

// In Program.cs
app.UseMiddleware<ErrorHandlingMiddleware>();
```

🟨 Questions for students

- Why is centralized error handling important?
- How does logging middleware help in debugging production issues?

---

🟦 Practice

- Add a logging middleware that records request method and path.
- Trigger an exception in a controller and verify the structured error response.

---

### 🔹 Intro to AOP via Action Filters and Decorators

Aspect-Oriented Programming (AOP) allows you to separate cross-cutting concerns (e.g., logging, caching, validation) from business logic.

**Action Filters**

- Run code before and after controller actions.
- Useful for logging, validation, authorization, or response modification.

**Decorators**

- Pattern to wrap logic around methods or services.
- Can be used for caching, retry policies, or additional checks.

**Example: Logging Action Filter**

```csharp
public class LogActionFilter : IActionFilter
{
    private readonly ILogger<LogActionFilter> _logger;

    public LogActionFilter(ILogger<LogActionFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation($"Executing action {context.ActionDescriptor.DisplayName}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation($"Executed action {context.ActionDescriptor.DisplayName}");
    }
}

// In Program.cs
builder.Services.AddControllers(options =>
{
    options.Filters.Add<LogActionFilter>();
});
```

🟨 Questions for students

- What are some examples of cross-cutting concerns?
- When would you choose an Action Filter over middleware?

---

🟦 Practice

- Create a custom action filter that validates if a query parameter apiKey is present.
- Apply the filter globally and test it using Postman.

---

### 🔹 Testing APIs with Postman

**Why Postman?**

- GUI tool for sending HTTP requests.
- Useful for testing APIs without writing client code.
- Supports saving collections, adding tests, and sharing with team members.

**Basic workflow**

1. Install Postman and create a new request.
2. Set the HTTP method (GET, POST, PUT, DELETE).
3. Provide the URL (e.g., https://localhost:5001/api/products).
4. Add headers (e.g., Content-Type: application/json).
5. Send the request and inspect the response.

**Example: Testing POST with JSON body**

```csharp
// POST /api/products
// Content-Type: application/json
{
  "id": 1,
  "name": "Laptop"
}
```

🟨 Questions for students

- Why is Postman useful in API development?
- How can collections in Postman improve team collaboration?

---

🟦 Practice

- Create a collection in Postman for your API project.
- Add requests for GET, POST, PUT, DELETE endpoints of the Products API.
