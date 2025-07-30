---
title: Creating the SchoolDB Database
---

Use the steps below to create **SchoolDB** and then run the table‑creation script.  
Copy each SQL block into **SSMS** (or any SQL client) in the given order.

---

## 🔹 Create and Select the Database

```sql
-- Create a new database
CREATE DATABASE SchoolDB;
GO

-- Switch context to the new database
USE SchoolDB;
GO
```

---

## 🔹 _Entity_ Overview

| Entity / Table         | Purpose                                                                 |
| ---------------------- | ----------------------------------------------------------------------- |
| **Classroom**          | A fixed group of students assigned to a classroom (e.g., class "204").  |
| **Student**            | Each learner enrolled in one classroom.                                 |
| **Teacher**            | A staff member who teaches one or more subjects across classrooms.      |
| **Subject**            | A topic of instruction (e.g., Math, Science, etc.).                     |
| **Period**             | A time slot in the weekly schedule (e.g., Monday 09:00–09:45).          |
| **TeachingAssignment** | Maps a teacher to a subject, classroom, and period (e.g., Math in 204). |

## 🔹 SQL Table Script

```sql
CREATE TABLE dbo.Classroom
(
    Id        INT IDENTITY PRIMARY KEY,
    ClassName NVARCHAR(20) NOT NULL  -- e.g., "204"
);

-- Student
CREATE TABLE dbo.Student
(
    Id           INT IDENTITY PRIMARY KEY,
    ClassroomId  INT NOT NULL,
    FirstName    NVARCHAR(50) NOT NULL,
    LastName     NVARCHAR(50) NOT NULL,
    BirthDate    DATE NOT NULL,
    CONSTRAINT FK_Student_Classroom
        FOREIGN KEY (ClassroomId) REFERENCES dbo.Classroom(Id)
);

-- Teacher
CREATE TABLE dbo.Teacher
(
    Id         INT IDENTITY PRIMARY KEY,
    FirstName  NVARCHAR(50) NOT NULL,
    LastName   NVARCHAR(50) NOT NULL,
    HireDate   DATE NOT NULL
);


-- Subject
CREATE TABLE dbo.Subject
(
    Id   INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL  -- e.g., "Math"
);


-- Period
CREATE TABLE dbo.Period
(
    Id        INT IDENTITY PRIMARY KEY,
    WeekDay   TINYINT NOT NULL,  -- 1 = Monday, ..., 7 = Sunday
    StartTime TIME    NOT NULL,
    EndTime   TIME    NOT NULL
);

-- TeachingAssignment
CREATE TABLE dbo.TeachingAssignment
(
    Id          INT IDENTITY PRIMARY KEY,
    TeacherId   INT NOT NULL,
    SubjectId   INT NOT NULL,
    ClassroomId INT NOT NULL,
    PeriodId    INT NOT NULL,
    CONSTRAINT FK_Assign_Teacher
        FOREIGN KEY (TeacherId) REFERENCES dbo.Teacher(Id),
    CONSTRAINT FK_Assign_Subject
        FOREIGN KEY (SubjectId) REFERENCES dbo.Subject(Id),
    CONSTRAINT FK_Assign_Classroom
        FOREIGN KEY (ClassroomId) REFERENCES dbo.Classroom(Id),
    CONSTRAINT FK_Assign_Period
        FOREIGN KEY (PeriodId) REFERENCES dbo.Period(Id),
    CONSTRAINT UQ_Classroom_Period UNIQUE(ClassroomId, PeriodId)
);
```

---

## 🛠 How to Execute in SSMS

1. Open **SQL Server Management Studio** and connect to `(local)\SQLEXPRESS`.
2. Paste the first block into a new query window and press **F5**.
3. Paste the second block (table creation) and press **F5** again.
4. Refresh _Object Explorer_ → **Databases → SchoolDB → Tables**.

You now have a ready-to-use schema for querying and EF Core mapping.
