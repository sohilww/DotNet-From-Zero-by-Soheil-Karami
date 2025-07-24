---
title: Value Types vs Reference Types
---

# Value Types vs Reference Types

## 🔹 What is a Value Type?

A **value type** holds data directly in its own memory location.

- Stored on the **stack**
- Copied by value
- Changing one copy doesn’t affect the other
- Includes: `int`, `float`, `bool`, `char`, `struct`, `DateTime`, etc.

```csharp
int a = 10;
int b = a;
b = 20;

Console.WriteLine(a); // Output: 10
Console.WriteLine(b); // Output: 20

```

🟨 **Questions for students**

- What happens when you assign a value type to another variable?
- Why doesn’t changing `b` affect `a` in this case?

---

🟦 **Practice**

- Create a struct called `Point` with `X` and `Y` fields. Copy one `Point` to another and modify it. Compare both values.

---

## 🔹 What is a Reference Type?

A **reference type** stores a reference (address) to the actual data on the heap.

- Stored on the **heap**
- Copied by reference
- Changing one reference affects all others pointing to the same object
- Includes: `class`, `string`, `object`, `array`, etc.

```csharp
class Person
{
    public string Name;
}

Person p1 = new Person { Name = "Ali" };
Person p2 = p1;
p2.Name = "Soheil";

Console.WriteLine(p1.Name); // Output: Soheil
```

🟨 **Questions for students**

- What’s being copied here: the object or the reference?
- Why do both `p1` and `p2` show the same name?

---

🟦 **Practice**

- Create a class `Book` with `Title` property. Assign one object to another variable, change one, and observe the effect.

---

## 🔹 Memory and Behavior Differences

| Feature           | Value Type                      | Reference Type             |
| ----------------- | ------------------------------- | -------------------------- |
| Stored in         | Stack                           | Heap                       |
| Copied by         | Value                           | Reference (address)        |
| Nullability       | Can’t be null (unless nullable) | Can be null                |
| Affects original? | ❌ No                           | ✅ Yes                     |
| Examples          | `int`, `struct`, `bool`         | `class`, `array`, `string` |

```csharp
int x = 5;
int y = x;
y++;
Console.WriteLine(x); // Output: 5
Console.WriteLine(y); // Output: 6
```

```csharp
int[] arr1 = { 1, 2, 3 };
int[] arr2 = arr1;
arr2[0] = 99;

Console.WriteLine(arr1[0]); // Output: 99
Console.WriteLine(arr2[0]); // Output: 99
```

🟨 **Questions for students**

- Which one uses shared memory?
- What’s the risk of modifying reference types in methods?

---

🟦 **Practice**

- Create a method that changes a field inside a class and call it.
- Do the same with a struct and compare the result.

---

## 🧹 Clean Code Tips

- Use value types for small, immutable data (like coordinates, amounts).
- Use reference types when identity matters or data is shared.
- Avoid returning references to mutable internal state.
- Be mindful of side effects when passing reference types to methods.
