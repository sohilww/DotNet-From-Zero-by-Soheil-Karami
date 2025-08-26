---
title: EF Core
---

# Entity Framework Core (EF Core)

**EF Core** is a modern, lightweight ORM for .NET. It maps your C# classes to database tables and lets you query data with **LINQ**, while EF Core translates queries to SQL and executes them on the database.

---

## 🔹 Why EF Core?

- Write queries in **C# with LINQ** instead of raw SQL.
- **Change tracking** for updates: modify objects, then `SaveChanges()`.
- **Migrations** to evolve your schema safely.
- Works with multiple providers (SQL Server, PostgreSQL, SQLite, MySQL, etc.).

🟨 **Questions for students**

- What benefits does an ORM provide compared to hand-written SQL?
- When might you still prefer raw SQL?

🟦 **Practice**

- List three risks that EF Core reduces for a beginner team.

---

## 🔹 Project Setup (Minimal)

> Install a provider (example: SQL Server) and EF tools:

```csharp
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

Add a **connection string** (e.g., in `appsettings.json`):

```csharp
{
  "ConnectionStrings": {
    "AppDb": "Server=localhost;Database=EfCoreDemo;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

Wire up **DbContext** in `Program.cs` (ASP.NET Core):

```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb")));
```

🟨 **Questions for students**

- What does the provider package (e.g., `SqlServer`) add beyond `Microsoft.EntityFrameworkCore`?
- Where should secrets (SQL credentials) be stored in production?

🟦 **Practice**

- Switch the provider to **SQLite** and run the same project with a local file database.

---

## 🔹 Model & DbContext

Define your domain models and a `DbContext` to represent the database session.

```csharp
using Microsoft.EntityFrameworkCore;

public sealed class Author
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;

    // Navigation
    public List<Book> Books { get; set; } = new List<Book>();
}

public sealed class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    // FK + Navigation
    public int AuthorId { get; set; }
    public Author? Author { get; set; }
}

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .Property(a => a.FullName)
            .HasMaxLength(200)
            .IsRequired();

        modelBuilder.Entity<Book>()
            .Property(b => b.Title)
            .HasMaxLength(300)
            .IsRequired();

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);
    }
}
```

🟨 **Questions for students**

- What is the difference between **navigation properties** and **foreign keys**?
- When would you prefer **Fluent API** over **Data Annotations**?

🟦 **Practice**

- Add an `Isbn` property to `Book` with `HasMaxLength(13)` and mark it required.

---

## 🔹 Migrations (Create/Update the Database)

Create and apply migrations:

```csharp
dotnet ef migrations add InitialCreate
dotnet ef database update
```

- `add`: scaffolds the migration based on model changes.
- `update`: applies migrations to the target database.

🟨 **Questions for students**

- What happens if you change your model but forget to add a migration?
- How do you revert a migration?

🟦 **Practice**

- Add a `PublishedOn` (DateTime) to `Book`, create a new migration, and update the DB.

---

## 🔹 Basic CRUD (Create / Read / Update / Delete)

### Helper to get a context

```csharp
using Microsoft.EntityFrameworkCore;

static AppDbContext CreateContext()
{
    DbContextOptions<AppDbContext> options =
        new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=localhost;Database=EfCoreDemo;Trusted_Connection=True;TrustServerCertificate=True")
            .Options;

    return new AppDbContext(options);
}
```

### Create

```csharp
using (AppDbContext db = CreateContext())
{
    Author author = new Author { FullName = "Robert C. Martin" };
    Book book = new Book { Title = "Clean Code", Author = author };

    db.Authors.Add(author);   // or db.Add(author)
    db.Books.Add(book);

    int changes = db.SaveChanges();
    Console.WriteLine($"Saved changes: {changes}");
}
```

### Read (LINQ Queries)

```csharp
using (AppDbContext db = CreateContext())
{
    List<string> titles = db.Books
        .Where(b => b.Title.Contains("Clean"))
        .OrderBy(b => b.Title)
        .Select(b => b.Title)
        .ToList();

    foreach (string t in titles) Console.WriteLine(t);
}
```

### Update

```csharp
using (AppDbContext db = CreateContext())
{
    Book? book = db.Books.FirstOrDefault(b => b.Title == "Clean Code");
    if (book != null)
    {
        book.Title = "Clean Code (2nd Edition)";
        db.SaveChanges();
    }
}
```

### Delete

```csharp
using (AppDbContext db = CreateContext())
{
    Book? book = db.Books.FirstOrDefault(b => b.Title.StartsWith("Clean"));
    if (book != null)
    {
        db.Books.Remove(book);
        db.SaveChanges();
    }
}
```

🟨 **Questions for students**

- What does EF track after you call `Add` vs after `Attach`?
- Why is `FirstOrDefault` often safer than `First`?

🟦 **Practice**

- Insert two authors and three books, then rename one book and delete another.

---

## 🔹 Relationships & Loading Data

### Include (eager loading)

```csharp
using Microsoft.EntityFrameworkCore;

using (AppDbContext db = CreateContext())
{
    List<Author> authors = db.Authors
        .Include(a => a.Books)
        .OrderBy(a => a.FullName)
        .ToList();

    foreach (Author a in authors)
    {
        Console.WriteLine(a.FullName);
        foreach (Book b in a.Books)
        {
            Console.WriteLine($"  - {b.Title}");
        }
    }
}
```

### Select optimized projections

```csharp
using Microsoft.EntityFrameworkCore;

using (AppDbContext db = CreateContext())
{
    var authorBooks = db.Authors
        .OrderBy(a => a.FullName)
        .Select(a => new
        {
            Name = a.FullName,
            Titles = a.Books.Select(b => b.Title).ToList()
        })
        .ToList();

    foreach (var item in authorBooks) Console.WriteLine($"{item.Name} ({item.Titles.Count})");
}
```

🟨 **Questions for students**

- When should you prefer `Include` vs. projecting only the fields you need?
- What performance issues can `Include` chains cause?

🟦 **Practice**

- Load authors with their books, but only project `{ AuthorName, BookCount }`.

---

## 🔹 Tracking vs. No-Tracking

- **Tracking** (default): EF watches entities; changes are persisted on `SaveChanges()`.
- **No-Tracking**: Faster for read-only queries; EF doesn’t track entities.

```csharp
using Microsoft.EntityFrameworkCore;

using (AppDbContext db = CreateContext())
{
    List<Book> readOnly = db.Books
        .AsNoTracking()
        .Where(b => b.Title.Contains("Clean"))
        .ToList();
}
```

🟨 **Questions for students**

- Why is `AsNoTracking()` helpful in API read endpoints?
- What happens if you modify a no-tracked entity and call `SaveChanges()`?

🟦 **Practice**

- Measure (informally) the difference between a tracked vs no-tracked read on 10k rows.

---

## 🔹 Async, Paging, Sorting

Use async to avoid blocking threads (esp. in web apps). Combine with paging for scalable queries.

```csharp
using Microsoft.EntityFrameworkCore;

using (AppDbContext db = CreateContext())
{
    int pageIndex = 0; // zero-based
    int pageSize = 10;

    List<Book> page = await db.Books
        .OrderBy(b => b.Title)
        .Skip(pageIndex * pageSize)
        .Take(pageSize)
        .AsNoTracking()
        .ToListAsync();

    Console.WriteLine($"Fetched {page.Count} books");
}
```

🟨 **Questions for students**

- Why should you always sort before `Skip/Take`?
- Where does async provide the biggest benefit?

🟦 **Practice**

- Implement a method `GetBooksPageAsync(int page, int size)` returning titles only.

---

## 🔹 Async and Await with EF Core

Entity Framework Core provides **async versions** of most query and save methods (`ToListAsync`, `FirstOrDefaultAsync`, `SaveChangesAsync`, etc.).  
These are critical in web applications where scalability and responsiveness matter.

---

### Why Async?

- **Non-blocking I/O**: Database operations take time, but `async` lets threads return to the pool while waiting.
- **Better scalability**: In ASP.NET Core, this allows the server to handle more concurrent requests.
- **Responsiveness**: Keeps applications (especially web apps and UIs) responsive under load.

---

### Example: Querying with Async

```csharp
using Microsoft.EntityFrameworkCore;

using (AppDbContext db = CreateContext())
{
    List<Book> books = await db.Books
        .OrderBy(b => b.Title)
        .ToListAsync();

    foreach (Book b in books)
    {
        Console.WriteLine(b.Title);
    }
}
```

---

### Example: FirstOrDefaultAsync

```csharp
using Microsoft.EntityFrameworkCore;

using (AppDbContext db = CreateContext())
{
    Book? book = await db.Books
        .FirstOrDefaultAsync(b => b.Title.Contains("Clean"));

    if (book != null)
    {
        Console.WriteLine($"Found: {book.Title}");
    }
}
```

---

### Example: SaveChangesAsync

```csharp
using Microsoft.EntityFrameworkCore;

using (AppDbContext db = CreateContext())
{
    Author author = new Author { FullName = "Kent Beck" };
    db.Authors.Add(author);

    int changes = await db.SaveChangesAsync();
    Console.WriteLine($"Saved {changes} changes.");
}
```

---

### When to Use Async

- Always in **web applications** (ASP.NET Core controllers, APIs).
- Useful in **desktop apps** with UI threads (to avoid blocking).
- Less critical in **small console apps** or background jobs with few queries.

---

🟨 **Questions for students**

- What happens to a thread while an async EF Core query is waiting on the database?
- Why is async less critical in a console app with a single user?

🟦 **Practice**

- Convert an existing sync query in your project to use `ToListAsync`.
- Write a method `GetAuthorByNameAsync(string name)` that returns the author or `null`.
- Insert a new `Book` and save it using `SaveChangesAsync`.

---

✅ **Tip**: Never block async calls with `.Result` or `.Wait()` — this can cause deadlocks in ASP.NET Core. Always use `await`.

## 🔹 Transactions & Concurrency (Intro)

### Simple transaction

```csharp
using Microsoft.EntityFrameworkCore.Storage;

using (AppDbContext db = CreateContext())
{
    using (IDbContextTransaction tx = db.Database.BeginTransaction())
    {
        try
        {
            Author author = new Author { FullName = "Martin Fowler" };
            db.Authors.Add(author);
            db.SaveChanges();

            Book book = new Book { Title = "Refactoring", AuthorId = author.Id };
            db.Books.Add(book);
            db.SaveChanges();

            tx.Commit();
        }
        catch
        {
            tx.Rollback();
            throw;
        }
    }
}
```

> For optimistic concurrency, add a `RowVersion` (`byte[]` with `.IsRowVersion()`) and handle `DbUpdateConcurrencyException`.

🟨 **Questions for students**

- What problem do transactions solve?
- How would you detect and resolve a concurrency conflict?

🟦 **Practice**

- Add a `RowVersion` to `Book` and simulate a concurrency conflict.

---

## 🔹 Error Handling (Friendly Failures)

```csharp
using Microsoft.EntityFrameworkCore;

try
{
    using AppDbContext db = CreateContext();

    Book book = new Book { Title = "" }; // invalid: required
    db.Books.Add(book);
    db.SaveChanges();
}
catch (DbUpdateException ex)
{
    Console.WriteLine("A database update error occurred.");
    Console.WriteLine(ex.InnerException?.Message);
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected: {ex.Message}");
}
```

> Validate early (e.g., in services) to avoid round-trip failures to the DB.

🟨 **Questions for students**

- Why should you validate DTOs before mapping to entities?
- What details are safe to log from `DbUpdateException`?

🟦 **Practice**

- Add simple guard clauses to ensure `Title` is not empty before saving.

---

## 🔹 Best Practices (Quick Checklist)

- Prefer **projections** (`Select`) to return only what you need.
- Use **`AsNoTracking()`** for read-only queries.
- Always **sort before paging**.
- Keep **transactions** small and focused.
- Use **async** for I/O-bound data access paths.
- Evolve schema with **migrations**, avoid manual schema drift.
- Centralize **validation** and avoid leaking entities outside domain boundaries.

---

## 📌 Summary

| Topic              | Purpose / Takeaway                                             |
| ------------------ | -------------------------------------------------------------- |
| DbContext & Models | Map classes to tables, set relationships                       |
| Migrations         | Version and apply schema changes safely                        |
| CRUD + LINQ        | Query, modify, and persist using C# and LINQ                   |
| Loading Data       | `Include` or projection; prefer minimal payloads               |
| Tracking           | Default tracks changes; use `AsNoTracking` for read-only       |
| Async & Paging     | Scale and keep threads free; always order before paging        |
| Transactions       | Group operations atomically                                    |
| Seeding            | Bootstrap reference data                                       |
| Error Handling     | Catch `DbUpdateException`; validate early                      |
| Best Practices     | Projection, no-tracking, small transactions, async, migrations |
