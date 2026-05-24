# C# Projects by Joe Habre

<p align="left">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"/>
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
  <img src="https://img.shields.io/badge/Platform-Linux%20%7C%20macOS%20%7C%20Windows-lightgrey?style=for-the-badge"/>
  <img src="https://img.shields.io/badge/License-MIT-green?style=for-the-badge"/>
</p>

![Build](https://github.com/Joeehabre/Csharp-Projects/actions/workflows/build.yml/badge.svg)

A collection of **C# / .NET 8** projects by **Joe Habre (AUB)**.  
Each project is self-contained and showcases distinct C# language features — from LINQ and generics to design patterns and OOP.

---

## Projects

| Folder | Description | Key Concepts |
|---|---|---|
| [`task-manager/`](task-manager/) | Full-featured CLI task manager with priorities, due dates, tags, and JSON persistence | LINQ, `System.Text.Json`, generics, enums |
| [`blackjack/`](blackjack/) | Terminal Blackjack with betting, dealer AI, and multi-round play | OOP, abstract classes, inheritance, polymorphism |
| [`data-structures/`](data-structures/) | Generic Stack, Queue, Doubly-Linked List, and BST from scratch | Generics, `IEnumerable<T>`, `yield return`, iterative in-order traversal |
| [`design-patterns/`](design-patterns/) | Observer, Factory, Strategy, and Builder patterns with real examples | Interfaces, fluent API, SOLID principles |

---

## Quick Start

**Requirements:** [.NET 8 SDK](https://dotnet.microsoft.com/download)

```bash
git clone https://github.com/Joeehabre/Csharp-Projects.git
cd Csharp-Projects
```

### task-manager
```bash
dotnet run --project task-manager/task-manager.csproj
```

### blackjack
```bash
dotnet run --project blackjack/blackjack.csproj
```

### data-structures
```bash
dotnet run --project data-structures/data-structures.csproj
```

### design-patterns
```bash
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

**Concepts:** LINQ (`Where`, `GroupBy`, `ToDictionary`, `OrderBy`), JSON serialization, `enum`, POCO models

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

**Concepts:** Generics with constraints (`where T : IComparable<T>`), `IEnumerable<T>`, `yield return`, iterative and recursive traversal

**Sample output:**
```
── Stack<int> ──
  Pushed 1-5  |  Count: 5  |  Peek: 5
  Popped: 5   |  Count: 4
  Contents (top→bottom): 4, 3, 2, 1

── Queue<string> ──
  Enqueued: alpha, beta, gamma, delta  |  Count: 4
  Dequeued: alpha  |  Peek: beta
  Contents (front→back): beta, gamma, delta

── LinkedList<int> ──
  List: 0 <-> 1 <-> 2 <-> 3  |  Count: 4
  Contains 2: True  |  Contains 9: False
  After RemoveFirst + RemoveLast: 1 <-> 2

── BinarySearchTree<int> ──
  Inserted: 5 3 7 1 4 6 9  |  Count: 7  |  Height: 3
  In-order:   1, 3, 4, 5, 6, 7, 9
  Pre-order:  5, 3, 1, 4, 7, 6, 9
  Post-order: 1, 4, 3, 6, 9, 7, 5
  Contains 4: True  |  Contains 8: False
```

---

### 🧩 Design Patterns
Four classic GoF patterns demonstrated with practical C# examples.

| Pattern | Example | What it shows |
|---|---|---|
| **Observer** | Stock market price alerts | Events, loose coupling, `interface` subscriptions |
| **Factory** | Shape factory (Circle, Rectangle, Triangle) | Open/closed principle, polymorphic creation |
| **Strategy** | Sorting algorithms with benchmarks | Swappable algorithms, `Stopwatch`, generics |
| **Builder** | Fluent pizza builder | Fluent API, `init`-only properties, immutability |

**Sample output:**
```
── 1. Observer Pattern (Stock Market) ──
  📋 LOG    AAPL: $180.00 ▲ $185.50
  📋 LOG    AAPL: $185.50 ▼ $172.00
  🚨 ALERT  AAPL: $185.50 → $172.00  (7.3% change)
  📋 LOG    MSFT: $320.00 ▲ $348.00
  🚨 ALERT  MSFT: $320.00 → $348.00  (8.8% change)

── 2. Factory Pattern (Shapes) ──
  Circle       | Area:    78.54 | Perimeter:    31.42
  Rectangle    | Area:    24.00 | Perimeter:    20.00
  Triangle     | Area:     6.00 | Perimeter:    12.00

── 3. Strategy Pattern (Sorting) ──
  Bubble Sort  :  1843.2 µs
  Quick Sort   :    98.6 µs
  Merge Sort   :   112.4 µs
  Verified sorted: 0 ≤ 9998

── 4. Builder Pattern (Pizza) ──
  Your pizza:
    Size:   Large
    Crust:  Thick
    Sauce:  BBQ
    Cheese: Cheddar (extra)
    Tops:   Chicken, Red Onion, Jalapeños
```

---

## What I Learned

- Idiomatic C# — LINQ, nullable reference types, pattern matching, `init` properties
- Generic constraints and `IEnumerable<T>` / `yield return` for lazy iteration
- Classic GoF design patterns applied in real, runnable examples
- .NET 8 project structure, solution files, and CI with GitHub Actions

---

## License

[MIT](LICENSE)
