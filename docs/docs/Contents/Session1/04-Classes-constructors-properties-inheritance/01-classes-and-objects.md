---
title: Classes and Objects
sidebar_position: 1
---

# 🧱 Classes and Objects in C#

Classes are the **blueprints** for creating objects.  
They help us model real-world entities using **data (fields/properties)** and **behavior (methods)**.

---

## 🧠 Why Use Classes?

Let’s say you want to model a car.  
Instead of writing variables like this:

```csharp
string carBrand = "Toyota";
string carColor = "Red";
int carSpeed = 120;
```

You can group related data and logic using a class:

```csharp
class Car
{
    public string Brand;
    public string Color;
    public int Speed;
}
```

Then you create an object (instance) of the class:

```csharp
Car myCar = new Car();
myCar.Brand = "Toyota";
myCar.Color = "Red";
myCar.Speed = 120;
```

Now `myCar` is a real object in memory based on the blueprint `Car`.

🟨 **Question for students**  
What is the difference between a class and an object? Can you explain it in your own words?

🟦 **Practice**  
Create a class called Book with these fields:

- `Title` (string)
- `Author` (string)
- `Pages` (int)
- Then create 2 different books and assign values to their fields.

---

## 🧠 Real-Life Analogy

| Concept | Real-Life Example                          |
| ------- | ------------------------------------------ |
| Class   | Blueprint of a house                       |
| Object  | A built house based on that blueprint      |
| Field   | The rooms, doors, and windows of the house |
| Method  | What the house can do (e.g. open a door)   |

This analogy helps us understand how classes define a structure, while objects are real things we can use in code.

### 🖼️ Think of a drawing of a tree.

It shows **branches, leaves, roots, and fruits** — but it's just a drawing.That drawing is like a **class** — it defines the structure of a tree.

But you can’t eat a fruit from a picture! 🍎  
To actually use the tree — to **pick its fruit**, **watch it grow**, or **interact with it** —  
you need to **plant and grow a real one**.

That real, living tree is the **object** — an instance created from the blueprint.

Just like in programming:

- A **class** describes what something _could be_
- An **object** is the real thing you can use

---

## 🧩 Defining Methods Inside Classes

A class can also include **methods**, which define the behavior or actions of an object.

For example, a `Car` class might have a method called `Honk()` that prints `"Beep beep!"`.

We define methods _inside_ the class, and we _call_ them using the object.

```csharp
class Car
{
    public string Brand;
    public int Speed;

    public void Honk()
    {
        Console.WriteLine("Beep beep!");
    }
}
```

To call the method:

```csharp
Car myCar = new Car();
myCar.Honk();
```

🟨 **Question for students**

- Can a class have both **fields** and **methods**?
- What’s the difference between them?

🟦 **Practice**

Extend your `Book` class:

- Add a method called `DisplayInfo()`
- It should print: `Title: <title>, Author: <author>, Pages: <pages>`
- Create a few `Book` objects and call `DisplayInfo()` for each one

---

Let’s continue with the **Tree** example:

You might define a class like this:

```csharp
class Tree
{
    public string FruitType;
    public int Height;
    public int LeafCount;

    public void Grow()
    {
        Height++;
        Console.WriteLine("The tree grew taller!");
    }

    public void DropLeaves()
    {
        LeafCount = 0;
        Console.WriteLine("All leaves dropped.");
    }

    public void ProduceFruit()
    {
        Console.WriteLine($"Producing delicious {FruitType} 🍎");
    }
}
```

That means every tree (object) based on this class can **grow**, **drop its leaves**, or **produce fruit**.

Think of it like this:

```csharp
Tree appleTree = new Tree();
appleTree.Grow();
appleTree.ProduceFruit();
```

🟨 **Question for students**

- What actions would you add to a Tree class?
- Are those actions shared across all types of trees?

🟦 **Practice**

Design a Tree class that includes:

- At least two fields (e.g. `Type`, `Height`)
- A method called `DisplayInfo()` that prints tree details
- A method called Grow() that increases the height by 1 meter each time it's called
