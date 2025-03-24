using TimeTracker.Domain.Models.Project;

namespace TimeTracker.Domain.Models.TimeEntry;

public record struct TimeEntryResponse
(
    int Id,
    ProjectResponse Project,
    DateTime Start,
    DateTime? End
);
