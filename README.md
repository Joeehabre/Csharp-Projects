# C# Projects by Joe Habre

![Build](https://github.com/Joeehabre/Csharp-Projects/actions/workflows/build.yml/badge.svg)

<p align="left">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"/>
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
  <img src="https://img.shields.io/badge/Platform-Linux%20%7C%20macOS%20%7C%20Windows-lightgrey?style=for-the-badge"/>
  <img src="https://img.shields.io/badge/License-MIT-green?style=for-the-badge"/>
</p>

A collection of **C# / .NET 8** projects covering CLI tools, OOP design patterns, generic data structures, and terminal games.  
Each project is self-contained and showcases distinct C# language features.

---

## Projects

| Folder | Description | Key Concepts |
|---|---|---|
| [`task-manager/`](task-manager/) | Full-featured CLI task manager with priorities, due dates, tags, and JSON persistence | LINQ, `System.Text.Json`, generics, enums |
| [`blackjack/`](blackjack/) | Terminal Blackjack with betting, dealer AI, and multi-round play | OOP, abstract classes, inheritance, polymorphism |
| [`data-structures/`](data-structures/) | Generic Stack, Queue, Doubly-Linked List, and BST from scratch | Generics, `IEnumerable<T>`, iterators, `yield return` |
| [`design-patterns/`](design-patterns/) | Observer, Factory, Strategy, and Builder patterns with real examples | Interfaces, delegates, fluent API, SOLID principles |

---

## Quick Start

**Requirements:** [.NET 8 SDK](https://dotnet.microsoft.com/download)

```bash
git clone https://github.com/Joeehabre/Csharp-Projects.git
cd Csharp-Projects
```

Run any project:

```bash
dotnet run --project task-manager/task-manager.csproj
dotnet run --project blackjack/blackjack.csproj
dotnet run --project data-structures/data-structures.csproj
dotnet run --project design-patterns/design-patterns.csproj
```

Or build everything at once:

```bash
dotnet build CsharpProjects.sln
```

---

## Project Details

### 🗂 Task Manager
A CLI task manager with full CRUD, filtering, and persistence.

**Features:**
- Add tasks with title, priority, due date, and tag
- Mark complete, delete, filter by tag or priority
- LINQ-powered queries: overdue tasks, stats grouped by priority
- JSON persistence via `System.Text.Json` — survives restarts
- Color-coded output: red for overdue, yellow for high priority

**Concepts:** LINQ (`Where`, `GroupBy`, `ToDictionary`, `OrderBy`), JSON serialization, `enum`, `record`-style models

---

### 🃏 Blackjack
A fully playable terminal Blackjack game.

**Features:**
- Complete 52-card deck with Fisher-Yates shuffle
- Ace value auto-adjustment (11 → 1 to avoid bust)
- Dealer AI — hits until reaching 17
- Betting system with balance tracking
- Blackjack pays 3:2; push returns bet

**Concepts:** Abstract classes (`Player`), inheritance (`HumanPlayer`, `Dealer`), polymorphism (`WantsHit`), encapsulation

---

### 📦 Data Structures
Four generic data structures built from scratch — no BCL equivalents used.

| Structure | Implementation | Complexity |
|---|---|---|
| `Stack<T>` | Dynamic array | Push/Pop O(1) amortized |
| `Queue<T>` | Circular buffer | Enqueue/Dequeue O(1) amortized |
| `LinkedList<T>` | Doubly-linked nodes | AddFirst/Last O(1) |
| `BinarySearchTree<T>` | Recursive nodes + iterative in-order | Insert/Search O(log n) avg |

**Concepts:** Generics with constraints (`where T : IComparable<T>`), `IEnumerable<T>`, `yield return`, operator overloading

---

### 🧩 Design Patterns
Four classic GoF patterns demonstrated with practical C# examples.

| Pattern | Example | What it shows |
|---|---|---|
| **Observer** | Stock market price alerts | Events, loose coupling, `interface` subscriptions |
| **Factory** | Shape factory (Circle, Rectangle, Triangle) | Open/closed principle, polymorphic creation |
| **Strategy** | Sorting algorithms with benchmarks | Swappable algorithms, `Stopwatch`, generics |
| **Builder** | Fluent pizza builder | Fluent API, immutable `record`-style products |

---

## What I Learned

- Idiomatic C# — LINQ, nullable reference types, pattern matching, `init` properties
- Generic constraints and `IEnumerable<T>` / `yield return` for lazy iteration
- Classic GoF design patterns applied in real, runnable examples
- .NET 8 project structure, solution files, and CI with GitHub Actions
