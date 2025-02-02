using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Domain.Entities;

namespace TimeTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeEntryController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<TimeEntry>> GetAllTimeEntries()
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry)
    {
        return Ok();
    }
}
