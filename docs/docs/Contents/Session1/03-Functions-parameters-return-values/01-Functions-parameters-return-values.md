---
title: Functions, Parameters, and Return Values
---

# 🧩 Functions in C#

Functions (also called **methods**) allow you to reuse logic and organize your code into meaningful blocks.  
Instead of writing the same code again and again, you write a function once and call it whenever needed.

---

## 🔧 Syntax Overview

```csharp
returnType FunctionName(parameters)
{
    // code to execute
    return value; // optional if returnType is void
}
```

- `returnType` defines what the function gives back
- `parameters` are inputs (can be none, one, or many)
- Use `void` if the function returns nothing

## 📘 Example 1: Simple Greeting Function

```csharp
void SayHello()
{
    Console.WriteLine("Hello, world!");
}
```

To run this function, use:

```csharp
SayHello();
```

🟨 **Question for students**

- What happens if we call `SayHello();` inside a `for` loop?

🟦 **Practice**  
Write a function that:

- Prints your name
- Call it 3 times using a loop

---

### 📗 Example 2: Function with Parameters

Functions can receive values (called **parameters**) from the caller:

```csharp
void GreetUser(string name)
{
    Console.WriteLine($"Hello, {name}!");
}
```

Usage:

```csharp
GreetUser("Ali");
GreetUser("Sara");
```

🟨 **Question for students**  
What happens if you call GreetUser(); without passing any value?

🟦 **Practice**  
Write a function called `DescribePet` that:

- Takes two parameters: `string name` and `string type`
- Prints something like `"My pet's name is Holo and it's a bird."`

### 📗 Example 3: Function with Return Value

You can make functions that return something using `return`:

```csharp
int Add(int a, int b)
{
    return a + b;
}
```

Usage:

```csharp
int sum = Add(5, 7);
Console.WriteLine($"Sum is: {sum}");
```

🟨 **Question for students**  
Can a function return a value and still print something to the console?

🟦 **Practice**  
Write a function called `Square` that:

- Takes an `int` as input
- Returns its `square (x * x)`
- Print the result for 3 different numbers

### 📗 Example 4: Using Return in Conditionals

You can return early from a function using `return`:

```csharp
void CheckAge(int age)
{
    if (age < 18)
    {
        Console.WriteLine("Access denied.");
        return;
    }

    Console.WriteLine("Access granted.");
}

```

🟨 **Question for students**  
What happens if we remove the return keyword and add more code after the condition?

🟦 **Practice**  
Write a function `CheckPassword` that:

- Takes a `string password`
- If it's `"1234"`, print `"Welcome!"`
- Otherwise, print `"Incorrect password"` and return early

---

## 🧼 Clean Code Practices for Functions

Writing clean and readable functions is a key part of being a professional developer.  
Here are some best practices to follow when writing methods in C#:

---

### ✅ Function Names Should Be Clear and Descriptive

Bad:

```csharp
void DoIt() { }
```

Good:

```csharp

void SendInvoiceToCustomer() { }

```

> 📌 Use verbs for functions (`PrintReport`, `CalculateSalary`, `SendEmail`)

### ✅ Keep Functions Small

- A function should do **only one thing**.
- If you need a comment to explain a block inside a method — extract that block into a separate function

### ✅ Avoid Long Parameter Lists

Bad:

```csharp
void RegisterUser(string name, string email, string phone, string address, string password, int age)  { }
```

Good:

- Group related values into objects (UserInfo)
- Use fewer than 4 parameters if possible

### ✅ Prefer Return Values Over Console Outputs

Functions should return values, not always Console.WriteLine inside:

```csharp
int GetDiscount(int age)
{
    if (age >= 60)
        return 10;
    return 0;
}
```

Let the caller decide how to display or use the result.

### ✅ Avoid Side Effects

Functions should not change global state or variables unless absolutely necessary.

Bad:

```csharp
int counter = 0;

void DoSomething()
{
    counter++; // ❌ unexpected side effect
}

```

🟨 **Question for students**

- Which of these clean code rules have we accidentally broken before?
- Can you refactor one of your previous functions to be cleaner?

🟦 **Practice**  
Refactor the following function using clean code principles:

```csharp
void A(string n, int a, string e)
{
    Console.WriteLine("Name: " + n + ", Age: " + a + ", Email: " + e);
}

```

Hints:

- Rename the method
- Return a formatted string instead of printing it

---

### ✅ Stay at One Level of Abstraction

A function should operate at **a single level of abstraction**.  
Mixing high-level ideas with low-level implementation details makes the code harder to read and maintain.

---

🧵 **Bad Example: Mixed Abstractions**

```csharp
void ProcessOrder()
{
    Console.WriteLine("Processing...");

    // Connect to database
    SqlConnection conn = new SqlConnection("connection_string");
    conn.Open();

    // Insert order
    SqlCommand cmd = new SqlCommand("INSERT INTO Orders ...", conn);
    cmd.ExecuteNonQuery();

    Console.WriteLine("Done!");
}
```

In this example, the method mixes:

- High-level logic: `"ProcessOrder"`
- Low-level implementation: DB connection and SQL command

🪄 **Better: One Level per Function**

```csharp
void ProcessOrder()
{
    Console.WriteLine("Processing...");
    SaveOrderToDatabase();
    Console.WriteLine("Done!");
}

void SaveOrderToDatabase()
{
    using var conn = new SqlConnection("connection_string");
    conn.Open();

    var cmd = new SqlCommand("INSERT INTO Orders ...", conn);
    cmd.ExecuteNonQuery();
}
```

Now:

- `ProcessOrder()` talks at a high level
- `SaveOrderToDatabase()` handles the low-level details

🟨 **Question for students**

- Do you have any questions about this principle? Let’s discuss them together.

🟦 **Practice**  
Refactor this function to separate concerns and stay at one level of abstraction:

```csharp
void SendWelcomeEmail(string email)
{
    Console.WriteLine("Preparing email...");

    string subject = "Welcome!";
    string body = "Thanks for signing up.";
    SmtpClient client = new SmtpClient("smtp.server.com");
    client.Send(email, subject, body);

    Console.WriteLine("Email sent.");
}

```

Hint:

- Split it into 2 or more focused methods.
