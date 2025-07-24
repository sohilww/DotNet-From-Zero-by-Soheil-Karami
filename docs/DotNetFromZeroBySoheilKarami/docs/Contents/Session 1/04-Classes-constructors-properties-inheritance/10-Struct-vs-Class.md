---
title: Struct vs Class
---

# Struct vs Class

## 🔹 What is a `struct`?

A `struct` is a **value type** that is commonly used for small, lightweight objects that represent a single value or data structure.

- Stored on the **stack**
- Copied by value (not reference)
- Cannot inherit from other classes or structs
- Useful for performance-critical scenarios (e.g. `Point`, `DateTime`)

```csharp
public struct Point
{
    public int X;
    public int Y;
}
```

Using the struct

```csharp
Point p1 = new Point { X = 5, Y = 10 };
Console.WriteLine($"X: {p1.X}, Y: {p1.Y}");
```

🟨 **Questions for students**

- What are typical use cases where you'd prefer a `struct` over a `class`?
- What happens if you pass a struct to a method and modify its field?

---

🟦 **Practice**

- Create a `struct` called `Point` with `X` and `Y` fields. Create two points and assign values.
- Pass a `Point` to a method and try to change its values. Print before and after.

---

## 🔹 What is a `class`?

A `class` is a **reference type** used to create complex objects and define behavior via methods and properties.

- Stored on the **heap**
- Passed by reference
- Supports inheritance and polymorphism

```csharp
public class Person
{
    public string Name;
    public int Age;
}
```

🟨 **Questions for students**

- Why are classes more suitable for building application logic?
- What happens when you assign a class instance to another variable?

---

🟦 **Practice**

- Create a class called `Person` with `Name` and `Age` properties. Create two variables and assign one to the other. Modify one and print both.

---

## 🔹 Memory and Behavior Differences

| Feature         | Struct                           | Class                     |
| --------------- | -------------------------------- | ------------------------- |
| Type            | Value type                       | Reference type            |
| Memory location | Stack                            | Heap                      |
| Copy behavior   | By value (independent copy)      | By reference (shared ref) |
| Inheritance     | Not supported                    | Fully supported           |
| Nullability     | Cannot be null (unless nullable) | Can be null               |

```csharp
Point a = new Point { X = 1, Y = 2 };
Point b = a;
b.X = 99;
Console.WriteLine(a.X); // Output: 1
Console.WriteLine(b.X); // Output: 99
```

```csharp
Person p1 = new Person { Name = "Ali", Age = 25 };
Person p2 = p1;
p2.Age = 40;
Console.WriteLine(p1.Age); // Output: 40
```

🟨 **Questions for students**

- What’s the difference between modifying a class and a struct inside a method?
- When would copying by reference be a better option?

---

🟦 **Practice**

- Create a method that modifies both a `Point` struct and a `Person` class. Compare the results and explain why they differ.

---

## 🧹 Clean Code Tips

- Prefer `struct` only when:
  - The object is small and immutable
  - You don’t need inheritance or complex behavior
- Avoid large `structs` because copying them is expensive
- Use `class` when you need shared behavior and object identity
