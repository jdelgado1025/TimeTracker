using System.Reflection.Metadata;

namespace TimeTracker.API.Repositories.Time_Entry;

public class TimeEntryRepository : ITimeEntryRepository
{
    private readonly DataContext _context;

    public TimeEntryRepository(DataContext context)
    {
        _context = context;
    }

    private static List<TimeEntry> _timeEntries = new List<TimeEntry>
    {
        new TimeEntry
        {
            Id = 1,
            Project = "Time Tracker App",
            End = DateTime.Now.AddHours(1)
        }
    };

    public async Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry)
    {
        _context.TimeEntries.Add(timeEntry);
        await _context.SaveChangesAsync();

        return await _context.TimeEntries.ToListAsync();
    }

    public List<TimeEntry>? DeleteTimeEntry(int id)
    {
        var entry = _timeEntries.Find(x => x.Id == id);

        if (entry == null)
            return null;

        _timeEntries.Remove(entry);
        return _timeEntries;
    }

    public List<TimeEntry> GetAllTimeEntries()
    {
        return _timeEntries;
    }

    public TimeEntry? GetTimeEntryById(int id)
    {
        return _timeEntries.FirstOrDefault(x => x.Id == id);
    }

    public List<TimeEntry>? UpdateTimeEntry(int id, TimeEntry timeEntry)
    {
        var timeEntryIndex = _timeEntries.FindIndex(t => t.Id == id);
        if (timeEntryIndex == -1)
            return null;

        _timeEntries[timeEntryIndex] = timeEntry;
        return _timeEntries;
    }
}
