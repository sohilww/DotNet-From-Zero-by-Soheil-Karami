---
title: DDD Overview
---

# Domain‑Driven Design Overview

Domain‑Driven Design (DDD) is both a **way of thinking** about software and a **toolbox of patterns**.  
This page is only a **first touch**. To go deeper you’ll need to study the _Blue Book_ (Eric Evans) and _Red Book_ (Vaughn Vernon).

---

## 🔹 Two Perspectives of DDD

| Perspective   | Focus                                                   | Typical Outcome                                         |
| ------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| **Strategic** | _Big‑picture_ boundaries, language, and team alignment. | Clean context boundaries that stop “feature bleeding.”  |
| **Tactical**  | _Code‑level_ patterns that implement the model.         | Entities, Value Objects, Aggregates, Repositories, etc. |

---

## 🔹 Strategic Vocabulary

| Term                    | One‑Line Description                                                                       |
| ----------------------- | ------------------------------------------------------------------------------------------ |
| **Bounded Context**     | A boundary inside which a model lives and the language is unambiguous.                     |
| **Subdomain**           | A boundary inside which a model lives and the language is unambiguous.                     |
| **Ubiquitous Language** | Shared vocabulary used by both devs and domain experts inside a context.                   |
| **Context Map**         | Diagram showing how multiple bounded contexts relate (e.g., _Customer BC_ ↔ _Billing BC_). |

### Strategic Subdomain Types

| Subdomain Type | Short Definition                     | Example                  |
| -------------- | ------------------------------------ | ------------------------ |
| **Core**       | Competitive advantage; must not fail | Pricing engine at Amazon |
| **Supporting** | Important but not unique             | HR, Billing              |
| **Generic**    | Commodity you could buy              | Logging, Authentication  |

---

## 🔹 Tactical Building Blocks & Further Reading

| Pattern (Code‑Level) | Purpose                                       | Where to read more |
| -------------------- | --------------------------------------------- | ------------------ |
| **Entity**           | Identity + lifecycle                          | _Blue Book_ Ch. 5  |
| **Value Object**     | Immutable value, equality by data             | _Blue Book_ Ch. 5  |
| **Aggregate**        | Consistency boundary, root + children         | _Red Book_ Ch. 6   |
| **Aggregate Root**   | Gateway to the Aggregate; enforces invariants | _Red Book_ Ch. 6   |
| **Repository**       | Collection‑like interface for Aggregates      | _Blue Book_ Ch. 6  |
| **Domain Service**   | Operation that doesn’t fit Entity/VO          | _Red Book_ Ch. 7   |
| **Factory**          | Encapsulate complex creation logic            | _Blue Book_ Ch. 6  |

> **Tip:** Tackle _Strategic_ first (naming, boundaries), then apply the _Tactical_ patterns inside each bounded context.

---

## 🔹 Why DDD Lowers Long‑Term Cost

- **Clear domain boundaries** ⇒ fewer cross‑team collisions and rewrites.
- **Rich domain model** ⇒ business rules live near the data, not scattered in controllers.
- **Ubiquitous language** ⇒ fewer misunderstandings between devs and experts.
- **Strategic focus on core subdomain** ⇒ effort spent where it returns the most value.

Result: less duplication, less accidental complexity, and faster onboarding of new developers.

---

## 🔹 Tiny Code Illustration

```csharp
// Inside "Billing" bounded context
public class Invoice : IAggregateRoot
{
    private readonly List<InvoiceLine> _lines = new();
    public Guid Id { get; }
    public Money Total => _lines.Aggregate(new Money(0, "USD"),
                                           (sum, l) => sum.Add(l.Price));

    public Invoice(Guid id) => Id = id;
    public void AddLine(Product p, Money price)
        => _lines.Add(new InvoiceLine(p, price));
}

public class InvoiceLine
{
    public Product Product { get; }
    public Money   Price   { get; }
    public InvoiceLine(Product p, Money price)
    {
        Product = p;
        Price   = price;
    }
}
```

> **Context rule:** Only `Invoice` (aggregate root) may add or remove lines—external code cannot touch `_lines` directly.

🟨 **Questions for students**

- Which subdomain might “Billing” be—core, supporting, or generic? Why?
- If `Product` belongs to a different bounded context, which pattern mediates the relationship?

---

🟦 **Practice**

- Draw a **Context Map** for a simple e‑commerce: _Catalog_, _Ordering_, _Billing_, _Shipping_.
- Pick one context and list its Entities, Value Objects, and Aggregates.

---

## 🧹 Takeaways

- Strategic design defines **where** things belong; tactical patterns define **how** they work.
- Boundaries + ubiquitous language dramatically cut hidden maintenance cost.
- Every code example in this course will live **inside a clear bounded context** as we continue with EF Core and LINQ.
