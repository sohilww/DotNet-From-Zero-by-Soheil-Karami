---
title: if , else if , else
sidebar_position: 1
---

# if, else if, else

Conditionals allow your program to make decisions based on certain conditions.

---

## 🔧 Syntax Overview

Used when the number of iterations is known.

```csharp
if (condition)
{
    // code to execute each iteration
}
else if(anotherCondition){

}
else{

}

```

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
