namespace TimeTracker.Domain.Models.TimeEntry;

/* Data Transfer Object for Time Entry Request */
public record struct TimeEntryCreateRequest
(
    int ProjectId,
    DateTime Start,
    DateTime? End
);
