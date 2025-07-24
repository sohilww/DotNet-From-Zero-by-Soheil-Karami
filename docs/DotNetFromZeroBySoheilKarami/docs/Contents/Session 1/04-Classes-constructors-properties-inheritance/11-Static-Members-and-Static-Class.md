---
title: Static Members and Static Class
---

# Static Members and Static Class

## 🔹 What does `static` mean?

The keyword `static` means **shared** — the member belongs to the **type itself**, not to a specific object.

- Static methods can be called without creating an object.
- Static fields are shared across all uses of a class.

---

## 🔹 Where is `static` used?

You can use `static` for:

- **Utility methods** that don’t need object state (e.g. `Math.Sqrt`)
- **Constants and config values** (e.g. `AppSettings.Version`)
- **Global counters** or shared resources (e.g. a `TotalCount` tracker)
- **Entry point of the program** (`static void Main()`)

```csharp
public class AppTools
{
    public static int ConvertSecondsToMinutes(int seconds)
    {
        return seconds / 60;
    }
}
```

```csharp
public class AppTools
{
    public static string AppName = "DotNet From Zero";

    public static int ConvertSecondsToMinutes(int seconds)
    {
        return seconds / 60;
    }
}

// Usage in Main
Console.WriteLine(AppTools.AppName);
Console.WriteLine(AppTools.ConvertSecondsToMinutes(180)); // Output: 3
```

🟨 **Questions for students**

- In what situations would `static` make your code cleaner or simpler?
- What’s an example of a class you’ve used that was static?

---

🟦 **Practice**

- Create a static class called `AppTools` with a method to convert seconds to minutes.
- Add a static string `AppName` and print it from `Main`.

---

## 🔹 Static Fields and Methods

A **static field** belongs to the type, not any specific object — so its value is **shared across the entire app domain**.

A **static method** can only access static fields and other static methods.

```csharp
public class User
{
    public static int UserCount = 0;

    public User()
    {
        UserCount++;
    }
}
```

```csharp
User u1 = new User();
User u2 = new User();
Console.WriteLine(User.UserCount); // Output: 2
```

🟨 **Questions for students**

- Can static methods access `this`?
- Why do static fields behave like global variables?

---

🟦 **Practice**

- Create a class `User` with a static field `UserCount`. Increment it inside the constructor.
- Print the value of `UserCount` after creating multiple users.

---

## 🔹 Static Class

A class marked as `static`:

- **Cannot be instantiated**
- **Must only contain static members**
- Is useful for grouping reusable helper methods

```csharp
public static class SystemInfo
{
    public static void PrintEnvironment()
    {
        Console.WriteLine($"OS: {Environment.OSVersion}");
        Console.WriteLine($".NET Version: {Environment.Version}");
    }
}

// Usage:
SystemInfo.PrintEnvironment();
```

🟨 **Questions for students**

- Why can't you create an object of a static class?
- When is it better to use a static class instead of an instance class?

---

🟦 **Practice**

- Create a static class `SystemInfo` with a method `PrintEnvironment()` that prints OS and .NET version.

---

## 🧠 Memory and Performance Notes

- Static fields are stored in the **application domain (AppDomain)** — they live for the lifetime of the app.
- Because they're global and always available, **they're never garbage collected** until the process ends.
- Access to static members is slightly **faster** than instance members (no object lookup), but:
  - Overusing static fields leads to **shared state** → race conditions in multithreading.
  - Too many static members = **memory pressure** over time.

Use static responsibly.

---

## 🧹 Clean Code Tips

- Use static methods for **stateless, reusable logic** (like calculators, validators).
- Avoid putting business logic or complex dependencies in static classes.
- Be cautious with mutable static fields in multithreaded apps.
- Always ask: "Should this really be global?"
