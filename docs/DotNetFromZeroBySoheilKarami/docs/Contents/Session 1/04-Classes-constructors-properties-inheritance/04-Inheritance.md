---
title: Inheritance
sidebar_position: 4
---

# 🌿 Inheritance in C#

After seeing how repetitive code becomes a problem,  
it's time to introduce a better approach: **Inheritance** — one of the pillars of OOP.

---

## 🧠 What is Inheritance?

Inheritance allows a class (called a **subclass**) to reuse the fields and methods of another class (called the **superclass**).

Instead of repeating common logic in every class, we write it **once** in the superclass, and all subclasses **inherit** it.

---

### 🌳 Real Example: Tree System

All types of trees can **photosynthesize** and **have height**,  
but the way they **grow** and **produce fruit** can be different.

Let’s create a base class called `Tree`, and derive `AppleTree`, `OliveTree`, and `PineTree` from it.

```csharp
public class Tree
{
    protected int Height = 0;

    public void Photosynthesize()
    {
        Console.WriteLine("Tree is photosynthesizing 🌞");
    }

    public virtual void Grow()
    {
        Console.WriteLine("Generic tree is growing 🌱");
    }

    public virtual void ProduceFruit()
    {
        Console.WriteLine("Generic fruit produced.");
    }

    protected void ReportHeight()
    {
        Console.WriteLine($"Tree height is {Height} meters.");
    }
}
public class AppleTree : Tree
{
    public override void Grow()
    {
        Height += 2;
        Console.WriteLine("Apple tree grew by 2 meters.");
        ReportHeight();
    }

    public override void ProduceFruit()
    {
        Console.WriteLine("Produced delicious apples 🍎");
    }
}
public class OliveTree : Tree
{
    public override void Grow()
    {
        Height += 1;
        Console.WriteLine("Olive tree grew by 1 meter.");
        ReportHeight();
    }

    public override void ProduceFruit()
    {
        Console.WriteLine("Produced rich olives 🫒");
    }
}
public class PineTree : Tree
{
    public override void Grow()
    {
        Height += 3;
        Console.WriteLine("Pine tree grew by 3 meters.");
        ReportHeight();
    }

    public override void ProduceFruit()
    {
        Console.WriteLine("Produced pine cones 🌲");
    }
}
```

---

## 🧩 Method Customization with `virtual` and `override`

In object-oriented programming, a **superclass** can provide a **default version** of a method using the `virtual` keyword.

Subclasses can then use the `override` keyword to **customize** that method’s behavior.

This allows us to:

- Keep shared structure and naming
- Change only what’s unique in each subclass

### 🧪 Code Comparison

Let’s say every tree grows, but each one grows at a different rate.  
We define a `virtual` method in the superclass, and then `override` it in each subclass.

This way, we avoid writing completely separate `Grow()` methods from scratch.

```csharp
public class Tree
{
    protected int Height = 0;

    public virtual void Grow()
    {
        Console.WriteLine("Generic tree is growing slowly.");
    }
}
public class AppleTree : Tree
{
    public override void Grow()
    {
        Height += 2;
        Console.WriteLine("Apple tree is growing faster! 🍎");
    }
}
```

---

🟨 **Question for students**

- What would happen if we removed `override` in the subclass?
- Can you call the superclass method inside the overridden one?

### 💡 Answer 1: Removing `override` in the subclass

If you remove `override` in the subclass and try to define the same method,  
you are actually hiding the base method — not overriding it.  
This can lead to confusion and unexpected behavior (no polymorphism).

```csharp
public class Tree
{
    public virtual void Grow()
    {
        Console.WriteLine("Generic tree is growing.");
    }
}

public class AppleTree : Tree
{
    // Missing 'override' — this is NOT overriding
    public void Grow()
    {
        Console.WriteLine("Apple tree is growing.");
    }
}
```

---

### 💡 Answer 2: Calling the superclass method

Yes! You can call the superclass version of a method from within the overridden method using the `base` keyword.

This is useful when you want to **extend** the behavior rather than replace it.

```csharp
public class Tree
{
    public virtual void Grow()
    {
        Console.WriteLine("Generic tree is growing.");
    }
}

public class AppleTree : Tree
{
    // Missing 'override' — this is NOT overriding
    public void Grow()
    {
        Console.WriteLine("Apple tree is growing.");
    }
}
```

---

## 🔐 Using `protected` for Inheritance

We’ve seen `public` and `private`, but what about **`protected`**?

A `protected` field or method is:

- ❌ Not accessible from outside the class
- ✅ But available to subclasses

This is perfect when you want to **hide something from the outside**,  
but still allow subclasses to use it.

```csharp
// Inside Tree class
protected int Height;
protected void ReportHeight()
{
    Console.WriteLine($"Tree height: {Height} meters");
}

// Inside child class
public override void Grow()
{
    Height += 2;
    ReportHeight(); // allowed because it's protected
}

```

---

🟨 **Question for students**

- How is `protected` different from `private` and `public`?
- Why might a `Tree` want to keep `Height` protected instead of public?

---

🟦 **Practice**

- Create a new `CherryTree` class that inherits from the `Tree` superclass
- Use `override` to customize `Grow()` and `ProduceFruit()`
- Try using a `protected` field in the superclass

---

---

## 🏗️ Calling Superclass Constructors with `base()`

Sometimes, your **superclass has a constructor** that takes arguments —  
maybe it needs to initialize fields like `Name`, `Height`, or `Age`.

To pass values from the subclass constructor to the superclass constructor,  
use the `base(...)` keyword.

---

### 📘 Example: Tree with Constructor

Let’s say we want every tree to have a **name** and a **starting height**.

We define a constructor in the superclass like this:

```csharp
public class Tree
{
    public string Name { get; }
    public int Height { get; }

    public Tree(string name, int height)
    {
        Name = name;
        Height = height;
    }
}
```

Then, in the subclass, we use `base(...)` to **forward values**.

```csharp
public class AppleTree : Tree
{
    public AppleTree() : base("Apple Tree", 2)
    {
        // Additional logic if needed
    }
}
```

---

🟨 **Question for students**

- What happens if the superclass has no parameterless constructor, but the subclass doesn't call `base(...)`?
- Can we mix custom logic in subclass constructors with base logic?

---

🟦 **Practice**

- Add a constructor to `Tree` that takes a `string name` and `int height`
- In `AppleTree`, use `base(...)` to pass "Apple Tree" and 2
- In `PineTree`, use `base(...)` to pass "Pine Tree" and 3

---

## 🧼 Clean Code Tips for Inheritance

While inheritance is powerful, misusing it can lead to **tight coupling**, **fragile design**, and **unmaintainable code**.  
Here are some clean code principles to help you write **safe and scalable inheritance hierarchies**:

---

### 1️⃣ Prefer Composition Over Inheritance — When Appropriate

Before using inheritance, ask yourself:

> "Is this a **“is-a”** relationship or a **“has-a”** relationship?"

✅ Use inheritance if `AppleTree` **is a** `Tree`  
✅ Use composition if `Tree` **has a** `Logger`

If it's not a real **type of** relationship, use composition.

---

### 2️⃣ Avoid Deep Inheritance Trees

Try to keep your inheritance structure **shallow** — ideally **1–2 levels**.

🧠 Deep hierarchies make the code harder to read and debug.  
Changes in the superclass may unexpectedly break subclasses.

---

### 3️⃣ Don’t Override Just to Change One Line

If you find yourself overriding a method just to slightly change something,  
it's a sign the method is **doing too much** or needs to be **broken down**.

✅ Split the method into smaller pieces  
✅ Extract common logic to helper methods

---

### 4️⃣ Avoid Calling Virtual Methods from Constructors

Calling `virtual` or `override` methods from a superclass constructor is dangerous —  
because the subclass is **not fully constructed yet**.

🔒 You might accidentally call a method that depends on uninitialized fields.

---

### 5️⃣ Use `protected` with Care

While `protected` is helpful for subclasses, exposing too much internal state makes classes tightly coupled.

> 🧠 Use `private` by default → only use `protected` when necessary

---

### 6️⃣ Name Your Superclasses Clearly

Avoid vague names like `BaseClass` or `MyBase`.  
Use meaningful names that reflect shared behavior.

✅ Prefer: `Tree`, `Animal`, `Vehicle`, `Shape`  
❌ Avoid: `BaseComponent`, `BaseObject`, `CommonClass`

---

🟨 **Question for students**

- Have you seen real-world cases where misuse of inheritance caused problems?
- Why is `protected` more dangerous than `private`?
- Can you think of a better way to reuse logic without inheritance?

---

🟦 **Practice**

- Review your subclass structure.  
  Are you overriding methods you don’t really need to?
- Can any logic be extracted into a helper class instead of a superclass?
- Check if any `protected` fields can be safely made `private` or refactored.
