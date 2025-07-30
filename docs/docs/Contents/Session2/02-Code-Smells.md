---
title: Code Smells Snapshot
---

# Code Smells Snapshot

## 🔹 What is a Code Smell?

> A **code smell** is a surface indication that usually corresponds to a deeper problem in the system.  
> — Martin Fowler

Smells don’t always break your code immediately, but the longer they linger, the **maintenance cost** and **risk of defects** go up.

---

## 🔹 Three Common Smells

### 1. **God Class / God Method**

- A single class or method that tries to **do everything.**
- Symptoms: thousands of lines, many responsibilities, frequent changes.

#### Problem Example

```csharp
public class OrderProcessor
{
    public void Process(int orderId)
    {
        // 1) Data Access
        var order = db.Orders.Find(orderId);

        // 2) Business Rules
        var total = order.Items.Sum(i => i.Price);

        // 3) Payment Gateway
        payment.Pay(order.Customer, total);

        // 4) Presentation + Email
        var html = $"<h1>Invoice #{orderId}</h1><p>Total: {total}</p>";
        mail.Send(order.CustomerEmail, "Your invoice", html);
    }
}
```

#### Technique — Extract Class / Extract Method

> **What is it?** Break a large class or method into smaller, focused units.
> **Target problem:** Too many responsibilities in one place.
> **Benefit:** Better readability, isolated change, easier unit testing.

#### Refactored

```csharp
public class OrderService
{
    private readonly IOrderRepository repo;
    private readonly PaymentService payment;
    private readonly InvoiceMailer mailer;

    public OrderService(IOrderRepository repo,
                        PaymentService payment,
                        InvoiceMailer mailer)
    {
        this.repo = repo;
        this.payment = payment;
        this.mailer = mailer;
    }

    public void Process(int orderId)
    {
        var order  = repo.Get(orderId);
        var total  = order.CalculateTotal();
        payment.Pay(order.Customer, total);
        mailer.SendInvoice(order, total);
    }
}
```

🟨 **Questions for students**

- Which responsibilities were extracted and into what classes?
- How does this refactor improve testability?

---

🟦 **Practice**

- Take a “do‑everything” method from a sample project and split it into at least **three** smaller classes or methods, each with a single responsibility.

---

### 2. **Shotgun Surgery**

> A single logical change requires edits in many unrelated files—often due to tight coupling or scattered duplication.

#### Problem Sketch

Imagine a **tax calculation rule** duplicated across `CheckoutService`, `InvoiceGenerator`, and `ReportBuilder`. Any rule change forces edits in all three files.

#### Technique — Introduce Policy / Strategy

> **What is it?** Centralize a varying rule behind an interface or strategy class.
> **Target problem:** Logic scattered across multiple files.
> **Benefit:** One‑stop change, lower coupling, clearer dependencies.

#### Refactored

```csharp
public interface ITaxPolicy
{
    decimal Calculate(decimal netPrice);
}

public class DefaultTaxPolicy : ITaxPolicy
{
    public decimal Calculate(decimal netPrice) => netPrice * 0.09m;
}

public class CheckoutService
{
    private readonly ITaxPolicy tax;
    public CheckoutService(ITaxPolicy tax) => this.tax = tax;

    public decimal GetTotal(decimal net) => net + tax.Calculate(net);
}
```

🟨 **Questions for students**

- How does introducing `ITaxPolicy` reduce Shotgun Surgery?
- Which SOLID principle is applied here?

---

🟦 **Practice**

- Locate duplicated logic across two or more methods/classes in a code snippet.  
  Consolidate it behind a single strategy or helper class and update the consumers.

---

### 3. **Magic Numbers / Strings**

- Hard‑coded constants with no descriptive name.
- Makes code harder to read, reuse, or update safely.

#### Problem Example

```csharp
if (discountCode == "S3")
{
    price *= 0.85; // 15 % off
}
```

#### Technique — Replace Magic Constant with Named Constant / Enum

> **What is it?** Give each “mystery” value a descriptive name.
> **Target problem:** Unknown meaning, copy‑paste errors.
> **Benefit:** Self‑documenting code, single‑point change for each constant.

#### Refactored

```csharp
public static class DiscountCodes
{
    public const string Seasonal2025 = "S3";
}

if (discountCode == DiscountCodes.Seasonal2025)
{
    price *= 0.85m;
}
```

🟨 **Questions for students**

- Why is using `DiscountCodes.Seasonal2025` safer than the raw string?
- How would you extend this design if many discount types exist?

---

🟦 **Practice**

- Replace all magic constants in a small code sample with named constants or enums.  
  Verify that changing the discount rate now requires editing **one** place only.

---

## 🧹 Clean Code Tips

- Use **Extract Class / Extract Method** to eliminate God Classes and large methods.
- Centralize business rules with **Strategy or Policy** to avoid Shotgun Surgery.
- Replace magic numbers or strings with **named constants or enums**—your future self will thank you.
