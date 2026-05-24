namespace TaskManager.Models;

public enum Priority { Low, Medium, High }
public enum Status   { Pending, Done }

public class TaskItem
{
    public int      Id        { get; set; }
    public string   Title     { get; set; } = string.Empty;
    public string   Tag       { get; set; } = string.Empty;
    public Priority Priority  { get; set; }
    public Status   Status    { get; set; }
    public DateTime DueDate   { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public bool IsOverdue =>
        Status == Status.Pending && DueDate.Date < DateTime.Today;

    public override string ToString() =>
        $"[{Id}] {Title} | {Priority} | {Status} | Due: {DueDate:yyyy-MM-dd}" +
        (IsOverdue ? " ⚠ OVERDUE" : "");
}
