namespace CAS.Domain.DoctorAggregate;

public class DaySchedule
{
    //        //Saturday => 10:00 => 11:00
    // //Saturday => 11:00 => 12:00
    public DayOfWeek WorkDay { get; set; }
    public List<WorkingHours> Hours { get; set; }

    public List<DaySchedule2XXX> Generate(int sessionDuration, int restDuration)
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
        var result = new List<DaySchedule2XXX>();
        foreach (var hour in Hours)
        {
            var insideResult=new List<DaySchedule2XXX>();
            var hourDiff = hour.EndTime - hour.StartTime;
            var sessionCount = hourDiff.TotalMinutes / sessionDuration;

            var firstDayOfScheduleXXX = new DaySchedule2XXX()
            {
                WorkDay = WorkDay,
                StartTime = hour.StartTime,
                EndTime = hour.StartTime + TimeSpan.FromMinutes(sessionDuration),
            };

            insideResult.Add(firstDayOfScheduleXXX);

            for (var i = 1; i < sessionCount; i++)
            {
                var previousSessionEndTime = insideResult[i - 1].EndTime;
                var session = new DaySchedule2XXX()
                {
                    WorkDay = WorkDay,
                    StartTime = previousSessionEndTime,
                    EndTime = previousSessionEndTime + TimeSpan.FromMinutes(sessionDuration),
                };
                insideResult.Add(session);
            }
            result.AddRange(insideResult);
        }


        return result;
    }
}

public class WorkingHours
{
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}

public class DaySchedule2XXX
{
    public DayOfWeek WorkDay { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}