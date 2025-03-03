namespace TimeTracker.Domain.Models.TimeEntry;

/* Data Transfer Object for Time Entry Request */
public record struct TimeEntryCreateRequest
(
    string Project,
    DateTime Start,
    DateTime? End
);
