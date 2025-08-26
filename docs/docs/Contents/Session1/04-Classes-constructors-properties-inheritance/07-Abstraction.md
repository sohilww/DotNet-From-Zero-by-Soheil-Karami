---
title: Abstraction
sidebar_position: 7
---

# 🧊 Abstraction in C#

**Abstraction** is the OOP principle of **hiding complexity** and **exposing only essential features**.
It helps you build cleaner, simpler, and easier-to-understand systems.

---

## 🧠 Real-Life Analogy

Imagine driving a car 🚗:

- You turn the steering wheel → the car turns
- You push the gas pedal → the car accelerates

You **don’t need to know** how the engine, gearbox, or brakes work inside.  
You only interact with the **essential features** — this is **abstraction** in action.

---

## 🌳 Tree Example

Let’s say we have different types of trees: AppleTree, PineTree, etc.

We want all trees to be able to:

- Grow
- Photosynthesize
- ProduceFruit

But we **don’t care how** each tree does it. We just want a **common interface** for all trees.

→ This is where abstraction helps.

---

## ✅ Abstraction in C# with `abstract` classes or `interface`

You can use:

- `abstract` classes → when you want to include **some shared logic**
- `interface` → when you only care about defining **the contract**

### 📘 Abstract Class Example

```csharp
public abstract class Tree
{
    public abstract void Grow();
    public abstract void ProduceFruit();

    public void Photosynthesize()
    {
        Console.WriteLine("Photosynthesizing... 🌞");
    }
}
```

### 📘 Interface Example

```csharp
public interface ITree
{
    void Grow();
    void ProduceFruit();
}
```

---

## 🔍 Abstraction vs Encapsulation

| Feature        | Encapsulation                            | Abstraction                         |
| -------------- | ---------------------------------------- | ----------------------------------- |
| Purpose        | Hide internal data                       | Hide implementation complexity      |
| How?           | Using `private`, `protected`, properties | Using `abstract class`, `interface` |
| Focus          | Who can access the data                  | What operations are available       |
| Real-life role | Sealed container                         | Simplified control panel or remote  |

🟨 **Question for students**

- What are some examples of abstraction in real life?
- Why do we need interfaces if abstract classes exist?

🟦 **Practice**

- Create an `IWorker` interface with `Work()` and `Report()`
- Implement `Engineer` and `Designer` classes
- Call the methods through an `IWorker` reference

---

## ✅ Summary

| Concept        | Description                                            |
| -------------- | ------------------------------------------------------ |
| Abstraction    | Expose **what** an object does, not **how** it does it |
| Interface      | Defines a contract (no implementation)                 |
| Abstract Class | Can define a contract + shared logic                   |
