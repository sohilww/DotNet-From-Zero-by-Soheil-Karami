---
sidebar_position: 1
---

# Getting Started with C# and .NET

Installing Visual Studio and Understanding the Basics

---

## 🔹 Introduction

Before we dive into writing code, it’s important to set up our development environment and get familiar with the tools and technologies we’ll use throughout this course.

This guide walks you through installing **Visual Studio**, and introduces you to the **C# language** and the **.NET platform**.

---

## 🔧 Step 1: Install Visual Studio 2022

### ✅ Download

1. Visit the official Visual Studio website:  
   👉 https://visualstudio.microsoft.com/
2. Click **Download Visual Studio** and choose the **Community 2022** edition (it’s free!)

### ✅ Install Required Workloads

When the Visual Studio installer launches, make sure to check **both** of the following workloads:

- ✅ **.NET desktop development**
- ✅ **ASP.NET and web development**

This will install everything needed for:

- Console apps
- Desktop applications (WinForms/WPF)
- Web API projects (which we’ll build later in the course)

> ⚠️ Make sure both workloads are selected before proceeding.

---

## ⚙️ Step 2: Install .NET SDK (optional)

If you're using **VS Code** or working outside Visual Studio, you can manually download and install the .NET SDK:

👉 https://dotnet.microsoft.com/download

> If you're using Visual Studio with the correct workloads, the SDK is installed automatically.

---

## 🔹 What is C#?

**C# (C-Sharp)** is:

- A modern, type-safe, object-oriented programming language
- Developed by Microsoft
- Widely used for backend services, desktop apps, games (Unity), and cross-platform development

It combines the power of C++ with the simplicity of Java and runs on the .NET platform.

---

## 🔹 What is .NET?

**.NET** is:

- A development platform for building applications across web, desktop, mobile, cloud, and more
- Includes tools, libraries, and a runtime
- **Cross-platform**: Runs on Windows, macOS, and Linux
- Open-source and actively maintained by Microsoft and the developer community

---

## 🧭 Why Use C# and .NET?

- ✅ Strong support from Microsoft and a thriving open-source community
- ✅ Suitable for beginners and powerful enough for enterprise-grade applications
- ✅ **High demand for .NET developers in Europe**:
  - Over **37,000 .NET job listings** across Europe on major job boards
  - Hundreds of active job opportunities in countries like Germany, Netherlands, UK, and Sweden
- ✅ Scalable and production-ready
- ✅ Excellent developer experience with Visual Studio

---

## 📜 A Brief History of .NET

- **1999–2002**: Microsoft began building the .NET Framework as part of its “Next Generation Windows Services” initiative.
- **2002**: .NET Framework 1.0 and C# were officially released.
- **2016**: Microsoft launched **.NET Core**, an open-source, cross-platform reimagining of .NET.
- **2020–Present**: The ecosystem was unified under a single versioning model with **.NET 5, 6, 7, 8**, released annually and aimed at supporting all platforms (web, mobile, cloud, desktop).

---

## 💻 What Can You Build with .NET?

### 🟢 Console Applications

Console apps are the simplest form of applications and a great starting point for beginners. These run in a command-line interface and don't have a graphical user interface. In this course, we’ll begin with console applications to learn the basics of the C# language, syntax, control flow, and object-oriented programming concepts without the complexity of UI frameworks. Console apps are also commonly used for scripting, automation, and simple backend tools.

---

### 🟦 Windows Desktop Applications

.NET allows you to build rich desktop applications for Windows using technologies like **Windows Forms (WinForms)** and **Windows Presentation Foundation (WPF)**. These platforms offer GUI-based tools to create applications with buttons, forms, menus, and custom windows. They are ideal for internal tools, business software, and traditional Windows environments. While we won’t go deep into this during the course, the same knowledge of C# will help you pick it up quickly later.

---

### 🌐 ASP.NET Web Applications

ASP.NET is a powerful framework built on top of .NET for creating modern web applications and RESTful APIs. With **ASP.NET Core**, you can build fast, scalable, and cross-platform web apps that run on Windows, Linux, and macOS. In this course, we’ll use **ASP.NET Core Web API** to build backend services — including routing, controllers, dependency injection, and JSON response handling. This is one of the most in-demand areas of .NET development in today’s job market.

---

## 🧪 Next Step

Once Visual Studio is installed, we’ll begin by creating our first **Console Application**, writing some simple code, and learning how C# works.

> 🚀 You’re now ready to begin your .NET journey.

---

## 🚀 Your First Console Application in C#

Now that Visual Studio is installed and ready, let's write and run your very first C# program.

### ✅ Step 1: Create a Console App

1. Open **Visual Studio 2022**
2. Click on **Create a new project**
3. Choose **Console App (.NET Core)** or **Console App (.NET 6/7/8)** depending on your installed version
4. Click **Next**, name your project (e.g., `HelloWorldApp`)
5. Choose a location and click **Create**

You should now see a file called `Program.cs` with some code already written inside.

---

### 🧠 Step 2: Understand the Code

Here's what the default template might look like:

```csharp
Console.WriteLine("Hello, World!");
```

This line prints a message to the terminal.

- `Console` is a class in the .NET base libraries
- `WriteLine` is a method that outputs text to the console and moves to the next line
- The text inside quotes (`"Hello, World!"`) is called a **string literal**

---

### ✏️ Step 3: Make It Your Own

Try changing the message:

```csharp
Console.WriteLine("My name is Soheil.");
```

You can also declare a variable and use it:

```csharp
string name = "Soheil";
Console.WriteLine("Hello, " + name + "!");
```

Or use **string interpolation**:

```csharp
Console.WriteLine($"Hello, {name}!");
```

---

### ▶️ Step 4: Run Your App

Click the green **Run** button (or press `Ctrl + F5`) to execute your code.  
You should see the message printed in the terminal window.

To prevent the console window from closing immediately, you can add this line at the end of your `Main` method:

```csharp
Console.ReadKey();
```

This waits for the user to press a key before closing the window.

Congratulations! You’ve just written and run your first C# program 🎉
