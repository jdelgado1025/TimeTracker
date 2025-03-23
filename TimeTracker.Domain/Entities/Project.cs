namespace TimeTracker.Domain.Entities;
public class Project : SoftDeletableEntity
{
    public required string Name { get; set; }
    public List<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
    public ProjectDetails? ProjectDetails { get; set; }
}
