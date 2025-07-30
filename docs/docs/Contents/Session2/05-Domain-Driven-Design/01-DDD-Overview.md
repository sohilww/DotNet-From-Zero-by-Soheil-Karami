---
title: DDD Overview
---

> **Note for students:**  
> DDD can look intimidating—many people even claim it’s “not for junior devs.”  
> I disagree. You don’t need to master every nuance today, **but you should know the theory behind these ideas now**.  
> Understanding the vocabulary early will make the deeper patterns feel familiar when you meet them again in real projects.

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

### Strategic Vocabulary (Problem Space vs Solution Space)

| Term                    | Kind           | Precise Definition                                                                                                                                                 | Quick Example                                                                   |
| ----------------------- | -------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------- |
| **Domain**              | Problem Space  | The whole sphere of knowledge or activity your software addresses.                                                                                                 | “E‑commerce” overall business.                                                  |
| **Subdomain**           | Problem Space  | A distinct area of responsibility **inside** the domain. Each subdomain solves one business problem.                                                               | “Payments”, “Shipping”, “Catalog”.                                              |
| **Bounded Context**     | Solution Space | A well‑defined implementation boundary **where a single model and Ubiquitous Language are consistent**. One subdomain may map to one or multiple bounded contexts. | _Payments_ subdomain implemented as **Billing BC** and **Accounting BC**.       |
| **Ubiquitous Language** | Solution Space | Shared terms used _inside a bounded context_ by both devs and domain experts.                                                                                      | In Billing BC, “Invoice” means an accounts‑receivable document (not a receipt). |
| **Context Map**         | Solution Space | Diagram that shows relationships and translation between multiple bounded contexts.                                                                                | Billing BC ↔ Shipping BC via `ShipmentPaid` event.                              |

> **Rule of Thumb**  
> _Domain/Subdomain_ describe **what** problems exist.  
> _Bounded Context_ describes **where** and **how** we solve them in code.

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
| **Aggregate**        | Consistency boundary, root + children         | _Blue Book_ Ch. 6  |
| **Aggregate Root**   | Gateway to the Aggregate; enforces invariants | _Blue Book_ Ch. 6  |
| **Repository**       | Collection‑like interface for Aggregates      | _Blue Book_ Ch. 6  |
| **Domain Service**   | Operation that doesn’t fit Entity/VO          | _Blue Book_ Ch. 5  |
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

- Pick one context and list its Entities, Value Objects, and Aggregates.

---

## 🧹 Takeaways

- Strategic design defines **where** things belong; tactical patterns define **how** they work.
- Boundaries + ubiquitous language dramatically cut hidden maintenance cost.
