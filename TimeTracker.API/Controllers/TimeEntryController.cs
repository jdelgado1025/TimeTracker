using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.API.Repositories.Time_Entry;
using TimeTracker.API.Services;
using TimeTracker.Domain.Entities;
using TimeTracker.Domain.Models.TimeEntry;

namespace TimeTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeEntryController : ControllerBase
{
    private readonly ITimeEntryService _timeEntryService;

    public TimeEntryController(ITimeEntryService timeEntryService)
    {
        _timeEntryService = timeEntryService;
    }

    [HttpGet]
    public ActionResult<List<TimeEntryResponse>> GetAllTimeEntries()
    {
        return Ok(_timeEntryService.GetAllTimeEntries());
    }

    [HttpGet("{id}")]
    public ActionResult<TimeEntryResponse> GetTimeEntryById(int id)
    {
        var result = _timeEntryService.GetTimeEntryById(id);
        if (result is null)
            return NotFound("Time Entry with ID not found or does not exist");

        return Ok(result);
    }

    [HttpPost]
    public ActionResult<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreateRequest timeEntry)
    {
        if (timeEntry == null)
            return BadRequest("Invalid Time Entry");

        return Ok(_timeEntryService.CreateTimeEntry(timeEntry));
    }

    [HttpPut("{id}")]
    public ActionResult<List<TimeEntryResponse>>? UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry)
    {
        var result = _timeEntryService.UpdateTimeEntry(id, timeEntry);
        if (result == null)
            return NotFound("Time Entry with the provided ID does not exist");

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public ActionResult<List<TimeEntryResponse>> DeleteTimeEntry(int id)
    {
        var result = _timeEntryService.DeleteTimeEntry(id);
        if (result == null)
            return NotFound("Time entry with ID not found or unable to delete");

        return Ok(result);
    }
}
