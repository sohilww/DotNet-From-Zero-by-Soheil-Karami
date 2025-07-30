---
title: Arrays and Collections
---

# Arrays and Collections

## 🔹 What is an Array?

An **array** is a fixed-size, strongly typed sequence of elements stored in a contiguous block of memory.

- All elements must be of the same type.
- The size of the array is fixed at creation.
- Indexing starts from 0.

```csharp
int[] numbers = new int[3];
numbers[0] = 10;
numbers[1] = 20;
numbers[2] = 30;
```

and

```csharp
string[] fruits = { "apple", "banana", "cherry" };
```

---

## 🔹 Accessing and modifying array elements

You can use the index to read or update values inside an array.

```csharp
fruits[1] = "orange";
Console.WriteLine(fruits[1]); // Output: orange
```

---

## 🔹 What is a List?

A `List<T>` is a **resizable collection** from the `System.Collections.Generic` namespace.

- Can grow or shrink in size
- Has helpful methods like `Add`, `Remove`, `Count`, etc.

```csharp
List<int> scores = new List<int>();
scores.Add(90);
scores.Add(85);
scores.Add(78);
```

and

```csharp
scores.Remove(85);
Console.WriteLine($"Total scores: {scores.Count}");
```

🟨 **Questions for students**

- What is the difference between an `array` and a `List<T>`?

🟦 **Practice**

- Create a `List<string>` and add 3 names to it. Print them using a `for` loop.
- Write a method that accepts a `List<int>` and returns the average.

---

## 🔹 What is a Dictionary?

A `Dictionary<TKey, TValue>` stores data in **key-value** pairs and provides fast lookups.

- Keys must be unique
- Useful for structured data like user ID → name, product ID → price, etc.

```csharp
Dictionary<string, string> capitals = new Dictionary<string, string>();
capitals["Iran"] = "Tehran";
capitals["France"] = "Paris";
```

and

```csharp
foreach (var pair in capitals)
{
    Console.WriteLine($"{pair.Key} → {pair.Value}");
}
```

---

## 📌 Summary

| Type                       | Key Feature             | Resizable | Indexed | Keyed  |
| -------------------------- | ----------------------- | --------- | ------- | ------ |
| `Array`                    | Fixed-size, index-based | ❌ No     | ✅ Yes  | ❌ No  |
| `List<T>`                  | Dynamic array           | ✅ Yes    | ✅ Yes  | ❌ No  |
| `Dictionary<TKey, TValue>` | Key-value pair storage  | ✅ Yes    | ❌ No   | ✅ Yes |

🟨 **Questions for students**

- How does a `Dictionary` handle duplicate keys?
- What type of collection would you use to store:
  - a list of student names?
  - a mapping of usernames to passwords?

---

🟦 **Practice**

- Create a dictionary of `country → capital` and print all pairs.
- Try removing an item from a `List` and a `Dictionary`.
