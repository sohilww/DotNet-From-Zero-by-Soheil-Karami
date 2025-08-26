---
title: Understanding the SchoolDB SQL Script
---

This page walks you through each SQL command used to create the **SchoolDB** schema. Each section provides a deeper look into SQL syntax, reasoning, and its relationship to real-world database design.

---

## 🔹 Creating the Database

```sql
CREATE DATABASE SchoolDB;
GO
```

- `CREATE DATABASE` initializes a container for storing all tables, views, and other schema objects.
- This command creates a physical `.mdf` (data file) and `.ldf` (log file) in the default location unless configured otherwise.
- `GO` is a batch terminator, signaling the end of a command block to SQL Server.

> 💡 **Tip:** While you can issue multiple statements in a session, it's best practice to separate DDL statements (like `CREATE DATABASE`) with `GO` to prevent dependency errors.

> 🔧 **What is DDL?**  
> DDL stands for **Data Definition Language**—it includes SQL commands like `CREATE`, `ALTER`, and `DROP` that define or modify the **structure** of database objects such as tables, indexes, or schemas.  
> Unlike `SELECT` or `INSERT`, which deal with data itself (DML), DDL changes the _blueprint_ of the database.

---

## 🔹 Switching to the Database

```sql
USE SchoolDB;
GO
```

- `USE` changes the context to the newly created `SchoolDB`, so subsequent commands are executed within this database.

> 📌 **Real-world analogy:** Think of `USE` as changing your current working directory in a command-line terminal.

---

## 🔹 Creating Tables

### 🔸 `Classroom` Table

```sql
CREATE TABLE dbo.Classroom (
    Id INT IDENTITY PRIMARY KEY,
    ClassName NVARCHAR(20) NOT NULL  -- e.g., "204"
);
```

#### 🧠 Explanation

- **`CREATE TABLE`**: Defines a new table and its structure.
- **`dbo.Classroom`**: The table is created in the default schema `dbo`.
- **`Id INT`**: Integer column, commonly used for unique identifiers.
- **`IDENTITY`**: Auto-increments the value, making it ideal for surrogate keys.
- **`PRIMARY KEY`**: Ensures each row is uniquely identifiable.
- **`ClassName NVARCHAR(20)`**: Stores up to 20 characters of Unicode text. `NOT NULL` enforces that every row must have a value.

---

### 🔸 `Student` Table

```sql
CREATE TABLE dbo.Student (
    Id INT IDENTITY PRIMARY KEY,
    ClassroomId INT NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    BirthDate DATE NOT NULL,
    CONSTRAINT FK_Student_Classroom FOREIGN KEY (ClassroomId) REFERENCES dbo.Classroom(Id)
);
```

#### 🧠 Explanation

- Introduces a **foreign key**: `ClassroomId` links each student to a classroom.
- Uses **`DATE`** type for `BirthDate` — storing only the date (no time).
- `NVARCHAR(50)` for names allows up to 50 Unicode characters.

---

### 🔸 `Teacher` Table

```sql
CREATE TABLE dbo.Teacher (
    Id INT IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    HireDate DATE NOT NULL
);
```

- Very similar to `Student`, but includes a `HireDate` to track employment.

---

### 🔸 `Subject` Table

```sql
CREATE TABLE dbo.Subject (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL  -- e.g., "Math"
);
```

- Simple table for listing academic subjects.

---

### 🔸 `Period` Table

```sql
CREATE TABLE dbo.Period (
    Id INT IDENTITY PRIMARY KEY,
    WeekDay TINYINT NOT NULL,  -- 1 = Monday, ..., 7 = Sunday
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL
);
```

#### 🧠 Explanation

- Introduces `TINYINT` for small-range integers (0–255). Ideal for days of the week.
- `TIME` stores time of day with high precision (e.g., '09:00:00').

---

### 🔸 `TeachingAssignment` Table

```sql
CREATE TABLE dbo.TeachingAssignment (
    Id INT IDENTITY PRIMARY KEY,
    TeacherId INT NOT NULL,
    SubjectId INT NOT NULL,
    ClassroomId INT NOT NULL,
    PeriodId INT NOT NULL,
    CONSTRAINT FK_Assign_Teacher FOREIGN KEY (TeacherId) REFERENCES dbo.Teacher(Id),
    CONSTRAINT FK_Assign_Subject FOREIGN KEY (SubjectId) REFERENCES dbo.Subject(Id),
    CONSTRAINT FK_Assign_Classroom FOREIGN KEY (ClassroomId) REFERENCES dbo.Classroom(Id),
    CONSTRAINT FK_Assign_Period FOREIGN KEY (PeriodId) REFERENCES dbo.Period(Id),
    CONSTRAINT UQ_Classroom_Period UNIQUE(ClassroomId, PeriodId)
);
```

#### 🧠 Explanation

- Demonstrates a **many-to-many** setup between teachers and subjects/classrooms/periods.
- Introduces a **composite unique constraint** to prevent duplicate assignments for the same classroom/period.

---

🟨 **Questions for students**

- Why is `INT IDENTITY` preferred over natural keys?
- How does a `FOREIGN KEY` improve data reliability?
- Why is a unique constraint important in `TeachingAssignment`?
- When should you avoid too many indexes?

---

🟦 **Practice**

- Create a table called `Exam` with:
  - `Id` (PK)
  - `CourseId` (FK to `Subject.Id`)
  - `ExamDate`
  - `TotalMarks`
- Add an index on `ExamDate` for fast sorting.
- Add an optional `Email` column to `Student`.
- Write a few **DML (Data Manipulation Language)** statements to work with data in your `SchoolDB`:
  - Use `INSERT` to add two new rows into the `Classroom` table (e.g., "101", "204").
  - Add three students using `INSERT` and assign them to the classrooms you just created.
  - Use `UPDATE` to change the `LastName` of one student.
  - Use `DELETE` to remove a student based on their `Id`.
  - Write a `SELECT` query to fetch all students along with their classroom name.

> 💡 Reminder: DML includes `INSERT`, `UPDATE`, `DELETE`, and `SELECT`—commands that modify or retrieve **data**, not structure.
