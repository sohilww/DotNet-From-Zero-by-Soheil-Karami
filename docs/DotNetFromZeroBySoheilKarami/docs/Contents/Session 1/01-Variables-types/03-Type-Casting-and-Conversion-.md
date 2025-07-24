---
title: Type Casting and Conversion
sidebar_position: 3
---

# Type Casting and Conversion

In C#, you can convert one data type into another using two main techniques:

---

## 🔹 Implicit Casting (Safe Casting)

This is done **automatically** when there is no risk of data loss. For example, from `int` to `double`.

```csharp
int myInt = 42;
double myDouble = myInt;
Console.WriteLine(myDouble); // Output: 42
```

---

---

## 🧮 Data Types Size and Range

Understanding the **size and range** of data types is essential before performing any casting operation. Here's a quick comparison:

| Type      | Description                                 | Size     | Range                                                   |
| --------- | ------------------------------------------- | -------- | ------------------------------------------------------- |
| `byte`    | Unsigned 8-bit integer                      | 1 byte   | 0 to 255                                                |
| `sbyte`   | Signed 8-bit integer                        | 1 byte   | -128 to 127                                             |
| `short`   | Signed 16-bit integer                       | 2 bytes  | -32,768 to 32,767                                       |
| `ushort`  | Unsigned 16-bit integer                     | 2 bytes  | 0 to 65,535                                             |
| `int`     | Signed 32-bit integer                       | 4 bytes  | -2,147,483,648 to 2,147,483,647                         |
| `uint`    | Unsigned 32-bit integer                     | 4 bytes  | 0 to 4,294,967,295                                      |
| `long`    | Signed 64-bit integer                       | 8 bytes  | -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 |
| `ulong`   | Unsigned 64-bit integer                     | 8 bytes  | 0 to 18,446,744,073,709,551,615                         |
| `float`   | Single-precision floating-point number      | 4 bytes  | ±1.5 × 10⁻⁴⁵ to ±3.4 × 10³⁸                             |
| `double`  | Double-precision floating-point number      | 8 bytes  | ±5.0 × 10⁻³²⁴ to ±1.7 × 10³⁰⁸                           |
| `decimal` | High-precision decimal (ideal for currency) | 16 bytes | ±1.0 × 10⁻²⁸ to ±7.9 × 10²⁸                             |
| `char`    | Unicode character                           | 2 bytes  | U+0000 to U+FFFF                                        |

Having this in mind helps you understand why **casting from `double` to `int` may lose precision**, or why **you can safely cast from `int` to `long` but not always the reverse**.

---

## 🔹 Explicit Casting (Manual Casting)

This is needed when you're converting a **larger or more precise** type to a smaller one, which may cause data loss. You use parentheses to cast manually.

```csharp
double pi = 3.14;
int whole = (int)pi;
Console.WriteLine(whole); // Output: 3
```

and

```csharp
double largeValue = 123456.789;
int smaller = (int)largeValue;
Console.WriteLine(smaller); // Output: 123456 (fraction lost)
```

---

## 🔹 Using Convert Class

The `Convert` class provides methods like `Convert.ToInt32`, `Convert.ToDouble`, etc. It is **safer** than direct casting, and it throws exceptions on failure.

```csharp
string priceText = "199";
int price = Convert.ToInt32(priceText);
Console.WriteLine(price); // Output: 199
```

---

## 🔹 Using Parse and TryParse

Used for converting **strings to numeric types**:

- `Parse` throws an exception if input is invalid
- `TryParse` returns a `bool` and doesn't throw an exception

```csharp
string input = "123";
int result = int.Parse(input);
Console.WriteLine(result); // Output: 123
```

and

```csharp
string input = "abc";
bool success = int.TryParse(input, out int value);
Console.WriteLine($"Success: {success}, Value: {value}");
// Output: Success: False, Value: 0
```

---

## 📌 Summary

| Method           | Description                            | Safe?    |
| ---------------- | -------------------------------------- | -------- |
| Implicit Casting | Automatically done if safe             | ✅ Yes   |
| Explicit Casting | Manual, may lose data                  | ⚠️ Risky |
| Convert Class    | Static methods for conversions         | ✅ Yes   |
| Parse            | Parses string, throws on failure       | ❌ No    |
| TryParse         | Tries parsing, returns success/failure | ✅ Yes   |
