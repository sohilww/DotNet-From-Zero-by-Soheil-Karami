---
title: while Loop
sidebar_position: 3
---

# while

A `while` loop is used when you want to **repeat an action** as long as a certain condition remains true.  
Unlike `for`, you **don’t need to know** how many times it will run in advance.

---

## 🔧 Syntax Overview

Used when the number of iterations is known.

```csharp
while (condition)
{
    // code to execute
}

```

> The loop will continue until the condition becomes false.
> Make sure the condition eventually becomes **false**, or the loop will run **forever**!

### 📗 Example 1: Example 1: Counting from 1 to 5

```csharp
int i = 1;

while (i <= 5)
{
    Console.WriteLine($"i = {i}");
    i++;
}
```

This prints numbers from 1 to 5, just like a for loop would.

🟨 **Question for students**

- What would happen if we forget to write `i++`?

---

🟦 **Practice**  
Write a while loop that:

- Starts from 10
- Counts down to 1
- Prints each number

---

### 📗 Example 2: Real-life Decision – Snoozing Your Alarm

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

This loop runs as long as you haven't snoozed 3 times and you're still sleepy.

🟨 **Question for students**

- What would happen if you set `wokeUpEarly = true` before the loop? What if you change the snooze limit?
- How would the loop behave if we change !wokeUpEarly to wokeUpEarly?
- What if we forget to increment snoozeCount?

---

🟦 **Practice**  
Write a while loop that simulates:

- Drinking 8 glasses of water (like in the for loop)
- Skipping glass 5 using continue
- Stopping after glass 6 using break

---

## 🧠 Advanced: Skipping with `continue`, Stopping with `break`

You can use `continue` and `break` inside a `while` loop just like in for.

### 📗 Example 3: Example: Skip Glass 5

```csharp
int glass = 1;

while (glass <= 8)
{
    if (glass == 5)
    {
        Console.WriteLine("Skipping glass 5 🚫");
        glass++;
        continue;
    }

    Console.WriteLine($"Glass {glass}: Drink water 💧");
    glass++;
}
```

### 📗 Example 4: Stop at First Even Number

```csharp
int number = 1;

while (number <= 10)
{
    if (number % 2 == 0)
    {
        Console.WriteLine($"Found even number {number} — stopping.");
        break;
    }

    Console.WriteLine($"Number: {number}");
    number++;
}
```

🟨 **Question for students**

- What would happen if we move glass++ after continue?
- Can we use break and continue together in one loop?

---

🟦 **Practice**  
Write a while loop that:

- Starts from 1
- Prints each number
- Skips 4
- Stops if the number is divisible by 5
- Prints `"Stopped at a multiple of 5"` before breaking

---
