using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Domain.Models.TimeEntry;

/* Data Transfer Object for Time Entry Request */
public class TimeEntryCreateRequest
{
    public required string Project { get; set; }
    public DateTime Start { get; set; } = DateTime.Now;
    public DateTime? End { get; set; }
}
