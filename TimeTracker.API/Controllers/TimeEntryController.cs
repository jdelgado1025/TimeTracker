using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.API.Repositories.Time_Entry;
using TimeTracker.Domain.Entities;

namespace TimeTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeEntryController : ControllerBase
{
    private readonly ITimeEntryRepository _timeEntryRepo;

    public TimeEntryController(ITimeEntryRepository timeEntryRepo)
    {
        _timeEntryRepo = timeEntryRepo;
    }

    [HttpGet]
    public ActionResult<List<TimeEntry>> GetAllTimeEntries()
    {
        return Ok(_timeEntryRepo.GetAllTimeEntries());
    }

    [HttpPost]
    public ActionResult<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry)
    {
        if (timeEntry == null)
            return BadRequest("Invalid Time Entry");

        return Ok(_timeEntryRepo.CreateTimeEntry(timeEntry));
    }
}
