---
title: String Manipulation
---

# String Manipulation

## 🔹 What does "immutable" mean?

In programming, an **immutable** object is one that **cannot be changed after it's created**.

For example:

- If you modify an immutable string, you're not changing the original string — you're creating a **new one** in memory.
- This helps avoid unintended side effects and makes programs easier to reason about.

Common immutable types:

- `string`
- `int`, `bool`, `double`, etc.

---

## 🔹 Strings are immutable

Strings are immutable sequences of characters. Once a string is created, it cannot be changed. Any operation on it returns a **new string**, not a modified version of the original.

```csharp
string original = "Hello";
string modified = original.ToUpper();
Console.WriteLine(original);  // Output: Hello
Console.WriteLine(modified);  // Output: HELLO
```

---

## 🔹 String Interpolation

Interpolation allows you to embed expressions directly in a string using `$`.

```csharp
int age = 33;
string name = "Soheil";
Console.WriteLine($"My name is {name} and I am {age} years old.");
```

---

## 🔹 Common string methods

| Method         | Description                        |
| -------------- | ---------------------------------- |
| `Length`       | Gets the number of characters      |
| `ToUpper()`    | Converts to uppercase              |
| `ToLower()`    | Converts to lowercase              |
| `Trim()`       | Removes whitespace from both ends  |
| `Substring()`  | Extracts a portion of the string   |
| `Replace()`    | Replaces part of the string        |
| `Contains()`   | Checks if a substring exists       |
| `StartsWith()` | Checks if string starts with text  |
| `EndsWith()`   | Checks if string ends with text    |
| `IndexOf()`    | Finds position of a character/text |

```csharp
string message = "  Hello World!  ";
Console.WriteLine(message.Length);                   // 17
Console.WriteLine(message.Trim());                   // "Hello World!"
Console.WriteLine(message.ToUpper());                // "  HELLO WORLD!  "
Console.WriteLine(message.ToLower());                // "  hello world!  "
Console.WriteLine(message.Contains("World"));        // true
Console.WriteLine(message.Replace("World", "Everyone")); // "  Hello Everyone!  "
Console.WriteLine(message.Substring(2, 5));          // "Hello"
```

---

## 🔹 Splitting and joining strings

Splitting divides a string into parts.

```csharp
string csv = "red,green,blue";
string[] colors = csv.Split(',');
foreach (var color in colors)
{
    Console.WriteLine(color);
}
```

Joining creates a string from parts.

```csharp
string[] items = { "car", "bike", "bus" };
string result = string.Join(" | ", items);
Console.WriteLine(result); // Output: car | bike | bus
```

---

## 🔹 Null, empty, and whitespace checks

These helper methods help safely evaluate string contents:

| Method                           | Description                          |
| -------------------------------- | ------------------------------------ |
| `string.IsNullOrEmpty(str)`      | True if str is `null` or `""`        |
| `string.IsNullOrWhiteSpace(str)` | True if str is `null` or only spaces |

```csharp
string input = "   ";
if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Input is empty or whitespace.");
}
```

## 📌 Summary

| Topic                 | Example / Use case                        |
| --------------------- | ----------------------------------------- |
| Concatenation         | `"Hello" + " " + "World"`                 |
| Interpolation         | `$"Age: {age}"`                           |
| Substring extraction  | `str.Substring(0, 3)`                     |
| Trimming              | `str.Trim()`                              |
| Replace               | `str.Replace("old", "new")`               |
| Contains / StartsWith | `str.Contains("abc")`                     |
| Split / Join          | `str.Split(',')`, `string.Join("-", ...)` |
| Null/Empty/Whitespace | `IsNullOrWhiteSpace(str)`                 |
