using Framework.Domain;

namespace CAS.Domain;
public class DoctorVacation : Entity<DoctorVacationId>
{
    public DoctorId DoctorId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string? Reason { get; private set; }

    public DoctorVacation(DoctorVacationId id, DoctorId doctorId, DateTime start, DateTime end, string? reason = null)
        : base(id)
    {
        DoctorId = doctorId ?? throw new ArgumentNullException(nameof(doctorId));
        StartDate = start;
        EndDate = end;
        Reason = reason;
    }
}
