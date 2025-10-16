namespace CAS.Domain.DoctorAggregate;

public class DaySchedule
{
    //        //Saturday => 10:00 => 11:00
    // //Saturday => 11:00 => 12:00
    public DayOfWeek WorkDay { get; set; }
    public List<WorkingHours> Hours { get; set; }

    public List<DayScheduleForCalculatingSlot> Generate(int sessionDuration, int restDuration)
    {
        //Saturday => 10:00 => 11:00
        //        //Saturday => 11:00 => 12:00
        //        //Saturday => 12:00 => 13:00
        //        //Saturday => 13:00 => 14:00
        //        
        //        
        //        
        //        //Saturday => 17:00 => 18:00
        //        //Saturday => 18:00 => 19:00
        //        //Saturday => 19:00 => 20:00
        var result = new List<DayScheduleForCalculatingSlot>();

        foreach (var workingHours in Hours)
        {
            var startTime = workingHours.StartTime;
            var endTime = workingHours.EndTime;

            while (startTime + TimeSpan.FromMinutes(sessionDuration) <= endTime)
            {
                var session = new DayScheduleForCalculatingSlot
                {
                    WorkDay = WorkDay,
                    StartTime = startTime,
                    EndTime = startTime + TimeSpan.FromMinutes(sessionDuration)
                };

                result.Add(session);

                startTime = session.EndTime + TimeSpan.FromMinutes(restDuration);
                }
            }

            return result;

    }
}

public class WorkingHours
{
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}