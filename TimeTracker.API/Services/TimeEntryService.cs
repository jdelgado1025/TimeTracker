using TimeTracker.API.Repositories.Time_Entry;
using TimeTracker.Domain.Entities;
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
        var newEntry = new TimeEntry
        {
            Project = timeEntryRequest.Project,
            Start = timeEntryRequest.Start,
            End = timeEntryRequest.End
        };

        var result = _timeEntryRepo.CreateTimeEntry(newEntry);
        return result.Select(t => new TimeEntryResponse 
        { 
            Id = t.Id,
            Project = t.Project,
            Start = t.Start,
            End = t.End
        }).ToList();
    }

    public List<TimeEntryResponse> GetAllTimeEntries()
    {
        var result = _timeEntryRepo.GetAllTimeEntries();
        return result.Select(t => new TimeEntryResponse 
        { 
            Id = t.Id,
            Project = t.Project,
            Start = t.Start,
            End = t.End
        }).ToList();
    }
}
