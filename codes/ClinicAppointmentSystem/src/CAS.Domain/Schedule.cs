using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Domain.Models;
public class Schedule
{
    public Guid Id { get; private set; }
    public Guid DoctorId { get; private set; }
    public DayOfWeek DayOfWeek { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }
    public int Duration { get; private set; } // minutes
    public bool Enable { get; private set; } = true;
    public List<AppointmentPeriod> Periods { get; private set; } = new();

    public Schedule(Guid id, Guid doctorId, DayOfWeek dayOfWeek, TimeSpan startTime, TimeSpan endTime, int duration)
    {
        Id = id;
        DoctorId = doctorId;
        DayOfWeek = dayOfWeek;
        StartTime = startTime;
        EndTime = endTime;
        Duration = duration;
    }

    public void GeneratePeriods()
    {
    }

    public void Disable() => Enable = false;
    public void EnablePeriod() => Enable = true;
}
