---
title: Understanding the SchoolDB SQL Script
---

This page walks you through each SQL command used to create the **SchoolDB** schema. We'll explain what each command does, why it's important, and how it relates to real-world application design.

---

## 🔹 Creating the Database

```sql
CREATE DATABASE SchoolDB;
GO
```

- `CREATE DATABASE`: This command creates a new SQL Server database named `SchoolDB`.
- `GO`: This tells SQL Server to execute the previous batch of commands.

> 💡 _Note: As the name suggests, a **Data Base** is only for storing and managing **data**—not for holding business logic._

---

## 🔹 Switching to the Database

```sql
USE SchoolDB;
GO
```

- `USE`: Changes the current working database context to `SchoolDB`, so all future commands apply to this database.

---

## 🔹 Creating Tables

Tables represent real-world entities like students or teachers. Let’s break down the structure.

### 🔸 Syntax: `CREATE TABLE`

```sql
CREATE TABLE dbo.Classroom (
    Id INT IDENTITY PRIMARY KEY,
    ClassName NVARCHAR(20) NOT NULL
);
```

- `dbo.Classroom`: A new table under the `dbo` schema.
- `Id INT IDENTITY PRIMARY KEY`: An auto-incrementing integer column that uniquely identifies each row.
  - `PRIMARY KEY`: Enforces uniqueness and makes the column the table’s identifier.
- `ClassName NVARCHAR(20) NOT NULL`: A required column for the classroom’s name.

---

## 🔹 What is a Primary Key?

A **Primary Key (PK)** is a column (or set of columns) that uniquely identifies each record. It must be:

- Unique
- Not null
- Indexed automatically

> 💡 Best practice: Always define a primary key in every table.

---

## 🔹 What is a Foreign Key?

A **Foreign Key (FK)** creates a link between two tables. It ensures that one table’s column (usually an `Id`) must exist in another table.

Example:

```sql
FOREIGN KEY (ClassroomId) REFERENCES dbo.Classroom(Id)
```

This line means:

> Every student’s `ClassroomId` must exist as an `Id` in the `Classroom` table.

---

## 🔹 Understanding Data Types

| Type       | Purpose                      | Example      |
| ---------- | ---------------------------- | ------------ |
| `INT`      | Whole numbers                | 1, 2, 100    |
| `NVARCHAR` | Variable-length Unicode text | N'Soheil'    |
| `DATE`     | Calendar date                | '2025-07-27' |
| `TIME`     | Clock time                   | '09:00:00'   |
| `TINYINT`  | Very small integer (0–255)   | 1 (Monday)   |

---

## 🔹 Unique Constraints

In this table:

```sql
CONSTRAINT UQ_Classroom_Period UNIQUE(ClassroomId, PeriodId)
```

We prevent a classroom from having **two teachers in the same time slot**. This is a real-life rule enforced in the database.

---

## 🧹 Summary

- You now understand how to create a database, define tables, and establish relationships.
- Use `PRIMARY KEY` for identity and `FOREIGN KEY` for connecting tables.
- Use the right `data types` to match real-world meaning and prevent errors.

---

🟨 **Questions for students**

- Why is it important to use `FOREIGN KEY` constraints in your database design?
- What might happen if two tables have no relationship defined between them?

---

🟦 Practice

- Create a new table `SubjectCategory` with:
  - `Id` (PK)
  - `Name` (e.g., "Science")
  - `Description` (optional)

Then add a `SubjectCategoryId` FK column to the existing `Subject` table.

---
