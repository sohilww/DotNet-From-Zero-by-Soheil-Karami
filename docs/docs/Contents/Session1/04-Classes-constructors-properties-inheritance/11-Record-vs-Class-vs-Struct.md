<<<<<<< HEAD
---
title: Record vs Class vs Struct
---

# Record vs Class vs Struct

## 🔹 What is a `record`?

A `record` is a **reference type** introduced in **C# 9** for modeling **immutable data** with **value-based equality**.

- Stored on the **heap**
- Passed by reference
- Automatically implements `Equals()`, `GetHashCode()`, and `ToString()`
- Ideal for DTOs, configs, models

```csharp
public record PersonRecord(string Name, int Age);
```

```csharp
var p1 = new PersonRecord("Ali", 30);
var p2 = p1 with { Age = 40 };
Console.WriteLine(p1); // PersonRecord { Name = Ali, Age = 30 }
Console.WriteLine(p2); // PersonRecord { Name = Ali, Age = 40 }
```

---

## 🔸 When to use a `record`?

- You want to **represent data** rather than behavior
- You need **immutable** objects with **value equality**
- You’re building:
  - Request/response models
  - External data contracts (e.g., JSON, XML)
  - Value-centric domain models

---

## 🔸 Comparing `record`, `class`, and `struct`

| Feature              | `record`                       | `class`                | `struct`                  |
| -------------------- | ------------------------------ | ---------------------- | ------------------------- |
| Type                 | Reference                      | Reference              | Value                     |
| Equality             | Value-based by default         | Reference-based        | Value-based               |
| Mutability           | Immutable by convention        | Mutable by default     | Mutable by default        |
| Inheritance          | Supported                      | Supported              | Not supported             |
| Immutability support | Built-in via `init` and `with` | Manual                 | Manual                    |
| Use case             | DTOs, ViewModels, configs      | Services, domain logic | Coordinates, colors, etc. |

---

## 🧠 Example Comparison

### `record` equality example:

```csharp
record A(string Name);
record B(string Name);

Console.WriteLine(new A("Ali") == new A("Ali")); // true
Console.WriteLine(new B("Ali") == new B("Ali")); // true
```

### `class` reference equality:

```csharp
class C { public string Name; }

Console.WriteLine(new C { Name = "Ali" } == new C { Name = "Ali" }); // false
```

🟨 **Questions for students**

- Why are records preferred over classes for DTOs?
- What’s the difference between reference equality and value equality?
- Can a record be mutable?

🟦 **Practice**

- Create a `record` for `Book` with `Title`, `Author`, and `Year`.
- Override `ToString()` for a custom print format.
=======
---
title: Record vs Class vs Struct
---

# Record vs Class vs Struct

## 🔹 What is a `record`?

A `record` is a **reference type** introduced in **C# 9** for modeling **immutable data** with **value-based equality**.

- Stored on the **heap**
- Passed by reference
- Automatically implements `Equals()`, `GetHashCode()`, and `ToString()`
- Ideal for DTOs, configs, models

```csharp
public record PersonRecord(string Name, int Age);
```

```csharp
var p1 = new PersonRecord("Ali", 30);
var p2 = p1 with { Age = 40 };
Console.WriteLine(p1); // PersonRecord { Name = Ali, Age = 30 }
Console.WriteLine(p2); // PersonRecord { Name = Ali, Age = 40 }
```

---

## 🔸 When to use a `record`?

- You want to **represent data** rather than behavior
- You need **immutable** objects with **value equality**
- You’re building:
  - Request/response models
  - External data contracts (e.g., JSON, XML)
  - Value-centric domain models

---

## 🔸 Comparing `record`, `class`, and `struct`

| Feature              | `record`                       | `class`                | `struct`                  |
| -------------------- | ------------------------------ | ---------------------- | ------------------------- |
| Type                 | Reference                      | Reference              | Value                     |
| Equality             | Value-based by default         | Reference-based        | Value-based               |
| Mutability           | Immutable by convention        | Mutable by default     | Mutable by default        |
| Inheritance          | Supported                      | Supported              | Not supported             |
| Immutability support | Built-in via `init` and `with` | Manual                 | Manual                    |
| Use case             | DTOs, ViewModels, configs      | Services, domain logic | Coordinates, colors, etc. |

---

## 🧠 Example Comparison

### `record` equality example:

```csharp
record A(string Name);
record B(string Name);

Console.WriteLine(new A("Ali") == new A("Ali")); // true
Console.WriteLine(new B("Ali") == new B("Ali")); // true
```

### `class` reference equality:

```csharp
class C { public string Name; }

Console.WriteLine(new C { Name = "Ali" } == new C { Name = "Ali" }); // false
```

🟨 **Questions for students**

- Why are records preferred over classes for DTOs?
- What’s the difference between reference equality and value equality?
- Can a record be mutable?

🟦 **Practice**

- Create a `record` for `Book` with `Title`, `Author`, and `Year`.
- Override `ToString()` for a custom print format.
>>>>>>> 7a193b16118128ada34af70ddb9f46fc255209b3
