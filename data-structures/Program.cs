using DataStructures;

Console.WriteLine("╔══════════════════════════════════╗");
Console.WriteLine("║   C# Generic Data Structures     ║");
Console.WriteLine("╚══════════════════════════════════╝\n");

// ── Stack ─────────────────────────────────────────────────────────────────
Console.WriteLine("── Stack<int> ──");
var stack = new Stack<int>();
foreach (var n in new[] { 1, 2, 3, 4, 5 }) stack.Push(n);
Console.WriteLine($"  Pushed 1-5  |  Count: {stack.Count}  |  Peek: {stack.Peek()}");
Console.WriteLine($"  Popped: {stack.Pop()}  |  Count: {stack.Count}");
Console.WriteLine($"  Contents (top→bottom): {string.Join(", ", stack)}");

// ── Queue ─────────────────────────────────────────────────────────────────
Console.WriteLine("\n── Queue<string> ──");
var queue = new Queue<string>();
foreach (var s in new[] { "alpha", "beta", "gamma", "delta" }) queue.Enqueue(s);
Console.WriteLine($"  Enqueued: alpha, beta, gamma, delta  |  Count: {queue.Count}");
Console.WriteLine($"  Dequeued: {queue.Dequeue()}  |  Peek: {queue.Peek()}");
Console.WriteLine($"  Contents (front→back): {string.Join(", ", queue)}");

// ── LinkedList ───────────────────────────────────────────────────────────
Console.WriteLine("\n── LinkedList<int> ──");
var list = new LinkedList<int>();
list.AddLast(1); list.AddLast(2); list.AddLast(3);
list.AddFirst(0);
Console.WriteLine($"  List: {string.Join(" <-> ", list)}  |  Count: {list.Count}");
Console.WriteLine($"  Contains 2: {list.Contains(2)}  |  Contains 9: {list.Contains(9)}");
list.RemoveFirst(); list.RemoveLast();
Console.WriteLine($"  After RemoveFirst + RemoveLast: {string.Join(" <-> ", list)}");

// ── BST ──────────────────────────────────────────────────────────────────
Console.WriteLine("\n── BinarySearchTree<int> ──");
var bst = new BinarySearchTree<int>();
foreach (var n in new[] { 5, 3, 7, 1, 4, 6, 9 }) bst.Insert(n);
Console.WriteLine($"  Inserted: 5 3 7 1 4 6 9  |  Count: {bst.Count}  |  Height: {bst.Height()}");
Console.WriteLine($"  In-order:   {string.Join(", ", bst.InOrder())}");
Console.WriteLine($"  Pre-order:  {string.Join(", ", bst.PreOrder())}");
Console.WriteLine($"  Post-order: {string.Join(", ", bst.PostOrder())}");
Console.WriteLine($"  Contains 4: {bst.Contains(4)}  |  Contains 8: {bst.Contains(8)}");
