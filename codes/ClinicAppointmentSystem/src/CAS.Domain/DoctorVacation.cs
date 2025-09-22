using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Domain;
public class DoctorVacation
{
    public Guid Id { get; private set; }
    public Guid DoctorId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string? Reason { get; private set; }

    public DoctorVacation(Guid id, Guid doctorId, DateTime start, DateTime end, string? reason = null)
    {
        Id = id;
        DoctorId = doctorId;
        StartDate = start;
        EndDate = end;
        Reason = reason;
    }
}
