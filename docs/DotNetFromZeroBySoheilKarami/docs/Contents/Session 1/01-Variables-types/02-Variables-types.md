# Variables, Types

Understanding variables, data types, conditionals, and loops is essential in any programming language.  
In this article, we’ll explore these core C# concepts in depth, using clear explanations, examples, and interactive questions designed for classroom discussion.

---

# 🧠 Static vs Dynamic Typing in Programming Languages

C# is a **statically typed language**, meaning you must declare the type of every variable at the time of its definition.

This means the compiler knows the type of each variable at compile time, which helps catch errors early and improves performance.

For example:

```csharp
int age = 30;
string city = "London";
```

In contrast, **dynamically typed languages** like Python or JavaScript determine the type of a variable at runtime.

---

## 🔍 Dynamically Typed Languages — Explained

In **dynamically typed languages**, you don't have to declare the type of a variable when you create it.  
The language interpreter determines the type **at runtime**, based on the value assigned.

### 🔸 Example (Python):

```python
x = 10       # x is an integer
x = "hello"  # now x is a string
```

Here, the same variable `x` can hold values of different types at different times, because Python decides the type dynamically.

---

## ✅ Pros of Dynamic Typing:

- **Faster to write**: You don’t need to think about or declare types upfront.
- **More flexible**: One variable can hold different types at different times.
- **Concise code**: Less boilerplate, useful in scripting or rapid prototyping.

---

## ❌ Cons of Dynamic Typing:

- **More prone to runtime errors**: Type-related bugs are often only caught when the program runs.
- **Harder to refactor**: Without knowing types in advance, refactoring large codebases can be risky.
- **Tooling limitations**: IDEs and code editors have less context to provide autocomplete or error detection.

---

## 💬 Quick Comparison

| Feature          | Statically Typed (e.g. C#)  | Dynamically Typed (e.g. Python)  |
| ---------------- | --------------------------- | -------------------------------- |
| Type known at... | Compile time                | Runtime                          |
| Type declaration | Required                    | Not required                     |
| Flexibility      | Less flexible               | More flexible                    |
| Error detection  | Early (compile time)        | Late (runtime)                   |
| Performance      | Generally faster at runtime | May be slower due to type checks |

🟦 **Practice**  
Can you think of a situation where dynamic typing would be helpful? And one where it could cause trouble?

---

## 🔹 Variables in C#

A **variable** is like a container that holds a value in memory. Every variable must have a **type** in C#, which defines what kind of data it can store.

🟦 **Practice**  
What is memory in a computer program? Why is it important when working with variables?

---

C# is a **statically typed language**, meaning you must declare the type of every variable at the time of its definition.

```csharp
int age = 25;
string name = "Soheil";
bool isActive = true;
double temperature = 36.6;
```

🟨 **Question for students**  
What happens if you try to assign a string value to a variable declared as an `int`?

---

## 🔹 Common Data Types

| Type     | Description                        | Example                    |
| -------- | ---------------------------------- | -------------------------- |
| `int`    | Integer numbers                    | `int count = 10;`          |
| `string` | Text / sequence of characters      | `string name = "Ali";`     |
| `bool`   | Boolean value: true or false       | `bool isLoggedIn = false;` |
| `double` | Floating-point with high precision | `double pi = 3.14159;`     |
| `char`   | A single Unicode character         | `char initial = 'A';`      |

🟦 **Practice**  
Define three variables: a student's age, their first name, and whether they passed the exam.

---

## 🔹 Other Important Data Types

C# supports many more useful types:

| Type       | Description                                 | Example                                | Size      | Range                                                   |
| ---------- | ------------------------------------------- | -------------------------------------- | --------- | ------------------------------------------------------- |
| `bool`     | Boolean true/false value                    | `bool isReady = true;`                 | 1 byte    | true / false                                            |
| `byte`     | Unsigned 8-bit integer                      | `byte level = 255;`                    | 1 byte    | 0 to 255                                                |
| `sbyte`    | Signed 8-bit integer                        | `sbyte offset = -128;`                 | 1 byte    | -128 to 127                                             |
| `short`    | Signed 16-bit integer                       | `short temp = -32000;`                 | 2 bytes   | -32,768 to 32,767                                       |
| `ushort`   | Unsigned 16-bit integer                     | `ushort u = 65000;`                    | 2 bytes   | 0 to 65,535                                             |
| `int`      | Signed 32-bit integer                       | `int age = 30;`                        | 4 bytes   | -2,147,483,648 to 2,147,483,647                         |
| `uint`     | Unsigned 32-bit integer                     | `uint count = 3000000000;`             | 4 bytes   | 0 to 4,294,967,295                                      |
| `long`     | Signed 64-bit integer                       | `long stars = 9000000000000000000;`    | 8 bytes   | -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 |
| `ulong`    | Unsigned 64-bit integer                     | `ulong uStars = 18000000000000000000;` | 8 bytes   | 0 to 18,446,744,073,709,551,615                         |
| `float`    | Single-precision floating-point number      | `float price = 19.99f;`                | 4 bytes   | ±1.5 × 10⁻⁴⁵ to ±3.4 × 10³⁸                             |
| `double`   | Double-precision floating-point number      | `double pi = 3.14159;`                 | 8 bytes   | ±5.0 × 10⁻³²⁴ to ±1.7 × 10³⁰⁸                           |
| `decimal`  | High-precision decimal (ideal for currency) | `decimal salary = 5000.75m;`           | 16 bytes  | ±1.0 × 10⁻²⁸ to ±7.9 × 10²⁸                             |
| `char`     | Single 16-bit Unicode character             | `char letter = 'A';`                   | 2 bytes   | U+0000 to U+FFFF                                        |
| `string`   | Sequence of characters                      | `string name = "Ali";`                 | Varies    | Up to 2 billion characters                              |
| `DateTime` | Date and time values                        | `DateTime now = DateTime.Now;`         | 8 bytes   | 01/01/0001 to 12/31/9999                                |
| `object`   | Base type of all types in C#                | `object anything = 42;`                | Reference | Can store any type                                      |
| `var`      | Type inferred from the value                | `var score = 88;`                      | Inferred  | Same as inferred type                                   |

💡 **Tip**: Always choose the most specific type for clarity and performance. Avoid `var` unless the type is obvious from the context.

🟨 **Question for students**  
Why do we need both `float` and `decimal` in C#? Which one would you choose for storing money?

🟨 **Question for students**  
What do you think are the most important things to consider when working with variables?

---

🟦 **Practice**

Write code to declare the following:

1. A `decimal` variable for a product price
2. A `DateTime` variable for today's date
3. A `var` variable for your favorite number

➕ (Optional)  
Print all three variables to the console.

---
