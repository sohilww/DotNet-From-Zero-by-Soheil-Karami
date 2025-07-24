---
title: Encapsulation
sidebar_position: 6
---

# 🔐 Encapsulation in C#

**Encapsulation** means "**hiding internal details**" and **only exposing what’s necessary**.  
It’s a key part of writing clean, safe, and maintainable object-oriented code.

---

## 🌳 Real-Life Analogy: The Tree

Imagine a real tree:

- 🌿 You can **see** the fruits and leaves → but you **can’t touch the roots**.
- 🌱 The inner roots of the tree could be modeled as `internal` or `protected`,  
   since they are **used by internal systems or subclasses**, but not by external consumers.

This is exactly how encapsulation works in programming:  
→ Protect what's internal, expose only what's useful.

---

## 🚫 Public Fields = Bad Practice

Let’s say we define a `Tree` class like this:

```csharp
public class Tree
{
    public int Height;
    public string FruitType;
}
```

Now any code can **directly modify** its internal state:

- Set `Height` to a negative number
- Change `FruitType` randomly
- Break the rules of our domain

---

🟨 **Question for students**

- What problems might happen if you expose all your class data?

---

## ✅ Encapsulation with `private` + `public`

We can **restrict access** by making fields `private`,  
and provide **controlled access** using properties or methods.

```csharp
public class Tree
{
    private int _height;
    private string _fruitType;

    public int Height
    {
        get => _height;
        set
        {
            if (value > 0)
                _height = value;
            else
                Console.WriteLine("Height must be positive.");
        }
    }

    public string FruitType
    {
        get => _fruitType;
        set => _fruitType = value;
    }
}
```

---

## 🧠 Why Properties Are Better

Properties let us:

- Add **validation** when setting a value
- Keep the field **hidden**
- Use a **clean syntax** for consumers

---

## 🔐 Access Modifiers in C#

| Modifier             | Who can access it?                     |
| -------------------- | -------------------------------------- |
| `public`             | Anyone — from anywhere                 |
| `private`            | Only inside the same class             |
| `protected`          | Inside the class and its subclasses    |
| `internal`           | Same project (assembly) only           |
| `protected internal` | Subclasses or same project             |
| `private protected`  | Same class or subclass in same project |

---

🟨 **Question for students**

- Which members of a class should usually be private?
- When would you use `protected` instead of `private`?

---

🟦 **Practice**

- Make all fields in your `Tree` class private
- Use properties or methods to control access
- Add validation: e.g., Height must always be positive

## 🧼 Clean Code Tips

- ✅ Never expose fields directly (`public int age;` ❌)
- ✅ Use properties with validation for critical data
- ✅ Start with `private`, then only open access if needed
- ✅ Keep class internals hidden unless you have a good reason

---

📌 Remember:

> Good encapsulation makes your class a **safe and reliable black box**.  
> You can use it, but you **don’t need to know how it works inside**.
