<<<<<<< HEAD
---
title: File I/O
---

# File I/O

## 🔹 What is File I/O?

File I/O (Input/Output) refers to **reading from** and **writing to** files on disk.

You typically use:

- `File.WriteAllText`, `File.ReadAllText` for simple operations
- `StreamWriter`, `StreamReader` for advanced scenarios

All methods are available under the `System.IO` namespace.

---

## 🔹 Writing to a file

```csharp
string content = "Hello, world!";
File.WriteAllText("output.txt", content);
Console.WriteLine("File written.");
```

🟨 **Questions for students**

- What happens if the file already exists?
- What if the path is invalid or you don’t have permission?

🟦 **Practice**

- Write your full name to a text file called `myname.txt`.

---

## 🔹 Reading from a file

```csharp
string text = File.ReadAllText("output.txt");
Console.WriteLine($"File content: {text}");
```

🟨 **Questions for students**

- What happens if the file doesn’t exist?
- Is the returned data type a string or byte array?

🟦 **Practice**

- Read the file `myname.txt` and print the number of characters in it.

---

## 🔹 Using StreamWriter and StreamReader

Use these classes when:

- Writing/reading **line-by-line**
- Working with **large files**

```csharp
using (StreamWriter writer = new StreamWriter("log.txt"))
{
    writer.WriteLine("First line");
    writer.WriteLine("Second line");
}
```

```csharp
using (StreamReader reader = new StreamReader("log.txt"))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}
```

🟨 **Questions for students**

- Why use `using` with StreamReader/Writer?
- What happens if you forget to close the stream?

🟦 **Practice**

- Write a list of 5 favorite books line-by-line to a file.
- Read the file line-by-line and number each output line.

---

## 🧠 Notes on Exceptions

Reading and writing to files can throw exceptions like:

- `FileNotFoundException`
- `UnauthorizedAccessException`
- `IOException`

Always use `try-catch` when working with files.

```csharp
try
{
    string data = File.ReadAllText("maybe-missing.txt");
}
catch (Exception ex)
{
    Console.WriteLine("Something went wrong: " + ex.Message);
}
```

## 🧹 Clean Code Tips

- Avoid hardcoding file paths — use config or user input
- Always close streams (or use `using`)
- Separate file access logic from business logic
- Log file errors meaningfully, don't silently fail
=======
---
title: File I/O
---

# File I/O

## 🔹 What is File I/O?

File I/O (Input/Output) refers to **reading from** and **writing to** files on disk.

You typically use:

- `File.WriteAllText`, `File.ReadAllText` for simple operations
- `StreamWriter`, `StreamReader` for advanced scenarios

All methods are available under the `System.IO` namespace.

---

## 🔹 Writing to a file

```csharp
string content = "Hello, world!";
File.WriteAllText("output.txt", content);
Console.WriteLine("File written.");
```

🟨 **Questions for students**

- What happens if the file already exists?
- What if the path is invalid or you don’t have permission?

🟦 **Practice**

- Write your full name to a text file called `myname.txt`.

---

## 🔹 Reading from a file

```csharp
string text = File.ReadAllText("output.txt");
Console.WriteLine($"File content: {text}");
```

🟨 **Questions for students**

- What happens if the file doesn’t exist?
- Is the returned data type a string or byte array?

🟦 **Practice**

- Read the file `myname.txt` and print the number of characters in it.

---

## 🔹 Using StreamWriter and StreamReader

Use these classes when:

- Writing/reading **line-by-line**
- Working with **large files**

```csharp
using (StreamWriter writer = new StreamWriter("log.txt"))
{
    writer.WriteLine("First line");
    writer.WriteLine("Second line");
}
```

```csharp
using (StreamReader reader = new StreamReader("log.txt"))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}
```

🟨 **Questions for students**

- Why use `using` with StreamReader/Writer?
- What happens if you forget to close the stream?

🟦 **Practice**

- Write a list of 5 favorite books line-by-line to a file.
- Read the file line-by-line and number each output line.

---

## 🧠 Notes on Exceptions

Reading and writing to files can throw exceptions like:

- `FileNotFoundException`
- `UnauthorizedAccessException`
- `IOException`

Always use `try-catch` when working with files.

```csharp
try
{
    string data = File.ReadAllText("maybe-missing.txt");
}
catch (Exception ex)
{
    Console.WriteLine("Something went wrong: " + ex.Message);
}
```

## 🧹 Clean Code Tips

- Avoid hardcoding file paths — use config or user input
- Always close streams (or use `using`)
- Separate file access logic from business logic
- Log file errors meaningfully, don't silently fail
>>>>>>> 7a193b16118128ada34af70ddb9f46fc255209b3
