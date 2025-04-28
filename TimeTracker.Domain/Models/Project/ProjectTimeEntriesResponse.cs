namespace TimeTracker.Domain.Models.Project;
public record struct ProjectTimeEntriesResponse
(
    int Id,
    string Name,
    string? Description,
    DateTime? StartDate,
    DateTime? EndDate,
    List<ProjectTimeEntriesSubResponse> TimeEntries
);