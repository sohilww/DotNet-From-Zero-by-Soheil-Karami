---
title: Null, Value Types, Reference Types, and Nullable Types
sidebar_position: 4
---

# Null, Value Types, Reference Types, and Nullable Types in C#

## 🔹 What is `null`?

In C#, `null` is a special literal that represents the **absence of a value** or **no reference**. It's most commonly used with **reference types**, such as `string`, `object`, arrays, and custom classes.

Example: A variable of type `string` can be set to `null` to indicate it doesn’t point to any text.

---

## 🔹 Value Types vs Reference Types

| Feature          | Value Types                                           | Reference Types                                  |
| ---------------- | ----------------------------------------------------- | ------------------------------------------------ |
| Stored in        | Stack                                                 | Heap                                             |
| Default behavior | Contains actual data                                  | Contains reference to data                       |
| Nullability      | Cannot be `null` by default                           | Can be `null`                                    |
| Examples         | `int`, `bool`, `double`, `char`, `DateTime`, `struct` | `string`, `object`, `class`, `array`, `delegate` |

---

## 🔹 The Problem: Value types can't be null

In many real-world cases (e.g. database, forms), you may need to represent a missing or optional value. But value types like `int`, `bool`, or `DateTime` **cannot be assigned `null` by default**.

```csharp
int number = null; // ❌ Compile error
```

---

## 🔹 The Solution: Nullable types

C# provides a syntax to make value types **nullable**, using `?`.

```csharp
int? age = null;
```

This lets you assign either a real value or `null` to a value type.

```csharp
age = 25;
```

---

## ✅ Checking for null values

You can detect whether a nullable variable holds a value:

1. Using `.HasValue`
2. Using comparison with `null`

```csharp
if (age.HasValue)
{
    Console.WriteLine($"Age is {age.Value}");
}
else
{
    Console.WriteLine("Age is not set.");
}
```

---

## 🔄 Using null-coalescing operator (`??`)

If the variable is `null`, you can provide a fallback/default value using `??`.

```csharp
int displayAge = age ?? 18;
Console.WriteLine($"Display age: {displayAge}");
```

---

## 💡 Using `?.` safely

The null-conditional operator lets you safely access members.

```csharp
int? score = null;
Console.WriteLine("Score: " + (score?.ToString() ?? "No score"));
```

## 📌 Summary

| Concept         | Description                                   |
| --------------- | --------------------------------------------- |
| `null`          | Absence of value or reference                 |
| `int` vs `int?` | `int` can’t be null; `int?` can               |
| `.HasValue`     | Returns true if value exists                  |
| `.Value`        | Gets the value (unsafe if null)               |
| `??`            | Returns default if null                       |
| `?.`            | Safely access members on possibly-null object |
