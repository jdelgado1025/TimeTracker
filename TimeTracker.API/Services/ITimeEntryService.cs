using TimeTracker.Domain.Entities;
using TimeTracker.Domain.Models.TimeEntry;

namespace TimeTracker.API.Services;

public interface ITimeEntryService
{
    TimeEntryResponse? GetTimeEntry(int id);
    List<TimeEntryResponse> GetAllTimeEntries();
    List<TimeEntryResponse> CreateTimeEntry(TimeEntryCreateRequest request);
    List<TimeEntryResponse>? UpdateTimeEntry(int id, TimeEntryUpdateRequest request);
    List<TimeEntryResponse>? DeleteTimeEntry(int id);
}
