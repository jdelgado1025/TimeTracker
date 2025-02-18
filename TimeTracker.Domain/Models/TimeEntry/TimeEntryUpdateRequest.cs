using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Domain.Models.TimeEntry;

public class TimeEntryUpdateRequest
{
    /* Need ID property when using a LIST for updating correctly */
    public int Id { get; set; }
    public required string Project { get; set; }
    public DateTime Start { get; set; } = DateTime.Now;
    public DateTime? End { get; set; }
}
