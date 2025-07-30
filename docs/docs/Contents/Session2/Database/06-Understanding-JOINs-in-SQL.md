---
title: Understanding JOINs in SQL
---

## 🔹 Understanding JOINs in SQL

Before we dive into JOINs, make sure your database has data in it.  
Download and run the following SQL script to insert test data into all tables except `Student`:

📂 [insert.sql](./insert.sql)

> This script will populate the tables `Classroom`, `Subject`, `Teacher`, `Period`, and `TeachingAssignment`.

---

### 🔸 What is a JOIN?

A **JOIN** is used to combine rows from two or more tables based on a related column between them.

- `INNER JOIN`: Returns only the matching rows between tables.
- `LEFT JOIN`: Returns all rows from the left table, plus matched rows from the right table (or NULL).
- `RIGHT JOIN`: Opposite of LEFT JOIN.
- `FULL OUTER JOIN`: Returns rows when there is a match in **either** table.

---

### 🔸 INNER JOIN Example

Show all teaching assignments along with teacher names and subject titles:

```sql
SELECT
  t.FirstName + ' ' + t.LastName AS TeacherName,
  s.Name AS Subject,
  c.ClassName,
  p.WeekDay,
  p.StartTime,
  p.EndTime
FROM dbo.TeachingAssignment ta
INNER JOIN dbo.Teacher t ON ta.TeacherId = t.Id
INNER JOIN dbo.Subject s ON ta.SubjectId = s.Id
INNER JOIN dbo.Classroom c ON ta.ClassroomId = c.Id
INNER JOIN dbo.Period p ON ta.PeriodId = p.Id;
```

> 🔍 This query joins **five tables** to show a full view of each teaching session.

---

### 🔸 LEFT JOIN Example

Show all teachers, even if they haven’t been assigned to a class yet:

```sql
SELECT
  t.FirstName + ' ' + t.LastName AS TeacherName,
  s.Name AS Subject
FROM dbo.Teacher t
LEFT JOIN dbo.TeachingAssignment ta ON t.Id = ta.TeacherId
LEFT JOIN dbo.Subject s ON ta.SubjectId = s.Id;
```

> 📝 This will include teachers with no assignments — their subject will appear as `NULL`.

---

### 🔸 JOIN Tips

- Always alias your tables (`t`, `s`, `ta`, etc.) for better readability.
- Use `WHERE` after `JOIN` to apply filters.

🟨 **Questions for students**

- What’s the difference between `INNER JOIN` and `LEFT JOIN`?
- What happens if you `JOIN` on the wrong key?
- How would you retrieve all subjects, even if they have no teacher assigned?

---

🟦 **Practice**

- Write a query to list all classrooms along with the subject and teacher assigned.
- List all class sessions with weekday name (you may use `CASE` to translate `WeekDay` number to name).
