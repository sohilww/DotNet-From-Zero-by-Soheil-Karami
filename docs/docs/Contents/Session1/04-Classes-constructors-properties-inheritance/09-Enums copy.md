---
title: Enums
sidebar_position: 9
---

# 🎯 Enumerations (enum)

In C#, an `enum` is a special value type that lets you **define a group of named constants**.  
It makes your code **more readable**, **less error-prone**, and easier to manage than using raw numbers or strings.

---

## 🧠 Why use enums?

Let’s say we’re building a system for different **types of trees**.  
We could represent tree types using strings like `"Apple"`, `"Olive"`, `"Pine"` — but what if someone mistypes `"Applle"`?

That’s why we use an `enum` — it gives us a controlled set of options.

---

## 🧩 Defining an Enum

To define an enum, use the `enum` keyword followed by a name and a list of values.

🧾 Example: Tree types

```csharp
enum TreeType
{
    Apple,
    Olive,
    Pine
}
```

---

## 🔢 Under the Hood: What are enum values?

By default, each enum value has an **underlying integer** starting from `0`.

So the above enum will be treated like:

- `TreeType.Apple` → `0`
- `TreeType.Olive` → `1`
- `TreeType.Pine` → `2`

You can override these values manually if you want.

```csharp
enum TreeType
{
    Apple = 1,
    Olive = 3,
    Pine = 5
}
```

## 🔄 Using Enums in Code

You can use enums in your class like this:

```csharp
class Tree
{
    public TreeType Type;

    public Tree(TreeType type)
    {
        Type = type;
    }

    public void Describe()
    {
        Console.WriteLine($"This is a {Type} tree.");
    }
}
```

This makes it much clearer and type-safe.

---

## ❓ Getting the Enum as a Number or String

Enums can be:

- Cast to `int` → for storing in database or comparing
- Converted to `string` → for display

```csharp
TreeType myTreeType = TreeType.Olive;

int typeAsNumber = (int)myTreeType;
string typeAsString = myTreeType.ToString();

Console.WriteLine(typeAsNumber);   // Output: 1 (or 3 if custom)
Console.WriteLine(typeAsString);   // Output: Olive
```

---

## 🧠 Best Practices

- Use `PascalCase` for enum names and values
- Avoid assigning random integers manually unless necessary
- Use enums when the set of values is **fixed and known ahead of time**

🟨 **Question for students**

- Why might enums be better than using strings or numbers directly?
- Can you think of a real-life system (like a game, app, or website) that would benefit from enums?

🟦 **Practice**

- Create an enum called `WeatherType` with values: `Sunny`, `Rainy`, `Cloudy`, `Snowy`
- Write a method that takes a `WeatherType` and prints a message like "It's a sunny day!"
