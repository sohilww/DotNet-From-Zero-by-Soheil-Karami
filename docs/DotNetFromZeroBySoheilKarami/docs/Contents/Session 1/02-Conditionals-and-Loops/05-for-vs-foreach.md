---
title: for vs foreach
sidebar_position: 5
---

# 🔄 `for` vs `foreach`

Both `for` and `foreach` are used to loop over data, but they serve different purposes.  
Let’s compare them in terms of **usage**, **flexibility**, and **performance**.

---

## 📌 Syntax Comparison

| Feature      | `for` loop                                      | `foreach` loop                                   |
| ------------ | ----------------------------------------------- | ------------------------------------------------ |
| Structure    | `for (int i = 0; i < array.Length; i++)`        | `foreach (var item in array)`                    |
| Index access | Manual control over index                       | No access to index by default                    |
| Readability  | Verbose                                         | Cleaner and more readable                        |
| Best for     | Indexed access, skipping, or complex conditions | Simple iteration over entire collection          |
| Modifying    | You can modify items or skip using `continue`   | Not ideal for modifying collection while looping |
| Performance  | Slightly faster in tight loops                  | Slightly slower due to enumerator creation       |

---

### 📘 Example 1: `for` Loop

````csharp
string[] names = { "Ali", "Sara", "Reza" };

for (int i = 0; i < names.Length; i++)
{
    Console.WriteLine($"{i}: {names[i]}");
}

> ✅ Gives you access to the index, which is useful for tracking position or modifying specific items.

### 📘 Example: foreach Loop

```csharp
string[] names = { "Ali", "Sara", "Reza" };

foreach (string name in names)
{
    Console.WriteLine($"Hello, {name}");
}
````

> ✅ Cleaner syntax when you just want to read or display items without needing the index.

## 🔄 When to Use `for`

Use `for` when:

- You need to access items by index
- You may want to skip or jump based on position
- You plan to modify the original collection
- Performance in large arrays really matters
- This loop prints a greeting for each name in the array.

## 🔄 When to Use `foreach`

Use `foreach` when:

- You just want to read or display all items
- You don’t care about the index
- You want clean and readable code
- You're working with List\<T\>, Dictionary\<TKey,TValue\>, arrays, etc.

🟦 **Practice**  
Convert the following `for` loop into a `foreach` loop:

```csharp
string[] colors = { "Red", "Green", "Blue" };

for (int i = 0; i < colors.Length; i++)
{
    Console.WriteLine($"Color: {colors[i]}");
}
```

Then answer:

- Which one do you find more readable?
- What would you do if you needed the index?

---

## ✅ Summary

| Use `for` when...                  | Use `foreach` when...                   |
| ---------------------------------- | --------------------------------------- |
| You need the index                 | You just need the item                  |
| You want to skip specific elements | You want simplicity                     |
| You need fine-grained control      | You prefer cleaner syntax               |
| You're modifying the collection    | You're only reading from the collection |
