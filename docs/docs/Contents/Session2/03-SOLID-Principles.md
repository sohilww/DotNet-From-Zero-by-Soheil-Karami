---
title: SOLID Principles
---

> **Note:** In this course we follow the definitions of SOLID as presented in the **“PPP” book (Principles, Patterns, and Practices of C#)** rather than the interpretation in _Clean Architecture_.  
> The core intent is identical—writing maintainable, extensible code—but terminology and code samples come from the PPP perspective.

# SOLID Principles

> Five design principles coined by Robert C. Martin that make software **easier to maintain, extend, and test**.

---

## 🔹 S – Single Responsibility Principle (SRP)

**A class should have one, and only one, reason to change.**

### Problem Example

```csharp
public class ReportGenerator
{
    public string CreateHtmlReport(IEnumerable<Sale> sales)
    {
        // 1) Build HTML
        var html = $"<h1>Sales ({sales.Count()})</h1>";

        // 2) Save to disk
        File.WriteAllText("sales.html", html);

        // 3) Email report
        mail.Send("admin@corp.com", "Daily report", html);

        return html;
    }
}
```

### Refactored (Extract Responsibilities)

```csharp
public class ReportGenerator        // builds HTML
{
    public string BuildHtml(IEnumerable<Sale> sales) => $"<h1>Sales ({sales.Count()})</h1>";
}

public class FileSaver              // saves to disk
{
    public void Save(string path, string content) => File.WriteAllText(path, content);
}

public class EmailSender            // sends email
{
    public void Send(string to, string subject, string body) => mail.Send(to, subject, body);
}
```

🟨 **Questions for students**

- List the three responsibilities in the “bad” example.
- How many reasons to change does the refactored `ReportGenerator` have?

---

🟦 **Practice**

- Find a class with >2 responsibilities and split it into focused classes or methods.

---

## 🔹 O – Open/Closed Principle (OCP)

**Software entities should be open for extension, but closed for modification.**

### Problem Example

```csharp
public class BonusCalculator
{
    public decimal Calculate(Employee e)
    {
        if (e.Type == "Permanent") return e.Salary * 0.1m;
        if (e.Type == "Contract")  return e.Salary * 0.05m;
        // add more `if` for every new employee type…
        return 0;
    }
}
```

### Refactored (Strategy Pattern)

```csharp
public interface IBonusPolicy
{
    decimal Calculate(Employee e);
}

public class PermanentBonus : IBonusPolicy
{
    public decimal Calculate(Employee e) => e.Salary * 0.1m;
}

public class ContractBonus : IBonusPolicy
{
    public decimal Calculate(Employee e) => e.Salary * 0.05m;
}

public class BonusCalculator
{
    private readonly IDictionary<string, IBonusPolicy> _policies;
    public BonusCalculator(IDictionary<string, IBonusPolicy> policies) => _policies = policies;

    public decimal Calculate(Employee e) => _policies[e.Type].Calculate(e);
}
```

🟨 **Questions for students**

- How does the new design let us add a **FreelancerBonus** without editing `BonusCalculator`?
- Which code smell did we remove?

---

🟦 **Practice**

- Implement a new `FreelancerBonus` policy and register it without changing existing classes.

---

## 🔹 L – Liskov Substitution Principle (LSP)

**Subtypes must be substitutable for their base types without breaking correctness.**

### Problem Violation

```csharp
public class Rectangle
{
    public int Width  { get; set; }
    public int Height { get; set; }
    public int Area() => Width * Height;
}

public class Square : Rectangle
{
    public override int Width
    {
        set { base.Width = base.Height = value; }
    }
    public override int Height
    {
        set { base.Width = base.Height = value; }
    }
}
```

`Square` breaks expectations: setting `Width` unexpectedly changes `Height`.

### Fix (Favor Composition)

```csharp
public abstract class Shape
{
    public abstract int Area();
}

public class Square : Shape
{
    public int Side { get; set; }
    public override int Area() => Side * Side;
}
```

🟨 **Questions for students**

- Why did inheriting `Square` from `Rectangle` violate LSP?
- How does the new design restore substitutability?

---

🟦 **Practice**

- Create a `Circle : Shape` class and show that any `Shape` can be used polymorphically without surprises.

---

## 🔹 I – Interface Segregation Principle (ISP)

**Clients should not be forced to depend on methods they do not use.**

### Problem Example

```csharp
public interface IWorker
{
    void Work();
    void Eat();
}

public class Robot : IWorker
{
    public void Work() { /*…*/ }
    public void Eat()  { /* meaningless for robots */ }
}
```

### Refactored (Split Interfaces)

```csharp
public interface IWorkable { void Work(); }
public interface IEatable  { void Eat(); }

public class Human : IWorkable, IEatable
{
    public void Work() { /*…*/ }
    public void Eat()  { /*…*/ }
}

public class Robot : IWorkable
{
    public void Work() { /*…*/ }
}
```

🟨 **Questions for students**

- Which method was a “pollution” for `Robot`?
- How does splitting interfaces improve clarity?

---

🟦 **Practice**

- Identify an overly large interface in a code sample and split it into smaller ones.

---

## 🔹 D – Dependency Inversion Principle (DIP)

**High‑level modules should not depend on low‑level modules; both should depend on abstractions.**

### Problem Example

```csharp
public class ReportExporter
{
    private readonly SqlExporter exporter = new SqlExporter();
    public void Export(string html) => exporter.Save(html);
}
```

### Refactored (Depend on Abstraction)

```csharp
public interface IExporter
{
    void Save(string content);
}

public class SqlExporter : IExporter
{
    public void Save(string content) { /*…*/ }
}

public class FileExporter : IExporter
{
    public void Save(string content) => File.WriteAllText("report.html", content);
}

public class ReportExporter
{
    private readonly IExporter exporter;
    public ReportExporter(IExporter exporter) => this.exporter = exporter;
    public void Export(string html) => exporter.Save(html);
}
```

🟨 **Questions for students**

- How does constructor injection enable easier testing?
- Which principle also helps here besides DIP?

---

🟦 **Practice**

- Write a unit test for `ReportExporter` using a fake `IExporter` implementation to verify `Export` is called.

---

## 🧹 SOLID in Practice

- SRP + OCP keep classes small and allow new features without touching existing code.
- LSP & ISP protect against unexpected side‑effects and bloated dependencies.
- DIP decouples high‑level policy from low‑level details, enabling easy testing and swapping implementations.

Mastering SOLID turns “good intentions” into **maintainable code**.
