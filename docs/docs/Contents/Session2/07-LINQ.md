---
title: LINQ
---

# LINQ (Language Integrated Query)

**LINQ** lets you write expressive, SQL-like queries directly in C# against in-memory collections, databases, XML, etc. It improves readability, reduces boilerplate, and encourages declarative data processing.

---

## 🔹 Why LINQ?

- Unified, readable queries in pure C#.
- Consistent operators across arrays, lists, and databases (with providers).
- Fewer loops, less error-prone code.

🟨 **Questions for students**

- What kinds of data sources can LINQ query?

🟦 **Practice**

- Why might a LINQ be safer than manual loops?
- List three places you would replace a `for` loop with a LINQ query in your own codebase.

---

## 🔹 Data Sources LINQ Can Query

LINQ is not limited to arrays or lists. It is designed to work with **any data source that implements `IEnumerable<T>` or `IQueryable<T>`**.  
This means the same query operators can be used across very different kinds of data.

| LINQ Provider        | Example Sources                          | Notes                                                                 |
| -------------------- | ---------------------------------------- | --------------------------------------------------------------------- |
| **LINQ to Objects**  | Arrays, Lists, Dictionaries, Collections | Queries run in memory against `IEnumerable<T>`                        |
| **LINQ to SQL / EF** | SQL Server, PostgreSQL, MySQL, etc.      | Queries are translated into SQL and executed in the database engine   |
| **LINQ to XML**      | `XDocument`, `XElement`                  | Query XML trees using LINQ operators                                  |
| **Custom Providers** | JSON APIs, NoSQL, in-house data formats  | By implementing a provider, LINQ can target virtually any data source |

### Example: LINQ to Objects (in-memory)

```csharp
int[] numbers = new int[] { 1, 2, 3, 4, 5 };

IEnumerable<int> evens = numbers.Where(n => n % 2 == 0);

foreach (int n in evens)
{
    Console.WriteLine(n);
}
```

### Example: LINQ to XML

```csharp
XDocument doc = XDocument.Parse(@"
<People>
  <Person Name='Alice' Age='30' />
  <Person Name='Bob' Age='25' />
</People>");

IEnumerable<string> names =
    doc.Descendants("Person")
       .Where(p => (int)p.Attribute("Age") > 26)
       .Select(p => (string)p.Attribute("Name"));

foreach (string name in names)
{
    Console.WriteLine(name); // Alice
}
```

🟨 **Questions for students**

- What’s the benefit of having a unified query language for such different sources?
- Why do you think LINQ queries against a database should not always be written the same way as queries against an in-memory list?

🟦 **Practice**

- Create an XML document with a few `Book` elements.
- Write a LINQ query to select all books published after the year 2015.

## 🔹 From Loop to LINQ (Even Numbers)

### Without LINQ: classic `for` loop

```csharp
int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };

List<int> evenNumbersLoop = new List<int>();
for (int i = 0; i < numbers.Length; i++)
{
    if (numbers[i] % 2 == 0)
    {
        evenNumbersLoop.Add(numbers[i]);
    }
}

foreach (int n in evenNumbersLoop)
{
    Console.WriteLine(n);
}
```

### With LINQ — Query Syntax

```csharp
int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };

IEnumerable<int> evenNumbersQuery =
    from n in numbers
    where n % 2 == 0
    select n;

foreach (int n in evenNumbersQuery)
{
    Console.WriteLine(n);
}
```

### With LINQ — Method Syntax

```csharp
int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };

IEnumerable<int> evenNumbersMethod =
    numbers.Where(n => n % 2 == 0);

foreach (int n in evenNumbersMethod)
{
    Console.WriteLine(n);
}
```

🟨 **Questions for students**

- Which version feels clearer to you and why?
- How does the LINQ version reduce opportunities for bugs?

🟦 **Practice**

- Print all numbers **greater than 10** from a new `int[]` using both loop and LINQ.

---

## 🔹 Query Syntax vs Method Syntax

Both styles are equivalent. Choose consistency across your codebase.

```csharp
string[] words = new string[] { "apple", "book", "car", "ball", "camera" };

// Query syntax: words starting with 'c', ordered by length
IEnumerable<string> q1 =
    from w in words
    where w.StartsWith("c")
    orderby w.Length
    select w;

// Method syntax: same result
IEnumerable<string> q2 = words
    .Where(w => w.StartsWith("c"))
    .OrderBy(w => w.Length);

foreach (string w in q1) Console.WriteLine(w);
Console.WriteLine("---");
foreach (string w in q2) Console.WriteLine(w);
```

🟨 **Questions for students**

- When would you prefer query syntax over method syntax?
- How can mixing styles in one file impact readability?

🟦 **Practice**

- Using both syntaxes, select words whose length is between 3 and 5 inclusive.

---

## 🔹 Core Operators: `Where`, `Select`, `OrderBy`, `ThenBy`, `OrderByDescending`

### `Where` (filter)

```csharp
int[] numbers = new int[] { 3, 7, 2, 8, 5, 10 };
IEnumerable<int> filtered = numbers.Where(n => n > 5);

foreach (int n in filtered) Console.WriteLine(n);
```

### `Select` (map / projection)

```csharp
int[] numbers = new int[] { 1, 2, 3 };
IEnumerable<int> squares = numbers.Select(n => n * n);

foreach (int n in squares) Console.WriteLine(n);
```

### `OrderBy` / `ThenBy` / `OrderByDescending`

```csharp
string[] names = new string[] { "Ava", "Mina", "John", "Zed", "Adam" };

// primary: by length ascending, secondary: by alphabetical
IEnumerable<string> ordered = names
    .OrderBy(n => n.Length)
    .ThenBy(n => n);

foreach (string n in ordered) Console.WriteLine(n);

Console.WriteLine("--- Desc by length ---");
IEnumerable<string> orderedDesc = names.OrderByDescending(n => n.Length);
foreach (string n in orderedDesc) Console.WriteLine(n);
```

🟨 **Questions for students**

- What’s the difference between `OrderBy` and `ThenBy`?
- Why might sorting by multiple keys be useful?

🟦 **Practice**

- Sort a list of people by `Age`, then by `Name`.

---

## 🔹 Element Operators: `First`, `FirstOrDefault`, `Last`, `Single`, `SingleOrDefault`

These return a **single element** (or default) instead of a sequence.

```csharp
int[] nums = new int[] { 2, 4, 6, 8 };

// First: throws if sequence is empty or no match
int firstEven = nums.First(n => n % 2 == 0);

// FirstOrDefault: returns default(T) if empty or no match (0 for int)
int firstOverTen = nums.FirstOrDefault(n => n > 10);

// Last: throws if empty or no match
int lastEven = nums.Last(n => n % 2 == 0);

// Single: requires exactly one matching element; throws if 0 or >1
int onlyEight = new int[] { 8 }.Single(n => n == 8);

// SingleOrDefault: requires 0 or 1 match; throws if >1; returns default if 0
int maybeNine = nums.SingleOrDefault(n => n == 9);

Console.WriteLine(firstEven);
Console.WriteLine(firstOverTen);  // 0
Console.WriteLine(lastEven);
Console.WriteLine(onlyEight);
Console.WriteLine(maybeNine);     // 0
```

🟨 **Questions for students**

- When is `Single` safer than `First`?
- Why can `FirstOrDefault` hide bugs if you don’t check for defaults?

🟦 **Practice**

- From an array of emails, get the **single** email marked as primary. Handle the case where there are zero or multiple primaries.

---

## 🔹 Common Helpers: `Any`, `All`, `Contains`, `Distinct`, `Take`, `Skip`

```csharp
int[] values = new int[] { 1, 2, 2, 3, 4, 5 };

// Any: does any element match?
bool hasEven = values.Any(v => v % 2 == 0);

// All: do all elements match?
bool allPositive = values.All(v => v > 0);

// Contains: is a value present?
bool hasTwo = values.Contains(2);

// Distinct: remove duplicates
IEnumerable<int> uniqueValues = values.Distinct();

// Take/Skip: paging
IEnumerable<int> page1 = values.Take(3); // first 3
IEnumerable<int> page2 = values.Skip(3).Take(3);

Console.WriteLine(hasEven);
Console.WriteLine(allPositive);
Console.WriteLine(hasTwo);
foreach (int v in uniqueValues) Console.WriteLine(v);
Console.WriteLine("--- page1 ---");
foreach (int v in page1) Console.WriteLine(v);
Console.WriteLine("--- page2 ---");
foreach (int v in page2) Console.WriteLine(v);
```

🟨 **Questions for students**

- When does `All` on an empty sequence return `true`?
- How would you implement simple paging with `Skip`/`Take`?

🟦 **Practice**

- Remove duplicates from a list of product IDs and return the first page of size 5.

---

## 🔹 `SelectMany` (flatten nested sequences)

Use `SelectMany` to flatten nested lists.

```csharp
List<List<int>> matrix = new List<List<int>>
{
    new List<int> { 1, 2, 3 },
    new List<int> { 4, 5 },
    new List<int> { 6 }
};

IEnumerable<int> flat = matrix.SelectMany(row => row);

foreach (int n in flat) Console.WriteLine(n);
```

🟨 **Questions for students**

- How is `SelectMany` different from `Select`?
- When do you see nested sequences in real projects?

🟦 **Practice**

- Given a `List<User>` where each user has `List<string> Roles`, list all **distinct** roles across all users.

---

## 🔹 Grouping: `GroupBy`

Group elements by a key and iterate groups.

```csharp
string[] words = new string[] { "cat", "dog", "car", "apple", "cow" };

IEnumerable<IGrouping<char, string>> groups = words.GroupBy(w => w[0]);

foreach (IGrouping<char, string> g in groups)
{
    Console.WriteLine($"Group {g.Key}:");
    foreach (string item in g)
    {
        Console.WriteLine($" - {item}");
    }
}
```

🟨 **Questions for students**

- What is the element type of groups and items?
- How would you sort items inside each group by length?

🟦 **Practice**

- Group people by birth year and print group sizes, ordered by year ascending.

---

## 🔹 Aggregation: `Count`, `Sum`, `Average`, `Min`, `Max`

```csharp
int[] numbers = new int[] { 1, 2, 3, 4, 5 };

int count = numbers.Count();
int sum = numbers.Sum();
double avg = numbers.Average();
int min = numbers.Min();
int max = numbers.Max();

Console.WriteLine(count);
Console.WriteLine(sum);
Console.WriteLine(avg);
Console.WriteLine(min);
Console.WriteLine(max);
```

🟨 **Questions for students**

- What happens if you call `Average()` on an empty sequence?
- How can you safely compute an average when the sequence might be empty?

🟦 **Practice**

- Compute min, max, and average of exam scores; print `"N/A"` if there are no scores.

---

## 🔹 Deferred Execution

Queries are executed when iterated (e.g., `foreach`, `ToList()`, `First()`). Mutating the source before enumeration affects results.

```csharp
List<int> data = new List<int> { 1, 2, 3, 4, 5 };
IEnumerable<int> query = data.Where(n => n > 2);

data.Add(100); // modify before enumeration

foreach (int n in query)
{
    Console.WriteLine(n); // includes 100
}

// To freeze results now:
List<int> snapshot = query.ToList();
```

🟨 **Questions for students**

- Why can deferred execution be both a feature and a foot-gun?
- How do `ToList()` / `ToArray()` change the behavior?

🟦 **Practice**

- Build a query, then mutate the source both **before** and **after** calling `ToList()`; compare outputs.

---

## 📌 Summary

| Operator / Concept       | Purpose                                   |
| ------------------------ | ----------------------------------------- |
| `Where`                  | Filter elements                           |
| `Select`                 | Transform elements                        |
| `OrderBy/ThenBy`         | Sort by one or multiple keys              |
| `OrderByDescending`      | Sort descending                           |
| `First/FirstOrDefault`   | Take first (throw vs default)             |
| `Last`                   | Take last element                         |
| `Single/SingleOrDefault` | Enforce exactly one (or zero/one) element |
| `Any/All`                | Existential / universal checks            |
| `Contains`               | Membership test                           |
| `Distinct`               | Remove duplicates                         |
| `Take/Skip`              | Paging                                    |
| `SelectMany`             | Flatten nested sequences                  |
| `GroupBy`                | Group elements by a key                   |
| Aggregates               | `Count`, `Sum`, `Average`, `Min`, `Max`   |
| Deferred Execution       | Execution happens on enumeration          |
