namespace TimeTracker.Domain.Models.TimeEntry;

public record struct TimeEntryResponse
(
    int Id,
    string Project,
    DateTime Start,
    DateTime? End
);
