namespace TimeTracker.Domain.Models.TimeEntry;

public record struct TimeEntryUpdateRequest
(
    int ProjectId,
    DateTime Start,
    DateTime? End
);
