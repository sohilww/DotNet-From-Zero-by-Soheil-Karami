---
title: Exception Handling
---

# Exception Handling

An **exception** is an error that occurs at runtime and interrupts the normal flow of your program.

## 🔹 What is an Exception?

An **exception** is an error that occurs at runtime and interrupts the normal flow of your program. If not handled properly, it can crash the application.

Examples of situations that may cause exceptions:

- Dividing by zero
- Accessing an invalid array index
- Converting invalid input
- Working with unavailable files

```csharp
int x = 10;
int y = 0;
int result = x / y; // Runtime exception: DivideByZeroException
```

🟨 **Questions for students**

- What is the difference between a compile-time error and a runtime exception?
- Can you guess what kind of exceptions might occur in user input?

🟦 **Practice**

- Try dividing a number by zero and observe the behavior.
- Try parsing the string `"abc"` into an integer using `int.Parse`.

---

## 🔹 Try-Catch Block

Use a `try-catch` block to catch and handle exceptions so your program can continue running.

```csharp
try
{
    int x = 10;
    int y = 0;
    int result = x / y;
}
catch
{
    Console.WriteLine("Something went wrong!");
}
```

and

```csharp
try
{
    Console.Write("Enter a number: ");
    int number = int.Parse(Console.ReadLine());
    int result = 100 / number;
    Console.WriteLine($"Result: {result}");
}
catch
{
    Console.WriteLine("Invalid input or division by zero!");
}
```

🟨 **Questions for students**

- What happens if you remove the `try-catch` block?
- Can one `catch` block handle all exception types?

🟦 **Practice**

- Write a program that asks for a number from the user and divides 100 by that number using try-catch.
- Add a catch block that prints a custom message if an exception occurs.

---

## 🔹 Catching Specific Exceptions

You can catch **specific exception types** to handle different error cases more precisely.

```csharp
try
{
    Console.Write("Enter a number: ");
    int number = int.Parse(Console.ReadLine());
    Console.WriteLine(100 / number);
}
catch (FormatException)
{
    Console.WriteLine("Please enter a valid number.");
}
catch (DivideByZeroException)
{
    Console.WriteLine("Cannot divide by zero.");
}
```

🟨 **Questions for students**

- What’s the benefit of catching specific exceptions?
- Can you catch multiple exceptions in a single try block?

🟦 **Practice**

- Handle both `DivideByZeroException` and `FormatException` separately in the same program.

---

## 🔹 Finally Block

The `finally` block is always executed whether an exception occurs or not — ideal for cleanup (e.g. closing files or connections).

```csharp
try
{
    int number = 10;
    Console.WriteLine(100 / number);
}
catch
{
    Console.WriteLine("An error occurred.");
}
finally
{
    Console.WriteLine("Operation complete.");
}
```

🟨 **Questions for students**

- When does the `finally` block run?
- Can you use a `finally` block without a `catch`?

🟦 **Practice**

- Create a program with `try-catch-finally` where:
  - The `try` performs a division
  - The `catch` handles exceptions
  - The `finally` prints `"Operation complete"`

---

## 🧹 Clean Code Tips

Exception handling is not a substitute for writing clean and predictable code. Here are some important best practices:

- **Don’t use try-catch to hide problems**: Use it to handle expected errors, not to silence bugs.
- **Each method should do one thing**: Don't mix parsing, logic, and output in one block. Separate responsibilities.
- **Validate before throwing**: Use `if` checks to prevent obvious exceptions like divide-by-zero.
- **Avoid deep nesting**: Don’t overuse try-catch inside loops or nested blocks.
- **Never leave catch blocks empty**: Always log or show something meaningful.

✅ A clean method might look like this:

```csharp
int GetUserInput()
{
    Console.Write("Enter a number: ");
    return int.Parse(Console.ReadLine());
}

int Divide(int a, int b)
{
    if (b == 0)
        throw new DivideByZeroException();
    return a / b;
}

try
{
    int number = GetUserInput();
    int result = Divide(100, number);
    Console.WriteLine($"Result: {result}");
}
catch (FormatException)
{
    Console.WriteLine("Input must be a valid number.");
}
catch (DivideByZeroException)
{
    Console.WriteLine("Cannot divide by zero.");
}
```

🟨 **Questions for students**

- Why is it better to validate inputs before entering a `try-catch` block?
- What happens if you put too much logic inside a `catch` block?

🟦 **Practice**

- Rewrite the program to:
  - Use a `for` or `while` loop to ask the user for **at least 5 numbers**
  - Try dividing `100` by each entered number
  - Handle errors (like invalid input or divide-by-zero) cleanly
  - Keep the logic for **input**, **calculation**, and **error handling** in separate methods

---

## 📌 Summary

| Keyword     | Purpose                                  |
| ----------- | ---------------------------------------- |
| `try`       | Wraps risky code that might throw errors |
| `catch`     | Handles exceptions when thrown           |
| `finally`   | Executes code regardless of exception    |
| `Exception` | Base class for all exceptions            |
