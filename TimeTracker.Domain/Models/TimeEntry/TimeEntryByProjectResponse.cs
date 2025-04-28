using TimeTracker.Domain.Models.Project;

namespace TimeTracker.Domain.Models.TimeEntry;

public record struct TimeEntryByProjectResponse
(
    int Id,
    DateTime Start,
    DateTime? End
);
