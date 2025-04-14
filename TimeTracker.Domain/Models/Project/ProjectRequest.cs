namespace TimeTracker.Domain.Models.Project;
public record struct ProjectRequest
(
    string Name,
    string? Description,
    DateTime? StartDate,
    DateTime? EndDate
);
