---
title: High‑Level Architecture
---

> **Important:** The code snippets below are intentionally simplified.  
> They are **not perfect designs**; they exist only to illustrate concepts.  
> As the course progresses, we will refactor and harden them into production‑ready patterns.

# High‑Level Architecture

Designing a real‑world .NET application is **more than “where do I put my files?”**  
A clear architectural boundary:

- **Separates concerns** – each layer owns one clear job.
- **Accelerates change** – teams work in parallel.
- **Improves testability** – pure logic is isolated from I/O.

We’ll use a **four‑layer architecture** diagram—crafted by Soheil purely for teaching purposes (not a production recommendation)—to make architectural boundaries easy to understand.(inspired by Clean Architecture and Union Architecture but simplified for beginners).

---

## 🔹 Domain Layer — _The Heart_

> **Purpose:** Hold core business rules, invariants, and ubiquitous language.  
> **Key idea:** “No framework talk allowed here.”

### Responsibilities

| Item                | Example                        |
| ------------------- | ------------------------------ |
| **Entities**        | `Order`, `Customer`, `Product` |
| **Value Objects**   | `Money`, `Email`, `Address`    |
| **Domain Services** | `PricingService`, `TaxPolicy`  |
| **Business Events** | `OrderPlaced`, `PaymentFailed` |

```csharp
// Value Object: immutable & self‑validating
public class Email
{
    public string Value { get; }

    private Email(string value) => Value = value;

    public static Email Create(string value)
    {
        if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("Invalid email");
        return new Email(value);
    }
}
```

🟨 **Questions for students**

- Why shouldn’t `Email` know anything about Entity Framework or HTTP?
- What makes a Value Object different from an Entity?

---

🟦 **Practice**

- Implement a `Money` value object with `Amount` + `Currency`.
- Add validation so mismatched currencies can’t be added.

---

## 🔹 Application Layer — _The Brains_

> **Purpose:** Coordinate use‑cases, orchestrate domain objects, enforce transactions.

### Typical Artifacts

| Concept            | Description                              |
| ------------------ | ---------------------------------------- |
| **Commands**       | Verb + DTO intent (`PlaceOrderCommand`)  |
| **Queries**        | Read‑only requests (`GetOrderByIdQuery`) |
| **Handlers**       | Execute a command/query                  |
| **DTOs / Mappers** | Shape data for API/UI, not for EF        |

```csharp
public class PlaceOrderCommand
{
    public int     OrderId { get; }
    public decimal Price   { get; }

    public PlaceOrderCommand(int orderId, decimal price)
    {
        OrderId = orderId;
        Price   = price;
    }
}

public class PlaceOrderHandler
{
    private readonly IUnitOfWork uow;
    private readonly IOrderRepository repo;

    public PlaceOrderHandler(IUnitOfWork uow, IOrderRepository repo)
    {
        this.uow  = uow;
        this.repo = repo;
    }

    public void Handle(PlaceOrderCommand cmd)
    {
        var order = repo.Get(cmd.OrderId);
        order.AddItem(cmd.Price);
        uow.Commit();                 // single transaction
    }
}
```

🟨 **Questions for students**

- How many external concerns are referenced in `PlaceOrderHandler`?
- What would break if `AddItem` called `Console.WriteLine`?

---

🟦 **Practice**

- Write a `GetTotalOrdersQuery` that returns total sales for today, leveraging repositories only.

---

## 🔹 Infrastructure Layer — _The Plumbing_

> **Purpose:** Provide technical capabilities (DB, file, SMTP, HTTP clients) **without leaking** into Domain/Application.

### Patterns Used

| Pattern          | Why?                                         |
| ---------------- | -------------------------------------------- |
| **Repository**   | Hide data‑access details; expose aggregates. |
| **Unit of Work** | Bundle writes into a single transaction.     |
| **Gateway**      | Wrap external APIs (payment, email).         |

```csharp
public class EfOrderRepository : IOrderRepository
{
    private readonly ShopDbContext db;
    public EfOrderRepository(ShopDbContext db) => this.db = db;

    public Order Get(int id)   => db.Orders.Find(id)!;
    public void Save(Order o)  => db.SaveChanges();
}

public class EfUnitOfWork : IUnitOfWork
{
    private readonly ShopDbContext db;
    public EfUnitOfWork(ShopDbContext db) => this.db = db;
    public void Commit() => db.SaveChanges();
}
```

🟨 **Questions for students**

- Why does `EfOrderRepository` implement an interface declared in Domain?
- What happens if tomorrow you switch from SQL Server to MongoDB?

---

🟦 **Practice**

- Implement `IPaymentGateway` abstraction in Application layer.
  Provide a fake gateway in tests and a real one in Infrastructure.

---

## 🔹 API / UI Layer — _The Window_

> **Purpose:** Translate transport (HTTP/JSON, gRPC, GUI) into Application commands and queries.

```csharp
[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly PlaceOrderHandler handler;
    public OrdersController(PlaceOrderHandler handler) => this.handler = handler;

    [HttpPost("{id}/items")]
    public IActionResult AddItem(int id, [FromBody] AddItemDto dto)
    {
        handler.Handle(new PlaceOrderCommand(id, dto.Price));
        return Ok();
    }
}
```

> **Rule of Thumb:** Controllers should contain _zero_ business logic.

🟨 **Questions for students**

- Where should input validation live: API or Application? Why?
- If authentication rules change, which layer adapts?

---

🟦 **Practice**

- Add a `GET /api/orders/{id}` endpoint. Map it to `GetOrderByIdQuery` without exposing EF entities to the client.

---

## 🔹 Putting It All Together — Request Flow

1. **HTTP Request** hits `OrdersController`.
2. Controller converts JSON → `PlaceOrderCommand`.
3. Application handler calls Domain methods (`AddItem`).
4. Handler invokes repositories (Infrastructure) and `UnitOfWork`.
5. Response DTO mapped back and returned to client.

> _**API → Application → Domain ↔ Infrastructure → DB**_

### Dependency Rule

> Source‑code dependencies **always point inward**: API → Application → Domain.  
> Infrastructure depends on Domain abstractions, **never the reverse**.

---

## 🧹 Clean Architecture Tips

- **Domain has no external references** — compile it in a standalone project.
- **Infrastructure can depend on any library**, but only implements interfaces from above.
- **Application layer contains no EF, no SMTP, no HTTP.**
- API is _thin_: mapping + authentication/authorization.
