using Mapster;
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

    public List<TimeEntryResponse> CreateTimeEntry(TimeEntryCreateRequest request)
    {
        var newEntry = request.Adapt<TimeEntry>();
        var result = _timeEntryRepo.CreateTimeEntry(newEntry);

        return result.Adapt<List<TimeEntryResponse>>();
    }

    public List<TimeEntryResponse>? DeleteTimeEntry(int id)
    {
        var result = _timeEntryRepo.DeleteTimeEntry(id);
        if (result == null)
            return null;

        return result.Adapt<List<TimeEntryResponse>>();
    }

    public List<TimeEntryResponse> GetAllTimeEntries()
    {
        var result = _timeEntryRepo.GetAllTimeEntries();
        return result.Adapt<List<TimeEntryResponse>>();
    }

    public List<TimeEntryResponse>? UpdateTimeEntry(int id, TimeEntryUpdateRequest request)
    {
        var updateEntry = request.Adapt<TimeEntry>();
        var result = _timeEntryRepo.UpdateTimeEntry(id, updateEntry);

        if(result == null)
            return null;

        return result.Adapt<List<TimeEntryResponse>>();
    }
}
