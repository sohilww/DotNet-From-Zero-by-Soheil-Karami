---
title: REST
---

Why it exists, what it solves.

## REST — the problem it solves (and how APIs looked before it)

Before REST was popular, two common ways to build APIs were:

- **Ad-hoc RPC-style endpoints** (custom URLs & verbs):  
  `/CreateProduct`, `/UpdateProduct`, `/DeleteProductById` – each one with its own payload format and error handling.

  - ❌ Ambiguous semantics (which status code is “success”? 200? 202?)
  - ❌ Tight coupling between client & server (custom shapes, brittle contracts)
  - ❌ Hard to cache, hard to scale, hard to document consistently

- **SOAP/XML-RPC** (formal but heavy):
  - ✅ Strong tooling and contracts (WSDL)
  - ❌ Verbose payloads (XML), complex standards, harder to consume on the web, limited cache-friendliness

**REST** (Representational State Transfer) addressed these problems by using the **web’s native primitives**:

- **Resources** modeled as **nouns** (e.g., `/products`), not actions.
- Standard **HTTP methods** (GET, POST, PUT, PATCH, DELETE) to express intent.
- Meaningful **HTTP status codes** to signal results uniformly.
- **Stateless** requests and cache-friendly design.
- Uniform interface → simpler, consistent, evolvable APIs.

Result: **loose coupling**, **predictability**, **interoperability**, and **scalability**.

---

## 🔹REST essentials (quick principles)

- **Resource-oriented**: `/products`, `/products/{id}`
- **Stateless**: each request carries enough info to be processed
- **Uniform interface**: standard verbs, media types (JSON), status codes
- **Cacheable**: leverage HTTP caching when applicable
- **Layered system**: proxies, gateways, CDNs can sit in the middle

---

## 🔹HTTP methods (CRUD mapping) and typical status codes

| Method | Intent                      | Typical success codes               | Notes                                         |
| ------ | --------------------------- | ----------------------------------- | --------------------------------------------- |
| GET    | Read a resource/collection  | `200 OK` (body)                     | Must not change server state                  |
| POST   | Create a new resource       | `201 Created` + `Location` header   | Body usually returns the created resource     |
| PUT    | Replace a resource entirely | `200 OK` (body) or `204 No Content` | Idempotent (same call → same result)          |
| PATCH  | Partially update a resource | `200 OK` or `204 No Content`        | Not necessarily idempotent; send only changes |
| DELETE | Remove a resource           | `204 No Content`                    | Idempotent (repeat is safe)                   |

**Common error codes**

- `400 Bad Request` (malformed input), `401 Unauthorized`, `403 Forbidden`, `404 Not Found`, `409 Conflict` (constraint clash), `422 Unprocessable Entity` (validation), `500`/`503` (server side)

---

## 🔹Anti-patterns to avoid

- ❌ Verb-based URLs: `/createProduct`, `/deleteProduct?id=1`
- ❌ Always returning `200 OK` for everything
- ❌ Mixing transport errors with domain errors (e.g., using 500 for validation)
- ❌ Hiding newly created resource URL (forgetting the `Location` header on `201 Created`)
  > ⚠️ **Guilty confession:** I have to admit that I’m often guilty of returning `201 Created` without including the `Location` header for the newly created resource.

---

## 🔹End-to-end example: Product REST API (all verbs + status codes)

**Goal:** Show a clean, idiomatic ASP.NET Core Web API for `/products`.

> ⚠️ **Note:** The design you see here (such as calling repository logic directly inside the controller or mixing models and DTOs in the same layer) is **only for teaching simplicity**. In real-world projects this is not a good practice and should be avoided.

### 1) Domain model & DTOs

```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;
}

public class CreateProductDto
{
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
}

public class UpdateProductDto   // for PUT (full update)
{
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
}

public class PatchProductDto    // for PATCH (partial update)
{
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public bool? IsActive { get; set; }
}
```

### 2) Repository abstraction (to keep controller thin)

```csharp
public interface IProductRepository
{
    Task<List<Product>> GetAllAsync(CancellationToken ct = default);
    Task<Product?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Product> AddAsync(Product product, CancellationToken ct = default);
    Task<bool> UpdateAsync(Product product, CancellationToken ct = default);
    Task<bool> DeleteAsync(int id, CancellationToken ct = default);
}
```

> For the session demo, an in-memory implementation is enough. Later you’ll swap it with EF Core.

```csharp
public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _store = new();
    private int _nextId = 1;

    public Task<List<Product>> GetAllAsync(CancellationToken ct = default)
        => Task.FromResult(_store.ToList());

    public Task<Product?> GetByIdAsync(int id, CancellationToken ct = default)
        => Task.FromResult(_store.FirstOrDefault(p => p.Id == id));

    public Task<Product> AddAsync(Product product, CancellationToken ct = default)
    {
        product.Id = _nextId++;
        _store.Add(product);
        return Task.FromResult(product);
    }

    public Task<bool> UpdateAsync(Product product, CancellationToken ct = default)
    {
        var idx = _store.FindIndex(p => p.Id == product.Id);
        if (idx < 0) return Task.FromResult(false);
        _store[idx] = product;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(int id, CancellationToken ct = default)
    {
        var p = _store.FirstOrDefault(x => x.Id == id);
        if (p is null) return Task.FromResult(false);
        _store.Remove(p);
        return Task.FromResult(true);
    }
}
```

### 3) Registration (DI) in Program.cs

```csharp
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
```

### 4) Controller with full REST semantics

```csharp
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("products")]
public  class ProductsController : ControllerBase
{
    private readonly IProductRepository _repo;

    public ProductsController(IProductRepository repo)
    {
        _repo = repo;
    }

    // GET /products  → 200 OK (list)
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll(CancellationToken ct)
    {
        var items = await _repo.GetAllAsync(ct);
        return Ok(items); // 200
    }

    // GET /products/{id} → 200 OK or 404 Not Found
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(int id, CancellationToken ct)
    {
        var item = await _repo.GetByIdAsync(id, ct);
        if (item is null) return NotFound(); // 404
        return Ok(item); // 200
    }

    // POST /products → 201 Created + Location header
    [HttpPost]
    public async Task<ActionResult<Product>> Create([FromBody] CreateProductDto dto, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(dto.Name) || dto.Price < 0)
            return BadRequest(new { message = "Name is required and Price must be non-negative." }); // 400

        var product = new Product { Name = dto.Name.Trim(), Price = dto.Price, IsActive = true };
        var created = await _repo.AddAsync(product, ct);

        // Returns 201, sets Location: /products/{id}, and body contains the resource
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT /products/{id} → 200 OK (body) or 204 No Content, 404 if not found
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Replace(int id, [FromBody] UpdateProductDto dto, CancellationToken ct)
    {
        var existing = await _repo.GetByIdAsync(id, ct);
        if (existing is null) return NotFound(); // 404

        if (string.IsNullOrWhiteSpace(dto.Name) || dto.Price < 0)
            return BadRequest(new { message = "Name is required and Price must be non-negative." }); // 400

        existing.Name = dto.Name.Trim();
        existing.Price = dto.Price;
        existing.IsActive = dto.IsActive;

        var ok = await _repo.UpdateAsync(existing, ct);
        if (!ok) return NotFound(); // race or missing

        // choose either Ok(existing) or NoContent(). Here we return the updated entity:
        return Ok(existing); // 200
    }

    // PATCH /products/{id} → 200/204, 404 if not found
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, [FromBody] PatchProductDto dto, CancellationToken ct)
    {
        var existing = await _repo.GetByIdAsync(id, ct);
        if (existing is null) return NotFound(); // 404

        if (dto.Name is not null)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest(new { message = "Name cannot be empty." }); // 400
            existing.Name = dto.Name.Trim();
        }

        if (dto.Price is not null)
        {
            if (dto.Price < 0) return BadRequest(new { message = "Price must be non-negative." });
            existing.Price = dto.Price.Value;
        }

        if (dto.IsActive is not null)
            existing.IsActive = dto.IsActive.Value;

        var ok = await _repo.UpdateAsync(existing, ct);
        if (!ok) return NotFound();

        return Ok(existing); // or NoContent()
    }

    // DELETE /products/{id} → 204 No Content, 404 if not found
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var deleted = await _repo.DeleteAsync(id, ct);
        if (!deleted) return NotFound(); // 404
        return NoContent(); // 204
    }
}
```

**Why these choices?**

- **POST → 201 Created + Location**: client learns where the new resource lives.
- **GET/PUT/PATCH/DELETE** use **resource URLs** (`/products/{id}`) and standard codes.
- **BadRequest (400)** only for malformed/invalid input; **NotFound (404)** for missing resource.
- **NoContent (204)** for successful operations with no body (DELETE).
- **Idempotency**: `PUT` & `DELETE` are safe to repeat; `POST` creates once; `PATCH` is partial.

---

🟨 **Questions for students**

- Why is returning `201 Created` with a `Location` header better than `200 OK` for POST?
- In what cases would you choose `PUT` vs `PATCH`? Give concrete examples.
- Which status code fits validation failures best in your API: `400` or `422`? Why?

---

🟦 **Practice**

- Create `Category` endpoints mirroring `Product` semantics (full CRUD, proper status codes).
- Add simple validation rules and make sure wrong inputs return `400` with helpful messages.
- Extend `GET /products` with optional `?search`, `?minPrice`, `?maxPrice` query parameters and keep responses RESTful.
- Try idempotency: call `PUT` and `DELETE` multiple times and observe behavior.

---
