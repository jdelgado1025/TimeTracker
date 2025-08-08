using TimeTracker.Domain.Models.TimeEntry;

namespace TimeTracker.Client.Services.TimeEntries;

public interface ITimeEntryService
{
    //Event to subscribe to for displaying Time Entries
    event Action? OnChange;
    public List<TimeEntryResponse> TimeEntries { get; set; }

    Task GetTimeEntriesByProject(int projectId);
}
