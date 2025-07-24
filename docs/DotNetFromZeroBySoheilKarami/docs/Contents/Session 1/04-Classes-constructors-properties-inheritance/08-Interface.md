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

You can plug in different devices (laptop, phone charger),  
but **each device has its own implementation** of how it uses electricity.

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

---

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

---

🟨 **Question for students**

- What are some real examples of interfaces you’ve seen in .NET or other languages?
- Why might a team prefer programming to an interface instead of a concrete class?

---

🟦 **Practice**

- Create an `IAnimal` interface with methods `Speak()` and `Move()`
- Implement it with `Dog` and `Bird` classes
- Write a method that accepts an `IAnimal` and calls both methods

---

## ⚡ Advanced: Default Interface Methods (C# 8+)

Starting from C# 8, interfaces can contain **default method implementations**.

This allows you to define **shared logic** inside the interface itself — something that was previously only possible with abstract classes.

---

Now, any class that implements `ITree`:

- ✅ Must implement `Grow()`
- ✅ Can skip implementing `Photosynthesize()` — the interface already has a default version

---

## ✅ Why is this useful?

- ✅ Lets you add new methods to interfaces without breaking old code
- ✅ Avoids duplication by providing shared behavior
- ✅ Makes interfaces more flexible for API design

---

## ⚠️ When to use (and when not to)

| Use it when...                               | Avoid it when...                                |
| -------------------------------------------- | ----------------------------------------------- |
| You want to evolve interfaces over time      | You need strict separation of interface & logic |
| You want to reuse default behavior           | You’re targeting old versions of C# / .NET      |
| You’re building extensible plugin-based code | You want very lightweight interfaces            |

---

🟨 **Question for students**

- Why might default interface methods help in large applications or libraries?
- How are they different from methods in abstract classes?

---

🟦 **Practice**

- Update your `ITree` interface to include a default method `Log()`
- Let it print `"Tree logged at [DateTime.Now]"` by default
- Try implementing it in `AppleTree` **without overriding** `Log()`
- Then override it in `PineTree` to print a custom message

---

## ✅ Summary

| Concept        | Description                                |
| -------------- | ------------------------------------------ |
| Interface      | Contract that defines what a class can do  |
| Implementation | Class must implement all members           |
| Use cases      | DI, Testing, Polymorphism, Plug-in systems |
