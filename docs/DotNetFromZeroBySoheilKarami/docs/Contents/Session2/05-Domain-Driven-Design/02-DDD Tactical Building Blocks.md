---
title: DDD Tactical Building Blocks
---

# DDD Tactical Building Blocks

This page dives deeper into the **code‑level patterns** you’ll use inside each bounded context.  
Remember: these snippets are **simplified for learning** and will evolve as we integrate EF Core and tests.

---

## 🔹 Entity

> **Identity + Lifecycle** — an object distinguished by `Id`, not by its data alone.

```csharp
public class Customer
{
    public Guid   Id   { get; }
    public string Name { get; private set; }
    public Email  Email { get; private set; }

    public Customer(Guid id, string name, Email email)
    {
        Id    = id;
        Name  = name;
        Email = email;
    }

    public void ChangeEmail(Email newEmail) => Email = newEmail;
}
```

🟨 **Questions for students**

- Why is `Id` immutable after construction?
- Could two Customers with identical data be considered different?

---

🟦 **Practice**

- Add a `Deactivate()` method that sets an `IsActive` flag and prevents further email changes.

---

## 🔹 Value Object

> **Immutability + Equality by Data** — represents a descriptive aspect of the domain.

```csharp
public class Address
{
    public string Street { get; }
    public string City   { get; }
    public string Zip    { get; }

    public Address(string street, string city, string zip)
    {
        Street = street;
        City   = city;
        Zip    = zip;
    }

    public override bool Equals(object? obj) =>
        obj is Address a &&
        a.Street == Street && a.City == City && a.Zip == Zip;

    public override int GetHashCode() =>
        HashCode.Combine(Street, City, Zip);
}
```

🟨 **Questions for students**

- Why does the setter not exist?
- What happens if you mutate a value object—why is that dangerous?

---

🟦 **Practice**

- Create a `Money` value object (Amount + Currency) that prevents mixing currencies in addition.

---

## 🔹 Aggregate Root

> **Consistency Boundary** — enforces invariants for itself and child entities.

```csharp
public class Order : IAggregateRoot
{
    private readonly List<OrderLine> _lines = new();
    public Guid Id { get; }

    public Order(Guid id) => Id = id;

    public void AddProduct(Product p, int qty)
    {
        if (qty <= 0) throw new ArgumentException("Qty > 0");
        _lines.Add(new OrderLine(p, qty));
    }

    public int TotalItems() => _lines.Sum(l => l.Qty);
}

public class OrderLine
{
    public Product Product { get; }
    public int     Qty     { get; }

    public OrderLine(Product product, int qty)
    {
        Product = product;
        Qty     = qty;
    }
}
```

🟨 **Questions for students**

- Why is `OrderLine` created **inside** `Order`, not exposed publicly?
- What invariant does `AddProduct` protect?

---

🟦 **Practice**

- Add `RemoveProduct(Guid productId)` ensuring total quantity never drops below zero.

---

## 🔹 Repository

> **Collection‑like interface** for loading/saving aggregates without exposing ORM details.

```csharp
public interface IOrderRepository
{
    Order Get(Guid id);
    void  Add(Order order);
}
```

🟨 **Questions for students**

- Why does the interface return an _aggregate root_ instead of child entities?
- Should repositories return `IQueryable<Order>`? Discuss pros/cons.

---

🟩 **Practice Plus**

- Implement an **in‑memory** `OrderRepository` for unit tests.

---

## 🔹 Domain Service

> **Domain logic that doesn’t belong in a single Entity/VO**.

```csharp
public class PricingService
{
    private readonly ITaxPolicy tax;
    public PricingService(ITaxPolicy tax) => this.tax = tax;

    public Money CalculatePrice(Product p, int qty)
    {
        var net = p.UnitPrice * qty;
        return tax.Apply(net);
    }
}
```

🟨 **Questions for students**

- Why not place `CalculatePrice` inside `Product` or `Order`?
- Which principle of SOLID does this separation support?

---

🟦 **Practice**

- Create a `ShippingService` that decides shipping cost based on weight and destination zones.

---

## 🔹 Factory

> **Encapsulate complex creation** or enforce invariants when creating aggregates.

```csharp
public static class InvoiceFactory
{
    public static Invoice CreateDraft(Order order)
    {
        var invoice = new Invoice(Guid.NewGuid());
        foreach (var line in order.Lines)
            invoice.AddItem(line.Product, line.Qty);
        return invoice;
    }
}
```

🟨 **Questions for students**

- What invariant might be lost if callers instantiated `Invoice` directly?
- How does the factory benefit testing?

---

🟦 **Practice**

- Build an `OrderFactory` that verifies stock availability before creating an Order.

---

## 🔹 Bonus Patterns

| Pattern           | Purpose                                                   | When to study                           |
| ----------------- | --------------------------------------------------------- | --------------------------------------- |
| **Specification** | Encapsulate complex query rules                           | After LINQ session                      |
| **Domain Event**  | Notify other parts of the model about significant changes | After EF Core introduces event dispatch |

---

## 🧹 Summary

- **Entities** have identity; **Value Objects** have meaning by value.
- **Aggregate Roots** guard invariants; **Repositories** abstract persistence.
- **Domain Services** and **Factories** keep entities small and focused.
