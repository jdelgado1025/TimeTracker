using TimeTracker.Domain.Entities;

namespace TimeTracker.API.Repositories.Time_Entry;

public interface ITimeEntryRepository
{
    List<TimeEntry> GetAllTimeEntries();
    List<TimeEntry> CreateTimeEntry(TimeEntry timeEntry);
    List<TimeEntry>? UpdateTimeEntry(int id, TimeEntry timeEntry);
    List<TimeEntry>? DeleteTimeEntry(int id, TimeEntry timeEntry);
}
