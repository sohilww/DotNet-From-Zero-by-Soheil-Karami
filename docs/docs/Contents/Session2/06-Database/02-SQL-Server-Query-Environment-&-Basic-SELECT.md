---
title: SQL Server — Query Environment & Basic SELECT
---

# SQL Server — Query Environment & Basic SELECT

---

## 🔹 Where Do I Run SQL?

Simply install **SQL Server Express** (or Developer Edition) and open **SQL Server Management Studio (SSMS)**.

1. Launch **SSMS** → _Connect_ to `(local)\SQLEXPRESS` (Windows Auth).
2. Open a **New Query** window — you’re ready to type T‑SQL.

_(Any T‑SQL client works, but all queries in this course come from SSMS.)_

---

🟦 **Practice**

- Research **SQL Server Express** and note _two_ key differences compared with **Developer** or **Standard** editions.  
  Summarize your findings in 2–3 bullet points.

---

## 🔹 Tables & Columns — The Building Blocks

| Concept         | Quick Definition                                               | Example                       |
| --------------- | -------------------------------------------------------------- | ----------------------------- |
| **Table**       | A named collection of rows that share the same set of columns. | `dbo.Students`                |
| **Column**      | A single field of data with a fixed type.                      | `FirstName NVARCHAR(50)`      |
| **Row**         | One record (tuple) in the table.                               | A single student              |
| **Primary Key** | Unique identifier for each row.                                | `Id INT IDENTITY PRIMARY KEY` |
| **Schema**      | Logical namespace for tables.                                  | `dbo`                         |

A table is like a spreadsheet: columns = headers, rows = data.  
SQL queries read or modify this tabular structure.

---

## 🔹 Anatomy of a Simple SELECT

```sql
SELECT  FirstName, LastName          -- WHAT columns?
FROM    dbo.Students                 -- FROM which table?
WHERE   EnrollmentYear = 2024        -- Optional filter
ORDER BY LastName;                   -- Optional sort
```

| Clause     | Ask yourself…                            |
| ---------- | ---------------------------------------- |
| `SELECT`   | What columns do I need?                  |
| `FROM`     | Which table (or view) contains them?     |
| `WHERE`    | Which rows match my criteria? (optional) |
| `ORDER BY` | How should the results be sorted? (opt.) |
| `GROUP BY` | Do I need aggregation? (optional)        |
| `HAVING`   | Filter aggregated rows? (optional)       |

---

### Bare‑bones Example

```sql
SELECT *
FROM   dbo.Products;
```

> Returns **all columns** and **all rows** — fine for quick inspection, dangerous in production.

---

🟨 **Questions for students**

- What happens if you omit `WHERE` on a 10 million‑row table?
- Why should you avoid `SELECT *` in most production code?

---

🟦 **Practice**

1. In SSMS, connect to your local SQL Server.
2. Run `SELECT @@VERSION;` and copy the result.
3. Create a table:

   ```sql
   CREATE TABLE dbo.Courses
   (
       Id    INT IDENTITY PRIMARY KEY,
       Title NVARCHAR(100)
   );
   ```

4. Insert three rows and write a `SELECT` that returns course titles alphabetically.

---

🟩 **Practice Plus**

- Use the command‑line tool **sqlcmd** to run the same `SELECT` on your `Courses` table.  
  Document the exact CLI command.

---

## 🧹 Takeaways

- A **table** stores rows; a **column** stores one field in every row.
- A `SELECT` reads data: `SELECT … FROM … WHERE … ORDER BY …`.
- Avoid `SELECT *` and always think about **row count** when skipping `WHERE`.
