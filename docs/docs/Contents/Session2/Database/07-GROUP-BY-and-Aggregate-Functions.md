---
title: GROUP BY and Aggregate Functions
---

Aggregate functions summarize data across multiple rows. You often use them with `GROUP BY` to group records by a specific column.

## 🔹Aggregate Functions

Aggregate functions summarize data across multiple rows. You often use them with `GROUP BY` to group records by a specific column.

| Function | Description               |
| -------- | ------------------------- |
| `COUNT`  | Counts the number of rows |
| `SUM`    | Adds numeric values       |
| `AVG`    | Calculates average        |
| `MIN`    | Finds minimum value       |
| `MAX`    | Finds maximum value       |

---

### 🔸 Example: Count Teachers per Subject

How many teachers are assigned to each subject?

```sql
SELECT s.Name AS Subject, COUNT(*) AS TeacherCount
FROM dbo.TeachingAssignment ta
JOIN dbo.Subject s ON ta.SubjectId = s.Id
GROUP BY s.Name;
```

- This groups teaching assignments by subject and counts how many assignments each has.
- If a subject is assigned more than once, it appears once in the result with the count.

---

### 🔸 Example: Count Teachers with No Assignment

Use `LEFT JOIN` + `GROUP BY` to find teachers with zero or more assignments.

```sql
SELECT t.FirstName + ' ' + t.LastName AS TeacherName, COUNT(ta.Id) AS AssignmentCount
FROM dbo.Teacher t
LEFT JOIN dbo.TeachingAssignment ta ON t.Id = ta.TeacherId
GROUP BY t.FirstName, t.LastName;
```

> 💡 If a teacher has no assignments, `COUNT(ta.Id)` will be `0`.

---

### 🔸 Use CASE to Translate WeekDay

Convert numeric weekdays into names (1 = Monday, etc.):

```sql
SELECT
  p.WeekDay,
  CASE p.WeekDay
    WHEN 1 THEN N'Monday'
    WHEN 2 THEN N'Tuesday'
    WHEN 3 THEN N'Wednesday'
    WHEN 4 THEN N'Thursday'
    WHEN 5 THEN N'Friday'
    ELSE N'Other'
  END AS WeekDayName
FROM dbo.Period p;
```

---

🟨 **Questions for students**

- Why must every selected column in a `GROUP BY` query be either aggregated or included in the `GROUP BY` clause?
- What’s the difference between `COUNT(*)` and `COUNT(column)`?

---

🟦 **Practice**

- Show teachers who have zero assignments?
- Show a list of subjects along with the number of classrooms they are taught in.
- Find the number of teaching assignments scheduled on each weekday (as a name).
- Show each classroom and how many different subjects are taught there.
