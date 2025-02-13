using TimeTracker.API.Repositories.Time_Entry;
using TimeTracker.Domain.Models.TimeEntry;

namespace TimeTracker.API.Services;

public class TimeEntryService : ITimeEntryService
{
    private readonly ITimeEntryRepository _timeEntryRepo;

    public TimeEntryService(ITimeEntryRepository timeEntryRepo)
    {
        _timeEntryRepo = timeEntryRepo;
    }

    public List<TimeEntryResponse> CreateTimeEntry(TimeEntryCreateRequest timeEntryRequest)
    {
        throw new NotImplementedException();
    }

    public List<TimeEntryResponse> GetAllTimeEntries()
    {
        throw new NotImplementedException();
    }
}
