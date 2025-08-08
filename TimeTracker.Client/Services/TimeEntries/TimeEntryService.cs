using System.Net.Http.Json;
using TimeTracker.Domain.Models.TimeEntry;

namespace TimeTracker.Client.Services.TimeEntries;

public class TimeEntryService : ITimeEntryService
{
    public List<TimeEntryResponse> TimeEntries { get; set; } = new();

    public event Action? OnChange;
    private readonly HttpClient _httpClient;

    public TimeEntryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task GetTimeEntriesByProject(int projectId)
    {
        var timeEntries = (projectId <= 0) ? 
            await _httpClient.GetFromJsonAsync<List<TimeEntryResponse>>("api/timeentry") : await _httpClient.GetFromJsonAsync<List<TimeEntryResponse>>($"api/timeentry/project/{projectId}");

        if(timeEntries is not null)
        {
            TimeEntries = timeEntries;
            OnChange?.Invoke();
        }


    }
}
