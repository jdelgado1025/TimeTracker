namespace TimeTracker.Domain.Models.Project;
public record struct ProjectTimeEntriesSubResponse
(
    int Id,
    DateTime? Start,
    DateTime? End
);