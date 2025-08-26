## 🔹 Understanding CRUD Operations

The term **CRUD** stands for the four basic operations used to manage data in a database:

- **C**reate → `INSERT`
- **R**ead → `SELECT`
- **U**pdate → `UPDATE`
- **D**elete → `DELETE`

Let's go through each of them with examples for the `Student` table.

---

### 🔸 Create (INSERT)

The `INSERT` statement adds new rows to a table.

```sql
INSERT INTO dbo.Student (ClassroomId, FirstName, LastName, BirthDate)
VALUES (1, 'YourName', 'YourLastname', '2010-03-15');
```

- You don’t need to include the `Id` column because it’s auto-generated (`IDENTITY`).
- All `NOT NULL` columns must be included unless they have default values.

---

### 🔸 Read (SELECT)

The `SELECT` statement retrieves data from a table.

```sql
SELECT Id, FirstName, LastName, BirthDate
FROM dbo.Student
WHERE ClassroomId = 1;
```

- Use `WHERE` to filter results.
- You can also use `JOIN` to pull related data from multiple tables.

> 💡 Example with JOIN:

```sql
SELECT s.FirstName, s.LastName, c.ClassName
FROM dbo.Student s
JOIN dbo.Classroom c ON s.ClassroomId = c.Id;
```

---

### 🔸 Update (UPDATE)

The `UPDATE` statement modifies existing rows in a table.

```sql
UPDATE dbo.Student
SET LastName = 'Karami'
WHERE Id = 3;
```

- Always use a `WHERE` clause to avoid updating all rows unintentionally.

---

### 🔸 Delete (DELETE)

The `DELETE` statement removes one or more rows.

```sql
DELETE FROM dbo.Student
WHERE Id = 5;
```

- Be cautious: `DELETE` permanently removes data unless transactions are used.

🟩 **Practice Plus**

❓ **What is a transaction in SQL, and why would you use it when running DELETE or UPDATE statements?**

- Provide a simple explanation of what a transaction is.
- Give an example of a situation where a transaction can help prevent data loss or ensure data consistency.
- Bonus: Try writing a `BEGIN TRAN`, `ROLLBACK`, and `COMMIT` example.

> ⚠️ Without a `WHERE` clause, all rows in the table will be deleted.

---

🟨 **Questions for students**

- What happens if you run an `UPDATE` without a `WHERE` clause?
- What’s the difference between `DELETE` and `TRUNCATE`?
- When would you use `JOIN` in a `SELECT` statement?

---

🟦 **Practice**

1. Insert a new student named "Ali Rahimi" born on `'2012-05-20'` into classroom with `Id = 2`.
2. Retrieve all students whose last name starts with "A".
3. Update the birthdate of student `Id = 1` to `'2011-01-01'`.
4. Delete the student with `Id = 4`.

---

> 💡 **Working with Unicode strings in SQL Server**

Whenever you're working with **Unicode text** (like Persian, Arabic, or any non-Latin script), you must prefix your string with `N` to ensure it's correctly stored or compared.

This applies to:

- `INSERT` statements
- `UPDATE` values
- `WHERE` conditions
- `LIKE` filters
- `SELECT` string literals

```sql
-- Insert Persian name into the Student table
INSERT INTO dbo.Student (ClassroomId, FirstName, LastName, BirthDate)
VALUES (1, N'زهرا', N'مقصودی', '2011-02-14');

-- Filter using Unicode in WHERE
SELECT * FROM dbo.Student
WHERE FirstName = N'زهرا';

-- Update using Unicode
UPDATE dbo.Student
SET LastName = N'مقصودی'
WHERE FirstName = N'زهرا';
```

- `N'زهرا'` tells SQL Server to treat the value as **Unicode**.
- If you omit the `N`, non-Latin characters may get stored as `'???'` or return incorrect results in comparisons.

> ⚠️ Always use `N` when working with Unicode, even in filters or string comparisons.
