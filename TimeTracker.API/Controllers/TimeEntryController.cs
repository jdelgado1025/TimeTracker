using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<List<TimeEntryResponse>>> CreateTimeEntry(TimeEntryCreateRequest timeEntry)
    {
        if (timeEntry == null)
            return BadRequest("Invalid Time Entry");

        return Ok(await _timeEntryService.CreateTimeEntry(timeEntry));
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
