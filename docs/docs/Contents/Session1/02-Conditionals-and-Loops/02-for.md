---
title: for Loop
sidebar_position: 2
---

# for

Loops allow you to repeat actions multiple times — either a set number of times or until a certain condition is met.

---

## 🔧 Syntax Overview

Used when the number of iterations is known.

```csharp
for (initialization; condition; increment)
{
    // code to execute each iteration
}

```

## 📘 Example 1: Print Numbers with a `for` Loop

```csharp
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"i = {i}");
}
```

This loop starts from 1 and runs as long as `i <= 5`, increasing `i` each time.

🟨 **Question for students**

- What happens if you change the condition to `i < 5`? What if you start from `i = 0`?

---

🟦 **Practice**  
Write a `for` loop that prints:

- All even numbers from 2 to 10
- All odd numbers from 1 to 9

---

## 📗 Example 2: Real-life Scenario – Drinking Water Throughout the Day

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

## 🧠 Advanced: Skipping Iterations with `continue`

Sometimes, you want to skip a specific iteration in a loop.  
For example, you may want to **skip glass number 5** when tracking your water intake:

### 📗 Example 3: Real-life Scenario – Drinking Water Throughout the Day with `continue`

```csharp
for (int glass = 1; glass <= 8; glass++)
{
    if (glass == 5)
    {
        Console.WriteLine("Skipped glass 5 🚫");
        continue;
    }

    Console.WriteLine($"Glass {glass}: Drink water 💧");
}
```

This loop will print reminders for glasses 1 to 8, except for glass 5.

🟨 **Question for students**

- What happens if you move the `continue` statement **before** the log?

---

🟦 **Practice**

Write a `for` loop that:

- Prints numbers from 1 to 10
- Skips number 4 using `continue`
- Prints a special message for number 7 (`"Lucky number!"`)
- Prints the number for all other values

## 🛑 Exiting Loops Early with `break`

Sometimes, you may want to **exit** a loop before it finishes all iterations.  
The `break` statement stops the loop immediately when a specific condition is met.

### 📘 Example: Stop Drinking After 6 Glasses

Let’s say you plan to drink 8 glasses of water a day,  
but for some reason, you want to **stop after 6 glasses**:

```csharp
for (int glass = 1; glass <= 8; glass++)
{
    if (glass > 6)
    {
        Console.WriteLine("That's enough for today! 🛑");
        break;
    }

    Console.WriteLine($"Glass {glass}: Drink water 💧");
}
```

---

### 📘 Example: Stop at 7

Let’s say you want to print the numbers from 1 to 20,
but you’re only interested in going until you find the **first number that’s divisible by 7**.
Once you hit that number, stop the loop early using `break`.

```csharp
for (int i = 1; i <= 10; i++)
{
    if (i == 7)
    {
        Console.WriteLine("Reached 7 — breaking the loop! 🛑");
        break;
    }

    Console.WriteLine($"Number: {i}");
}
```

🟨 **Question for students**

- What will happen if we remove the `break` statement?
- What if we change `i == 7` to `i >= 7`?

---

🟦 **Practice**

Write a `for` loop that:

- Prints numbers from 1 to 20
- Stops the loop when it reaches the second number divisible by **8**
- Prints `"Found a multiple of 8!"` before breaking
