---
title: Databases 101
---

> **Context for students:**  
> Before anything you need a mental map of the database landscape—why different engines exist, when to choose which, and how they shape your code.

# Databases 101

---

## 🔹 What is a Database?

A **database** is an organized, persistent store of data plus the software that lets you **create, read, update, and delete** that data safely and efficiently.

---

## 🔹 Broad Families

| Family               | Core Idea                                                                                                                         | Typical Query Language                                |
| -------------------- | --------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------- |
| **Relational (SQL)** | Tables with rows & columns; strong, predefined schema.                                                                            | SQL (`SELECT … FROM …`)                               |
| **NoSQL**            | “Not only SQL” — flexible or schema‑on‑read; optimized for specific data models and scale‑out.                                    | Engine‑specific APIs; some support SQL‑like languages |
| **NewSQL**           | Combines relational model with distributed, horizontal scaling while retaining ACID transactions. _(e.g., CockroachDB, Yugabyte)_ | ANSI‑SQL or PostgreSQL‑compatible dialects            |

---

## 🔹 Popular Relational (SQL) Databases

| Engine              | Vendor             |
| ------------------- | ------------------ |
| **SQL Server**      | Microsoft          |
| **PostgreSQL**      | Community          |
| **MySQL / MariaDB** | Oracle / Community |
| **Oracle DB**       | Oracle             |
| **SQLite**          | Public Domain      |

---

## 🔹 Popular NoSQL Databases

| Engine        | Data Model            |
| ------------- | --------------------- |
| **MongoDB**   | Document (JSON/BSON)  |
| **Redis**     | Key‑Value (in‑memory) |
| **Cassandra** | Wide‑Column           |
| **Neo4j**     | Graph                 |

---

### NoSQL Sub‑Types at a Glance

| Sub‑Type        | Data Shape            | Example Engines    |
| --------------- | --------------------- | ------------------ |
| **Document**    | Nested JSON docs      | MongoDB, Couchbase |
| **Key‑Value**   | Simple key ⇢ blob     | Redis, DynamoDB    |
| **Wide‑Column** | Sparse, column‑family | Cassandra, HBase   |
| **Graph**       | Nodes + Edges         | Neo4j              |

---

## 🔹 Why Did NoSQL Emerge?

1. **Horizontal Scalability** — shard across many cheap servers.
2. **Flexible Schema** — evolve data structures quickly.
3. **Big Data / High Throughput** — billions of writes per day (e.g., IoT).
4. **Polyglot Persistence** — “pick the right tool for each sub‑domain.”
5. **ACID** (SQL) ↔ **BASE** (Basically Available, Soft state, Eventually consistent).

> Relational engines scale **vertically** (bigger machine) with ACID.  
> NoSQL trades parts of ACID (or consistency) for partition‑tolerant scale.

---

## 🔹 Spotlight: SQL Server for .NET Developers

_SQL Server_ is Microsoft’s flagship RDBMS:

- Editions: Express (free), Developer (full but non‑prod), Standard, Enterprise.
- Features: T‑SQL, **Columnstore indexes**, JSON functions, in‑memory OLTP, built‑in **SQL CLR** for C#.
- Works natively with **Entity Framework Core**, Visual Studio tooling.

🟦 **Practice**

- Install SQL Server On your machine
- Pick a **Bounded Context** from your project (e.g., _Catalog_). Decide which database family suits it best and justify the choice in one paragraph.

🟩 **Practice Plus**

- spin up **SQL Server LocalDB** and **MongoDB Docker** containers and note the CLI commands you used.

---

## 🧹 Takeaways

- **Relational vs NoSQL** is not a _**war**_—it’s about trade‑offs.
- Know the **data model** (tabular, document, key‑value, graph) and **access patterns** before choosing an engine.
- Polyglot persistence is common; `”one solution rarely fits every sub‑domain.”`
