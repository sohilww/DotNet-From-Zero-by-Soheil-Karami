using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Domain;

//بازه های زمانی فعال هر دکتر برای رزرو در سیستم
public class DoctorActiveDays
{
    public Guid Id { get; private set; }
    public Guid DoctorId { get; private set; }
    public DateTime ActivityStartDate { get; private set; }
    public DateTime ActivityEndDate { get; private set; }

    public DoctorActiveDays(Guid id, Guid doctorId, DateTime start, DateTime end)
    {
        Id = id;
        DoctorId = doctorId;
        ActivityStartDate = start;
        ActivityEndDate = end;
    }
}
