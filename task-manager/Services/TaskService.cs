using System.Text.Json;
using TaskManager.Models;

namespace TaskManager.Services;

public class TaskService
{
    private readonly string _filePath;
    private List<TaskItem> _tasks;
    private int _nextId;

    public TaskService(string filePath = "tasks.json")
    {
        _filePath = filePath;
        _tasks    = Load();
        _nextId   = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
    }

    // ── CRUD ─────────────────────────────────────────────────────────────────

    public TaskItem Add(string title, Priority priority, DateTime dueDate, string tag = "")
    {
        var task = new TaskItem
        {
            Id       = _nextId++,
            Title    = title,
            Priority = priority,
            DueDate  = dueDate,
            Tag      = tag
        };
        _tasks.Add(task);
        Save();
        return task;
    }

    public bool Complete(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task is null) return false;
        task.Status = Status.Done;
        Save();
        return true;
    }

    public bool Delete(int id)
    {
        var removed = _tasks.RemoveAll(t => t.Id == id) > 0;
        if (removed) Save();
        return removed;
    }

    // ── QUERIES (LINQ showcase) ───────────────────────────────────────────────

    public IEnumerable<TaskItem> All()       => _tasks.OrderBy(t => t.DueDate);
    public IEnumerable<TaskItem> Pending()   => _tasks.Where(t => t.Status == Status.Pending).OrderBy(t => t.DueDate);
    public IEnumerable<TaskItem> Overdue()   => _tasks.Where(t => t.IsOverdue).OrderBy(t => t.DueDate);
    public IEnumerable<TaskItem> ByTag(string tag)
        => _tasks.Where(t => t.Tag.Equals(tag, StringComparison.OrdinalIgnoreCase));
    public IEnumerable<TaskItem> ByPriority(Priority p)
        => _tasks.Where(t => t.Priority == p).OrderBy(t => t.DueDate);

    public Dictionary<Priority, int> Stats() =>
        _tasks.GroupBy(t => t.Priority)
              .ToDictionary(g => g.Key, g => g.Count());

    // ── PERSISTENCE ──────────────────────────────────────────────────────────

    private void Save() =>
        File.WriteAllText(_filePath, JsonSerializer.Serialize(_tasks,
            new JsonSerializerOptions { WriteIndented = true }));

    private List<TaskItem> Load()
    {
        if (!File.Exists(_filePath)) return new();
        try { return JsonSerializer.Deserialize<List<TaskItem>>(File.ReadAllText(_filePath)) ?? new(); }
        catch { return new(); }
    }
}
