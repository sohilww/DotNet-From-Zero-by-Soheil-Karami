---
title: Constructors and Properties
sidebar_position: 2
---

# 🛠️ Constructors and Properties in C#

When you create an object, you often want to **initialize it with values**.  
That's where **constructors** and **properties** come in.

---

## 🔹 What is a Constructor?

A **constructor** is a special method that runs automatically when an object is created.  
It’s often used to assign values to fields or properties.

```csharp
class Tree
{
    public string FruitType;
    public int Height;

    public Tree(string fruitType, int height)
    {
        FruitType = fruitType;
        Height = height;
    }
}
```

You can now create a tree and set its values right when you create it:

```csharp
Tree appleTree = new Tree("Apple", 2);
```

---

🟨 **Question for students**

- What’s the benefit of using constructors instead of setting values one by one?

---

🟦 **Practice**

Create a class called `Book` with fields: `Title`, `Author`, and `Pages`.  
Write a constructor to set all of them when the object is created.

---

## 🔐 Access Control (Access Modifiers)

In C#, you can control **who can access** the fields and methods of a class using _access modifiers_.

The most common ones are:

| Modifier    | Who can access it?                       |
| ----------- | ---------------------------------------- |
| `public`    | Anyone — from anywhere                   |
| `private`   | Only inside the same class               |
| `protected` | Only inside the class and its subclasses |

---

### 🌳 Tree Analogy

Imagine a **tree**:

- 🍎 The fruits and leaves are visible — anyone can touch them → they are like `public` fields.
- 🌿 The inner **roots and trunk layers** are hidden and protected — like `private` parts of a class.

You can't just cut into the trunk directly from outside — only the tree itself (internally) can grow or alter those parts.

---

🟨 **Question for students**

- What about the **roots** of the tree?  
  Should they be `private`, or maybe `protected` so only specialized trees can access them?

Discuss where you'd apply each modifier in the tree class.

```csharp
class Tree
{
    public string FruitType;      // visible to everyone
    private int RootDepth;        // only accessible inside the class
    protected int BranchCount;    // accessible to subclasses too
}
```

```csharp
Tree appleTree = new Tree("Apple", 2);

```

## 🧠 Why Fields Should Be Private (Encapsulation)

If you expose your class’s data directly to the outside world,  
you lose control over **how it’s used** or **what values are allowed**.

Let’s say you have a tree with a public field called `Height`.

```csharp
class Tree
{
    public string FruitType;
    public int Height;

    public Tree(string fruitType, int height)
    {
        FruitType = fruitType;
        Height = height;
    }
}
```

Anyone could write:

```csharp
Tree myTree = new Tree();
myTree.Height = -10;

```

That doesn’t make sense in real life — trees don’t shrink to negative height!

This is why we make fields `private` and provide safe access through **properties** or **methods**.

---

🟨 **Question for students**

- What could go wrong if any part of your code can directly modify any field of any object?

---

## 🔍 Validation Logic

If we want to protect the field but still let others assign values,  
we could write our own **validation logic** in a method:

```csharp
class Tree
{
    private int Height;

    public void SetHeight(int newHeight)
    {
        if (newHeight > 0)
        {
            Height = newHeight;
        }
        else
        {
            Console.WriteLine("Invalid height. It must be positive.");
        }
    }
}

```

This way, we can ensure our object stays in a **valid state**.

---

## 💡 OOP Design Tip

Good object-oriented design means:

- Keep the **data private**
- Only expose what’s necessary
- Let the **class itself decide** what is valid or not

Don’t let the outside world mess with your tree’s roots 🌳

---

🟦 **Practice**

- Make the `LeafCount` field of your `Tree` class private
- Write a method `SetLeafCount(int leafCount)` that accepts only values greater than 0
- Try creating a tree and test with different height values (valid and invalid)

---

## 🏠 Introducing Properties

In C#, properties are a better way to **control access** to your class’s internal state.  
They look like fields from the outside — but give you full power to add logic inside.

---

### ❌ Why Not Use Public Fields?

Public fields let anyone assign anything, which can cause invalid states.

```csharp
class Tree
{
    public int Height;
}

Tree t = new Tree();
t.Height = -5; // ❌ invalid

```

We’ve already seen how this can lead to problems.

---

### ✅ Properties to the Rescue

A **property** lets you define a `get` and `set` method for a private field —  
but in a much cleaner and more readable way.

```csharp
class Tree
{
    private int _height;

    public int Height
    {
        get { return _height; }
        set
        {
            if (value > 0)
                _height = value;
            else
                Console.WriteLine("Height must be positive.");
        }
    }
}

```

This gives you control over how the data is accessed or modified.

---

🟨 **Question for students**

- Why would a `set` method sometimes include validation, but `get` often doesn’t?

---

## ⚡ Auto-Implemented Properties

If you don’t need custom logic, you can use **auto-properties** —  
they create the backing field for you automatically.

> Auto-properties are great for cases when you don’t need custom validation

```csharp
public string FruitType { get; set; }
```

This is perfect for simple cases like `Name`, `Type`, or `IsActive`.

---

## 🔒 Read-Only Properties

Want a property to be **read-only**? Just leave out the `set` part.

```csharp
public DateTime PlantedDate { get; }

public Tree()
{
    PlantedDate = DateTime.Now;
}
```

You can still assign the value in the constructor — but no one can change it later.

---

🟨 **Question for students**

- What kinds of data should be read-only in a class?
- Can you name one from real life (e.g. national ID, creation date, etc.)?

---

🟦 **Practice**

Update your `Tree` class:

- Change `Height` to a **property** with validation logic (reject negative values)
- Add an **auto-property** for `FruitType`
- Add a **read-only property** called `PlantedDate` that is set in the constructor

Then create a tree and try reading and modifying these values.

---

## ✅ Summary

| Concept       | Description                                       |
| ------------- | ------------------------------------------------- |
| Constructor   | Initializes objects when they’re created          |
| Property      | Exposes data with control over getting/setting    |
| Auto-property | Short syntax for properties with default behavior |
| Read-only     | Property that can’t be changed externally         |
