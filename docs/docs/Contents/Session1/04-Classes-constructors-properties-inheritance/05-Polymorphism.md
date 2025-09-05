<<<<<<< HEAD
---
title: Polymorphism
sidebar_position: 5
---

# 🔀 Polymorphism

**Polymorphism** means "**many forms**". It allows you to write code that can work with **different object types** in a consistent way.

---

## 🧠 Why Polymorphism?

Imagine you have different types of trees:

- AppleTree 🍎
- OliveTree 🫒
- PineTree 🌲

All of them have a method called `Grow()` — but **each tree grows differently**.

With polymorphism, you can call `Grow()` on any kind of tree, without worrying about which specific tree it is — the correct version will run.

---

### 📘 Example: Using a List of Trees

Let’s say we want to grow a list of trees together:

```csharp
public class Tree
{
    public virtual void Grow()
    {
        Console.WriteLine("Generic tree grows.");
    }
}

public class AppleTree : Tree
{
    public override void Grow()
    {
        Console.WriteLine("Apple tree grows by 2 meters 🍎");
    }
}

public class OliveTree : Tree
{
    public override void Grow()
    {
        Console.WriteLine("Olive tree grows by 1 meter 🫒");
    }
}

// Using polymorphism
List<Tree> forest = new List<Tree>
{
    new AppleTree(),
    new OliveTree(),
    new AppleTree()
};

foreach (Tree tree in forest)
{
    tree.Grow();  // Will call correct Grow() depending on the tree type
}
```

🟨 **Question for students**

- How does the program know which `Grow()` to call for each tree?
- What would happen if `Grow()` was not marked as `virtual`?

🟦 **Practice**

- Create a list of `Tree` objects with multiple subclasses.
- Write a loop that calls `Grow()` on each one.
- Then try adding a new subclass (`CherryTree`) and see what happens — without changing the loop!

---

## ⚙️ How Polymorphism Works in C#

To use polymorphism in C#, you need to declare methods using the `virtual` keyword in the superclass, and override them using `override` in the subclass.

If you forget to use `override`, the method will be **hidden** — not overridden.

---

### 🧪 `virtual` + `override` vs `new`

- `virtual`: Marks a method in the **superclass** as overridable.
- `override`: Tells the compiler you’re **intentionally replacing** a virtual method.
- `new`: Hides the base method, but doesn’t override it — this can cause confusion.

---

### 📘 Example: Method Hiding with `new`

```csharp
public class Tree
{
    public virtual void Grow()
    {
        Console.WriteLine("Generic tree grows.");
    }
}

public class ConfusedTree : Tree
{
    public new void Grow()
    {
        Console.WriteLine("Confused tree grows in its own weird way.");
    }
}

Tree t = new ConfusedTree();
t.Grow(); // Will print: "Generic tree grows." 😱 (not the subclass version!)
```

If you declare a method in a subclass without using `override`, you’re not overriding — you’re hiding the method.
This **breaks polymorphism**.

🟨 **Question for students**

- What’s the difference between using `override` and `new`?
- Why can method hiding be dangerous?

## 🧼 Clean Code Tips for Polymorphism

Polymorphism can make your code cleaner and more extensible — if used correctly.

Here are best practices to follow:

---

### ✅ Use `override`, not `new`

Using `new` hides the method, but breaks polymorphism. Always prefer `virtual` + `override` to keep behavior predictable.

---

### ✅ Don’t override just to call the base method

If your override only calls `base.Method()`, do you really need it? Keep your method overrides meaningful.

---

### ✅ Avoid business logic in the base class

Keep the base class generic — put shared structure or abstract behaviors there. Subclass behavior should live in the subclasses.

---

### ✅ Make base methods `abstract` if they must be overridden

If every subclass **must** implement a method, mark it as `abstract`. This avoids having default logic that might be wrong.

---

### ✅ Design for extensibility

Use polymorphism when you want to **add new types without changing existing logic**.

Your `for` or `foreach` loop should continue to work if you add `CherryTree`, `OrangeTree`, or even `CactusTree`.

🟨 **Question for students**

- What’s the risk of putting complex logic in the base class?
- Why might method hiding (`new`) lead to unexpected bugs?

🟦 **Practice**

- Refactor a class hierarchy to use `virtual` and `override` correctly.
- Identify any misuse of `new` and correct it.

---

## 🧱 Abstract Classes and Methods

Sometimes you want to **force** every subclass to implement certain behavior.  
That’s where **`abstract` classes** and **`abstract` methods** come in.

---

### 📌 What is an Abstract Method?

- Declared in a **base class** using the `abstract` keyword.
- **Has no body** (no implementation).
- **Must be overridden** by all subclasses.

---

### 📌 What is an Abstract Class?

A class that **cannot be instantiated** and may include abstract methods.  
It serves as a **blueprint** for other classes.

> Think of it like a **template** — you can’t create it directly,  
> but other classes use it as a base.

### 📘 Example: Abstract Tree

```csharp
public abstract class Tree
{
    public string Name;

    public Tree(string name)
    {
        Name = name;
    }

    public abstract void Grow();

    public void Photosynthesize()
    {
        Console.WriteLine($"{Name} is photosynthesizing 🌞");
    }
}

public class AppleTree : Tree
{
    public AppleTree() : base("Apple Tree") {}

    public override void Grow()
    {
        Console.WriteLine("Apple Tree grows by 2 meters 🍎");
    }
}

public class PineTree : Tree
{
    public PineTree() : base("Pine Tree") {}

    public override void Grow()
    {
        Console.WriteLine("Pine Tree grows by 3 meters 🌲");
    }
}

// Example usage
List<Tree> forest = new List<Tree>
{
    new AppleTree(),
    new PineTree()
};

foreach (Tree tree in forest)
{
    tree.Grow();
    tree.Photosynthesize();
}
```

🟨 **Question for students**

- Why would we want to force every tree to implement `Grow()`?
- Can an abstract class contain non-abstract methods too?

🟦 **Practice**

- Create an `abstract class Animal` with an abstract method `MakeSound()`.
- In `Dog` and `Cat` subclasses, override `MakeSound()` to print different messages.

---

## 🔍 Summary: `virtual` vs `abstract` vs `new`

| Keyword    | Can have default logic? | Must be overridden? | Breaks polymorphism? |
| ---------- | ----------------------- | ------------------- | -------------------- |
| `virtual`  | ✅ Yes                  | ❌ No               | ❌ No                |
| `abstract` | ❌ No                   | ✅ Yes              | ❌ No                |
| `new`      | ✅ Yes                  | ❌ No               | ✅ Yes               |
=======
---
title: Polymorphism
sidebar_position: 5
---

# 🔀 Polymorphism

**Polymorphism** means "**many forms**". It allows you to write code that can work with **different object types** in a consistent way.

---

## 🧠 Why Polymorphism?

Imagine you have different types of trees:

- AppleTree 🍎
- OliveTree 🫒
- PineTree 🌲

All of them have a method called `Grow()` — but **each tree grows differently**.

With polymorphism, you can call `Grow()` on any kind of tree, without worrying about which specific tree it is — the correct version will run.

---

### 📘 Example: Using a List of Trees

Let’s say we want to grow a list of trees together:

```csharp
public class Tree
{
    public virtual void Grow()
    {
        Console.WriteLine("Generic tree grows.");
    }
}

public class AppleTree : Tree
{
    public override void Grow()
    {
        Console.WriteLine("Apple tree grows by 2 meters 🍎");
    }
}

public class OliveTree : Tree
{
    public override void Grow()
    {
        Console.WriteLine("Olive tree grows by 1 meter 🫒");
    }
}

// Using polymorphism
List<Tree> forest = new List<Tree>
{
    new AppleTree(),
    new OliveTree(),
    new AppleTree()
};

foreach (Tree tree in forest)
{
    tree.Grow();  // Will call correct Grow() depending on the tree type
}
```

🟨 **Question for students**

- How does the program know which `Grow()` to call for each tree?
- What would happen if `Grow()` was not marked as `virtual`?

🟦 **Practice**

- Create a list of `Tree` objects with multiple subclasses.
- Write a loop that calls `Grow()` on each one.
- Then try adding a new subclass (`CherryTree`) and see what happens — without changing the loop!

---

## ⚙️ How Polymorphism Works in C#

To use polymorphism in C#, you need to declare methods using the `virtual` keyword in the superclass, and override them using `override` in the subclass.

If you forget to use `override`, the method will be **hidden** — not overridden.

---

### 🧪 `virtual` + `override` vs `new`

- `virtual`: Marks a method in the **superclass** as overridable.
- `override`: Tells the compiler you’re **intentionally replacing** a virtual method.
- `new`: Hides the base method, but doesn’t override it — this can cause confusion.

---

### 📘 Example: Method Hiding with `new`

```csharp
public class Tree
{
    public virtual void Grow()
    {
        Console.WriteLine("Generic tree grows.");
    }
}

public class ConfusedTree : Tree
{
    public new void Grow()
    {
        Console.WriteLine("Confused tree grows in its own weird way.");
    }
}

Tree t = new ConfusedTree();
t.Grow(); // Will print: "Generic tree grows." 😱 (not the subclass version!)
```

If you declare a method in a subclass without using `override`, you’re not overriding — you’re hiding the method.
This **breaks polymorphism**.

🟨 **Question for students**

- What’s the difference between using `override` and `new`?
- Why can method hiding be dangerous?

## 🧼 Clean Code Tips for Polymorphism

Polymorphism can make your code cleaner and more extensible — if used correctly.

Here are best practices to follow:

---

### ✅ Use `override`, not `new`

Using `new` hides the method, but breaks polymorphism. Always prefer `virtual` + `override` to keep behavior predictable.

---

### ✅ Don’t override just to call the base method

If your override only calls `base.Method()`, do you really need it? Keep your method overrides meaningful.

---

### ✅ Avoid business logic in the base class

Keep the base class generic — put shared structure or abstract behaviors there. Subclass behavior should live in the subclasses.

---

### ✅ Make base methods `abstract` if they must be overridden

If every subclass **must** implement a method, mark it as `abstract`. This avoids having default logic that might be wrong.

---

### ✅ Design for extensibility

Use polymorphism when you want to **add new types without changing existing logic**.

Your `for` or `foreach` loop should continue to work if you add `CherryTree`, `OrangeTree`, or even `CactusTree`.

🟨 **Question for students**

- What’s the risk of putting complex logic in the base class?
- Why might method hiding (`new`) lead to unexpected bugs?

🟦 **Practice**

- Refactor a class hierarchy to use `virtual` and `override` correctly.
- Identify any misuse of `new` and correct it.

---

## 🧱 Abstract Classes and Methods

Sometimes you want to **force** every subclass to implement certain behavior.  
That’s where **`abstract` classes** and **`abstract` methods** come in.

---

### 📌 What is an Abstract Method?

- Declared in a **base class** using the `abstract` keyword.
- **Has no body** (no implementation).
- **Must be overridden** by all subclasses.

---

### 📌 What is an Abstract Class?

A class that **cannot be instantiated** and may include abstract methods.  
It serves as a **blueprint** for other classes.

> Think of it like a **template** — you can’t create it directly,  
> but other classes use it as a base.

### 📘 Example: Abstract Tree

```csharp
public abstract class Tree
{
    public string Name;

    public Tree(string name)
    {
        Name = name;
    }

    public abstract void Grow();

    public void Photosynthesize()
    {
        Console.WriteLine($"{Name} is photosynthesizing 🌞");
    }
}

public class AppleTree : Tree
{
    public AppleTree() : base("Apple Tree") {}

    public override void Grow()
    {
        Console.WriteLine("Apple Tree grows by 2 meters 🍎");
    }
}

public class PineTree : Tree
{
    public PineTree() : base("Pine Tree") {}

    public override void Grow()
    {
        Console.WriteLine("Pine Tree grows by 3 meters 🌲");
    }
}

// Example usage
List<Tree> forest = new List<Tree>
{
    new AppleTree(),
    new PineTree()
};

foreach (Tree tree in forest)
{
    tree.Grow();
    tree.Photosynthesize();
}
```

🟨 **Question for students**

- Why would we want to force every tree to implement `Grow()`?
- Can an abstract class contain non-abstract methods too?

🟦 **Practice**

- Create an `abstract class Animal` with an abstract method `MakeSound()`.
- In `Dog` and `Cat` subclasses, override `MakeSound()` to print different messages.

---

## 🔍 Summary: `virtual` vs `abstract` vs `new`

| Keyword    | Can have default logic? | Must be overridden? | Breaks polymorphism? |
| ---------- | ----------------------- | ------------------- | -------------------- |
| `virtual`  | ✅ Yes                  | ❌ No               | ❌ No                |
| `abstract` | ❌ No                   | ✅ Yes              | ❌ No                |
| `new`      | ✅ Yes                  | ❌ No               | ✅ Yes               |
>>>>>>> 7a193b16118128ada34af70ddb9f46fc255209b3
