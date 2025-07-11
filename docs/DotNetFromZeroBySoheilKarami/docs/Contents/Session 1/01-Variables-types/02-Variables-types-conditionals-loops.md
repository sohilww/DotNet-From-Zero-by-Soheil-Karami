# Variables, Types, Conditionals, and Loops in C#

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

## 🔹 Conditionals (if, else if, else)

Conditionals allow your program to make decisions based on certain conditions.

---

### 📘 Example 1: Grade Evaluation

```csharp
int grade = 82;

if (grade >= 90)
{
    Console.WriteLine("Excellent!");
}
else if (grade >= 75)
{
    Console.WriteLine("Good job!");
}
else
{
    Console.WriteLine("You can do better.");
}
```

🟨 **Question for students**  
What will be printed if `grade` is 70? What about 95?

---

🟦 **Practice**  
Write a conditional that prints different messages for ages:

- Under 18: “Minor”
- 18 to 64: “Adult”
- 65 and above: “Senior”

---

### 📗 Example 2: Real-life Decision – Sunglasses

Think of a real-life situation:

🟢 If it's daytime and sunny, you'll wear your sunglasses.  
🟡 If it's daytime but not sunny, you won't wear them.  
⚫ If it's night, you don't need sunglasses at all.

```csharp
bool isDaytime = true;
bool isSunny = false;

if (isDaytime && isSunny)
{
    Console.WriteLine("Wear sunglasses 😎");
}
else if (isDaytime && !isSunny)
{
    Console.WriteLine("No need for sunglasses.");
}
else
{
    Console.WriteLine("It's night — go to sleep! 🌙");
}
```

---

🟦 **Practice**

Think about 3 real-life situations where you make decisions based on conditions — like the sunglasses example.

For each one, write an `if / else if / else` structure in C# that models your decision.

Example ideas:

- Should I bring an umbrella?
- Should I study or rest?
- Should I take the bus or walk?

Be creative and make it personal!

---

## 🔁 Loops (for, while, foreach)

Loops allow you to repeat actions multiple times — either a set number of times or until a certain condition is met.

---

### 🔹 for Loop

#### 🔧 Syntax Overview

Used when the number of iterations is known.

```csharp
for (initialization; condition; increment)
{
    // code to execute each iteration
}

```

#### 📘 Example 1: Print Numbers with a `for` Loop

```csharp
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"i = {i}");
}
```

This loop starts from 1 and runs as long as `i <= 5`, increasing `i` each time.

🟨 **Question for students**  
What happens if you change the condition to `i < 5`? What if you start from `i = 0`?

---

🟦 **Practice**  
Write a `for` loop that prints:

- All even numbers from 2 to 10
- All odd numbers from 1 to 9

---

### 📗 Example 2: Real-life Scenario – Drinking Water Throughout the Day

Let’s say you want to drink 8 glasses of water in a day and log each one. You can use a `for` loop to simulate this behavior:

```csharp
for (int glass = 1; glass <= 8; glass++)
{
    Console.WriteLine($"Glass {glass}: Drink water 💧");
}
```

This loop prints a reminder for each glass from 1 to 8.

🟨 **Question for students**  
What would change in the loop if you wanted to skip glass 5? Or stop after 6 glasses?

---

🟦 **Practice**  
Write a program that simulates a daily habit with a fixed number of repetitions — for example:

- Brushing teeth 2 times a day
- Doing 10 push-ups
- Checking email 3 times

### 🔹 while Loop

#### 🔧 Syntax Overview

Used when the number of iterations is known.

```csharp
while (condition)
{
    // code to execute
}

```

#### 📗 Example 3: Real-life Decision – Snoozing Your Alarm

Think of a situation where you repeatedly do something — like snoozing your alarm in the morning:

🕒 You want to snooze up to 3 times unless you decide to wake up early.

```csharp
int snoozeCount = 0;
bool wokeUpEarly = false;

while (snoozeCount < 3 && !wokeUpEarly)
{
    Console.WriteLine("Snoozing... 😴");
    snoozeCount++;
}
```

🟨 **Question for students**  
What would happen if you set `wokeUpEarly = true` before the loop? What if you change the snooze limit?

---

🟦 **Practice**  
Think of a repeated action you do in real life (like checking notifications, drinking water during a workout, etc.).

Write a loop (`for` or `while`) that simulates this behavior in C#.

---

### 🔹 foreach Loop

#### 🔧 Syntax Overview

Used when the number of iterations is known.

```csharp
foreach (var item in collection)
{
    // code to execute for each item
}

```

#### 📘 Example 3: Iterating Over a List with `foreach`

Use `foreach` when you want to loop through all items in a collection like an array or a list.

```csharp
string[] fruits = { "Apple", "Banana", "Orange" };

foreach (string fruit in fruits)
{
    Console.WriteLine($"I like {fruit}");
}
```

🟨 **Question for students**  
Can you replace the `foreach` loop above with a `for` loop?

---

🟦 **Practice**  
Write a program that loops through an array of your 5 favorite movies (or songs) and prints each one to the console using `foreach`.

## ✅ Summary

- Variables are containers for data in memory
- Data types define the kind of data a variable can store
- Conditionals let you branch your logic based on values
- Loops let you run code multiple times

These are the building blocks of every C# program.
