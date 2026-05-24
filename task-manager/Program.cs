using TaskManager.Models;
using TaskManager.Services;

var service = new TaskService();

Console.WriteLine("╔══════════════════════════════╗");
Console.WriteLine("║       C# Task Manager        ║");
Console.WriteLine("╚══════════════════════════════╝");

while (true)
{
    Console.WriteLine("\n[1] Add task   [2] List all    [3] List pending");
    Console.WriteLine("[4] Complete   [5] Delete      [6] Overdue");
    Console.WriteLine("[7] Filter tag [8] Stats       [0] Exit");
    Console.Write("\n> ");

    var choice = Console.ReadLine()?.Trim();

    switch (choice)
    {
        case "1":
            Console.Write("Title: ");
            var title = Console.ReadLine() ?? "";

            Console.Write("Priority (1=Low, 2=Medium, 3=High): ");
            var priority = Console.ReadLine() switch
            {
                "3" => Priority.High,
                "2" => Priority.Medium,
                _   => Priority.Low
            };

            Console.Write("Due date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out var due))
                due = DateTime.Today.AddDays(7);

            Console.Write("Tag (optional): ");
            var tag = Console.ReadLine() ?? "";

            var added = service.Add(title, priority, due, tag);
            Console.WriteLine($"\n✓ Added: {added}");
            break;

        case "2":
            PrintTasks(service.All(), "All Tasks");
            break;

        case "3":
            PrintTasks(service.Pending(), "Pending Tasks");
            break;

        case "4":
            Console.Write("Task ID to complete: ");
            if (int.TryParse(Console.ReadLine(), out var cId))
                Console.WriteLine(service.Complete(cId) ? "✓ Marked complete." : "Task not found.");
            break;

        case "5":
            Console.Write("Task ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out var dId))
                Console.WriteLine(service.Delete(dId) ? "✓ Deleted." : "Task not found.");
            break;

        case "6":
            PrintTasks(service.Overdue(), "Overdue Tasks");
            break;

        case "7":
            Console.Write("Tag: ");
            var filterTag = Console.ReadLine() ?? "";
            PrintTasks(service.ByTag(filterTag), $"Tasks tagged '{filterTag}'");
            break;

        case "8":
            Console.WriteLine("\n── Stats ──");
            foreach (var (p, count) in service.Stats())
                Console.WriteLine($"  {p,-8}: {count} task(s)");
            break;

        case "0":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Unknown command.");
            break;
    }
}

static void PrintTasks(IEnumerable<TaskItem> tasks, string header)
{
    var list = tasks.ToList();
    Console.WriteLine($"\n── {header} ({list.Count}) ──");
    if (list.Count == 0) { Console.WriteLine("  (none)"); return; }
    foreach (var t in list)
    {
        var color = t.IsOverdue ? ConsoleColor.Red
                  : t.Priority == Priority.High ? ConsoleColor.Yellow
                  : ConsoleColor.White;
        Console.ForegroundColor = color;
        Console.WriteLine("  " + t);
        Console.ResetColor();
    }
}
