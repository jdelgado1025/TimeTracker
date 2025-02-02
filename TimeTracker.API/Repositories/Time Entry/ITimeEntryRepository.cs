using TimeTracker.Domain.Entities;

namespace TimeTracker.API.Repositories.Time_Entry;

public interface ITimeEntryRepository
{
    List<TimeEntry> GetAllTimeEntries();
    List<TimeEntry> CreateTimeEntry(TimeEntry timeEntry);
}
