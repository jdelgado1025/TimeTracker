using TimeTracker.Domain.Entities;

namespace TimeTracker.API.Repositories.Time_Entry;

public class TimeEntryRepository : ITimeEntryRepository
{
    private static List<TimeEntry> _timeEntries = new List<TimeEntry>
    {
        new TimeEntry
        {
            Id = 1,
            Project = "Time Tracker App",
            End = DateTime.Now.AddHours(1)
        }
    };

    public List<TimeEntry> CreateTimeEntry(TimeEntry timeEntry)
    {
        _timeEntries.Add(timeEntry);
        return _timeEntries;
    }

    public List<TimeEntry> GetAllTimeEntries()
    {
        return _timeEntries;
    }

    public List<TimeEntry>? UpdateTimeEntry(int id, TimeEntry timeEntry)
    {
        var timeEntryIndex = _timeEntries.FindIndex(t => t.Id == id);
        if (_timeEntries[timeEntryIndex] == null)
            return null;

        _timeEntries[timeEntryIndex] = timeEntry;
        return _timeEntries;
    }
}
