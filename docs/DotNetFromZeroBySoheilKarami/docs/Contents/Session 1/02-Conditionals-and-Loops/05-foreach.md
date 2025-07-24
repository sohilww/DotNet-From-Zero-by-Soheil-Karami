---
title: foreach Loop
sidebar_position: 4
---

# foreach

The `foreach` loop is used to **iterate over collections** such as arrays, lists, or dictionaries.  
It’s ideal when you don’t need to manually manage the index.

---

## 🔧 Syntax Overview

Used when working with collections.

```csharp
foreach (var item in collection)
{
    // code to execute for each item
}

```

> The loop automatically goes through every item in the collection..
> You don’t need to worry about the length or indexes.

### 📘 Example 1: Print Each Name

```csharp
string[] names = { "Ali", "Sara", "Nima", "Reza", "Soheil" };

foreach (string name in names)
{
    Console.WriteLine($"Hello, {name}!");
}
```

This loop prints a greeting for each name in the array.

🟨 **Question for students**

- What would happen if the array is empty?
- Can you use `i++` or indexes inside a `foreach`?

---

🟦 **Practice**  
Write a `foreach` loop that:

- Iterates over an array of your 5 favorite foods
- Prints: `"I love <food>!"` for each one

---

### 📗 Example 2: Real-Life Decision – Checking Tasks

Let’s say you have a list of tasks to complete today:

```csharp
string[] tasks = { "Email replies", "Team meeting", "Code review", "Push updates" };

foreach (string task in tasks)
{
    Console.WriteLine($"✅ Task completed: {task}");
}
```

🟨 **Question for students**

- What if you want to stop the loop after “Code review”?
- Can you remove an item from the collection during `foreach`?

---

🟦 **Practice**  
Write a `foreach` loop that:

- Goes through an array of 5 cities you'd like to visit
- Prints: `"Wish to visit: <city>"`

---

## 🧠 Advanced: Skipping with `continue`, Stopping with `break`

Although `foreach` is simpler, you can still use `break` and `continue` when needed.

### 📗 Example 3: Skip One Item

```csharp
string[] fruits = { "Apple", "Banana", "Mango", "Orange" };

foreach (string fruit in fruits)
{
    if (fruit == "Banana")
    {
        Console.WriteLine("Skipping banana 🍌");
        continue;
    }

    Console.WriteLine($"Eating {fruit} 🍎");
}
```

### 📗 Example 4: Stop When Found

```csharp
string[] tools = { "VS Code", "Rider", "Visual Studio", "Notepad++" };

foreach (string tool in tools)
{
    if (tool == "Visual Studio")
    {
        Console.WriteLine($"Found my favorite IDE: {tool} — stopping! 🛑");
        break;
    }

    Console.WriteLine($"Checking: {tool}");
}
```

🟨 **Question for students**

- What would happen if you add a `continue` after the `break`?
- When would you prefer `foreach` over `for`?

---

🟦 **Practice**  
Write a foreach loop that::

- Iterates through an array of numbers from 1 to 10
- Skips number 5
- Stops if the number is greater than 8
- Prints `"Skipping"` or `"Breaking"` messages appropriately

---
