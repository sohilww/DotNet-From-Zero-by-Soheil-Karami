---
title: API Routing, Model Binding, and Validation
---

### 🔹 API Routing

Routing is the process of mapping incoming HTTP requests to the appropriate controller action. In ASP.NET Core, routing is primarily **attribute-based**, which provides more flexibility compared to the old conventional routing.

**Types of Routing**

- **Conventional Routing**: Defined in `Program.cs` with a route pattern.
- **Attribute Routing**: Defined directly on controllers and actions using attributes.

**Route templates**

- `[Route("api/[controller]")]` maps the route based on controller name.
- `[HttpGet("{id}")]` maps to a GET request with an `id` parameter.

**Route constraints**

- Add restrictions to route parameters:
  - `{id:int}` → only matches integers.
  - `{slug:alpha}` → only matches alphabetic characters.
  - `{date:datetime}` → only matches valid DateTime values.

🟨 Questions for students

- How do route constraints help improve API design?
- What is the difference between conventional and attribute routing?

---

🟦 Practice

- Create a controller with a GET endpoint at `/api/products`.
- Add another GET endpoint that accepts an `id:int` parameter.
- Test both endpoints in Postman or a browser.

### 🔹 Conventional vs Attribute Routing

**Conventional Routing**

- Defined centrally in `Program.cs` (or `Startup.cs` in older versions).
- Uses a route template with placeholders, e.g. `"api/{controller}/{action}/{id?}"`.
- Good for scenarios where routes follow a consistent pattern.
- Less flexible because all controllers/actions must follow the global pattern.

**Attribute Routing**

- Defined directly on controllers and actions using attributes such as `[Route]`, `[HttpGet]`, `[HttpPost]`.
- Allows precise control of each endpoint’s URL.
- Commonly used in RESTful APIs because it matches the resource-based style.
- Makes routes self-documenting, since the route is next to the action code.

**Key differences**

- **Location**: Conventional is centralized; Attribute is on controllers/actions.
- **Flexibility**: Conventional requires pattern adherence; Attribute gives fine-grained control.
- **Readability**: Attribute routing makes endpoints easier to discover.
- **Use case**: Conventional works well for MVC apps; Attribute is the standard for Web APIs.

🟨 Questions for students

- Why is attribute routing generally preferred in Web APIs?
- In what scenario could conventional routing still be useful?

---

🟦 Practice

- Define a conventional route in `Program.cs` with the pattern `"api/{controller}/{action}/{id?}"`.
- Add an attribute route to a controller action and compare the two approaches.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Conventional route
app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action}/{id?}");

app.Run();
```

```csharp
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet("{id:int}")]
    public IActionResult GetUser(int id)
    {
        return Ok($"User with id {id}");
    }
}
```

---

```csharp
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(new[] { "Product1", "Product2" });

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id) => Ok($"Product with id {id}");
}
```

---

### 🔹 Model Binding

Model Binding is the process of converting HTTP request data into .NET objects. ASP.NET Core can automatically bind data from different sources such as query strings, route values, and the request body.

**Sources of binding**

- **FromQuery**: Extracts data from query string parameters.
- **FromRoute**: Extracts data from route parameters.
- **FromBody**: Extracts data from the request body (usually JSON).

**Simple vs Complex types**

- Simple types (int, string, bool) can be bound from query or route by default.
- Complex types (classes) are usually bound from the request body.

🟨 Questions for students

- How does ASP.NET Core decide whether to bind data from query, route, or body?
- Why are complex objects usually bound from the request body?

---

🟦 Practice

- Add a POST endpoint that accepts a JSON object representing a product.
- Use `[FromQuery]` to bind a filter parameter in a GET request.

```csharp
public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] ProductDto product)
    {
        return Ok($"Created product: {product.Name}");
    }

    [HttpGet("filter")]
    public IActionResult Filter([FromQuery] string name)
    {
        return Ok($"Filtering products by name: {name}");
    }
}
```

---

### 🔹 Validation

Validation ensures that incoming data meets expected rules before it reaches business logic. ASP.NET Core automatically validates models when the `[ApiController]` attribute is applied.

**Data Annotations**

- `[Required]` → property must have a value.
- `[StringLength(50)]` → string length must be within range.
- `[Range(1, 100)]` → numeric value must be within range.

**Automatic validation**

- If a model fails validation, ASP.NET Core returns `400 Bad Request` automatically with error details when `[ApiController]` is used.

**Custom validation**

- Create a class that inherits from `ValidationAttribute` to implement custom rules.

🟨 Questions for students

- What happens if a required property is missing in a request body?
- How does the `[ApiController]` attribute change validation behavior?

---

🟦 Practice

- Add validation attributes to the `ProductDto` model (`Name` is required, `Id` must be > 0).
- Test sending invalid requests in Postman and check the automatic error responses.

```csharp
public class ProductDto
{
    [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    public string Name { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] ProductDto product)
    {
        return Ok($"Created product: {product.Name}");
    }
}
```
