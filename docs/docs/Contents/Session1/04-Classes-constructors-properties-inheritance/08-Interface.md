---
title: Interfaces
sidebar_position: 8
---

# 🤝 Interfaces in C#

An **interface** defines a **contract** that a class agrees to follow.
It tells us **what** the class can do — but not **how** it does it.

---

## 🧠 Real-Life Analogy

Think of an **electric plug** 🔌 — it provides a standard interface (shape, voltage).

You can plug in different devices (laptop, phone charger), but **each device has its own implementation** of how it uses electricity.

---

## 🧾 Defining an Interface

Interfaces in C#:

- Start with `I` (e.g. `IDrawable`, `IVehicle`)
- Only contain method/property **signatures**
- Have **no implementation**

```csharp
public interface ITree
{
    void Grow();
    void ProduceFruit();
}
```

---

## 🧪 Implementing an Interface

Any class that implements the interface must implement **all its members**.

```csharp
public class AppleTree : ITree
{
    public void Grow() => Console.WriteLine("Growing Apple Tree 🍎");
    public void ProduceFruit() => Console.WriteLine("Producing apples 🍎");
}
```

🟨 **Question for students**

- What happens if a class implements an interface but forgets to implement one method?

---

## 📚 Multiple Implementations

You can implement an interface with many different classes:

- `IWorker` → `Engineer`, `Designer`, `Intern`
- `IVehicle` → `Car`, `Bike`, `Truck`

```csharp
public class PineTree : ITree
{
    public void Grow() => Console.WriteLine("Growing Pine Tree 🌲");
    public void ProduceFruit() => Console.WriteLine("Producing pine cones 🌰");
}
```

---

## 🔁 Interface vs Abstract Class

| Feature              | Interface               | Abstract Class                  |
| -------------------- | ----------------------- | ------------------------------- |
| Methods with code?   | ❌ Not allowed (C# < 8) | ✅ Can have logic               |
| Multiple inheritance | ✅ Yes                  | ❌ Only one base class          |
| Constructors?        | ❌ No                   | ✅ Yes                          |
| Fields?              | ❌ No                   | ✅ Yes                          |
| When to use?         | For **contracts**       | For **shared logic + contract** |

---

## 🔍 Why Use Interfaces?

✅ Common reasons:

- Dependency Injection
- Test Doubles (Mocks, Stubs)
- Plug-and-play architecture
- Clean, loosely coupled code

---

## 🧼 Clean Code Tips

- ✅ Name interfaces with an `I` prefix (`IUserRepository`)
- ✅ Prefer interfaces for all core business services
- ✅ One interface per responsibility (Single Responsibility Principle)
- ❌ Don’t create interfaces that are never reused

🟨 **Question for students**

- What are some real examples of interfaces you’ve seen in .NET or other languages?
- Why might a team prefer programming to an interface instead of a concrete class?

🟦 **Practice**

- Create an `IAnimal` interface with methods `Speak()` and `Move()`
- Implement it with `Dog` and `Bird` classes
- Write a method that accepts an `IAnimal` and calls both methods

---

## ⚠️ Important Note on Default Interface Methods (C# 8+)

While C# 8 introduced the ability to add default implementations to interfaces, this feature is **controversial** and should be used with caution.

Interfaces are meant to define **what a class can do** — not **how it should do it**. Putting logic inside an interface may:

- Mix contract and behavior (violates clean architecture)
- Reduce testability and clarity
- Surprise developers who expect interfaces to be logic-free

> ✅ Use it **only** when evolving shared public interfaces where backward compatibility is critical.

🟨 **Question for students**

- What are the trade-offs of using default interface methods?
- Why might it be better to move shared behavior into a base class or helper service?

🟦 **Practice**

- Try adding a default method to an interface.
- Then move the same logic into an abstract base class.
- Compare which version feels more testable, flexible, and readable.

---

## ✅ Summary

| Concept        | Description                                |
| -------------- | ------------------------------------------ |
| Interface      | Contract that defines what a class can do  |
| Implementation | Class must implement all members           |
| Use cases      | DI, Testing, Polymorphism, Plug-in systems |
