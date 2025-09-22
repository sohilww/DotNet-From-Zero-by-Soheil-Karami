using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Domain.Models;

public class AppointmentPeriod
{
    public Guid PeriodId { get; private set; }
    public Guid ScheduleId { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }

    public AppointmentPeriod(Guid periodId, Guid scheduleId, TimeSpan startTime, TimeSpan endTime)
    {
        PeriodId = periodId;
        ScheduleId = scheduleId;
        StartTime = startTime;
        EndTime = endTime;
    }

}
