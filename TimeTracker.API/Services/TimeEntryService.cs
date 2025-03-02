using Mapster;

namespace TimeTracker.API.Services;

public class TimeEntryService : ITimeEntryService
{
    private readonly ITimeEntryRepository _timeEntryRepo;

    public TimeEntryService(ITimeEntryRepository timeEntryRepo)
    {
        _timeEntryRepo = timeEntryRepo;
    }

    public async Task<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreateRequest request)
    {
        var newEntry = request.Adapt<TimeEntry>();
        var result = await _timeEntryRepo.CreateTimeEntry(newEntry);

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

    public TimeEntryResponse? GetTimeEntryById(int id)
    {
        var result = _timeEntryRepo.GetTimeEntryById(id);
        if(result == null)
            return null;

        return result.Adapt<TimeEntryResponse>();
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
