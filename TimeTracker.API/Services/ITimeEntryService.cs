using TimeTracker.Domain.Entities;
using TimeTracker.Domain.Models.TimeEntry;

namespace TimeTracker.API.Services;

public interface ITimeEntryService
{
    List<TimeEntryResponse> GetAllTimeEntries();
    List<TimeEntryResponse> CreateTimeEntry(TimeEntryCreateRequest timeEntryRequest);
}
