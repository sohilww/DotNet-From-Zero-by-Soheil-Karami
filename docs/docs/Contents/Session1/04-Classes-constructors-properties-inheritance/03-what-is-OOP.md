---
title: What is OOP
sidebar_position: 3
---

# 🚫 What is OOP

Before we dive into Object-Oriented Programming (OOP), let’s try building our tree system **without using any OOP features**.

---

## 🧱 Approach: One Class per Tree Type

Let’s create a separate class for each type of tree:

- AppleTree 🍎
- OliveTree 🫒
- PineTree 🌲

Each class will have its own:

- `Height` field
- `Grow()` method
- `Photosynthesize()` method
- `ProduceFruit()` method

And all these methods will be **almost identical**, except for a few lines.

```csharp
class AppleTree
{
    public int Height = 0;

    public void Grow()
    {
        Height += 2;
        Console.WriteLine("The Apple tree grew by 2 meters.");
    }

    public void Photosynthesize()
    {
        Console.WriteLine("tree is photosynthesizing 🌞");
    }

    public void ProduceFruit()
    {
        Console.WriteLine("Produced delicious apples 🍎");
    }
}
class OliveTree
{
    public int Height = 0;

    public void Grow()
    {
        Height += 1;
        Console.WriteLine("The Olive tree grew by 1 meter.");
    }

    public void Photosynthesize()
    {
        Console.WriteLine("tree is photosynthesizing 🌞");
    }

    public void ProduceFruit()
    {
        Console.WriteLine("Produced rich olives 🫒");
    }
}
class PineTree
{
    public int Height = 0;

    public void Grow()
    {
        Height += 3;
        Console.WriteLine("The Pine tree grew by 3 meters.");
    }

    public void Photosynthesize()
    {
        Console.WriteLine("tree is photosynthesizing 🌞");
    }

    public void ProduceFruit()
    {
        Console.WriteLine("Produced pine cones 🌲");
    }
}
```

---

## ⚠️ The Problem with This Approach

This kind of code looks okay when you only have 2 or 3 types. But imagine you want to support **20 types of trees** in the future...

### Issues:

- 🔁 **Code Duplication**  
  Every tree class repeats the same logic: growing, photosynthesizing, etc.

- 🐞 **Error-Prone**  
  If you need to fix a bug in the `Grow()` method, you have to fix it in **every class**.

- 🚫 **Hard to Extend**  
  What if you want to log every time a tree photosynthesizes? You’ll need to change **every file**.

- 🧩 **No Shared Structure**  
  All trees are similar, but the code doesn't express this. There is **no connection** between them.

🟨 **Question for students**

- What if you wanted to change how trees grow? Can you update that logic in one place? Or do you need to repeat it everywhere?
- Can you think of a better way to avoid duplicating `Photosynthesize()` logic?

🟦 **Practice**

1. Add a new class called `CherryTree`
2. Copy all code from one of the existing classes
3. Change only the fruit type

Then imagine this:  
A new requirement says _"Every tree must log the date when it grows."_ Now you have to open 4 files and update all `Grow()` methods manually.Is that scalable?

---

## 💬 DRY Principle – Don’t Repeat Yourself

One of the most important principles in clean code is:

> **DRY** – Don’t Repeat Yourself

It means that **every piece of knowledge or logic** should exist **in exactly one place** in your code.

---

### 👇 Let's look at an example

Each of our `Tree` classes has the exact same method for photosynthesis:

```csharp
public void Photosynthesize()
{
    Console.WriteLine("tree is photosynthesizing 🌞");
}
```

Now imagine we want to change the message — maybe log it differently, or include the tree type.

We’d need to change it in every single class — ❌ that’s duplication.

🟨 **Question for students**

- Why is code duplication dangerous?
- Can you think of a real project where repeating logic caused bugs or inconsistencies?

That's why we need a better approach — one that lets us **reuse shared logic**, **avoid duplication**, and **model real-world relationships**.

This is exactly what **Object-Oriented Programming (OOP)** is designed for.

Let’s take a step back and understand what OOP really is.

## 🧠 What is Object-Oriented Programming (OOP)?

**OOP** is a programming paradigm that organizes code around **objects**, which bundle together **data** and **behavior**.

Instead of scattering logic across multiple places, OOP helps you:

- Group related things together (like a tree and its behaviors)
- Reuse shared logic in a clean and safe way
- Extend functionality without duplicating code

---

### 🧩 Key Concepts of OOP

| Concept           | Description                                                        |
| ----------------- | ------------------------------------------------------------------ |
| **Class**         | A blueprint for creating similar objects (e.g. Tree)               |
| **Object**        | An instance of a class with actual data (e.g. appleTree)           |
| **Inheritance**   | Allows a class to inherit behavior and fields from another         |
| **Polymorphism**  | Allows different objects to respond differently to the same method |
| **Encapsulation** | Keeps internal data safe and exposes only what’s necessary         |
| **Abstraction**   | Hides irrelevant details and shows only what’s essential           |

🟨 **Question for students**

- Why might OOP help us scale better than copy-pasting code?
- Which part of your real life could be modeled as an object?

🟦 **Practice**

- Think about how our `Tree` example can benefit from being written in OOP style.
- What behaviors are shared?
- What parts are unique to each tree?
