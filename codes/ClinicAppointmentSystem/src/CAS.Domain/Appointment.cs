using Framework.Domain;

namespace CAS.Domain;

public class Appointment : AggregateRoot<AppointmentId>
{
    public DoctorId DoctorId { get; private set; }
    public PatientId PatientId { get; private set; }
    public DateTime Date { get; private set; }
    public AppointmentPeriodId PeriodId { get; private set; }
    public AppointmentStatus Status { get; private set; }

    public Appointment(AppointmentId id, DoctorId doctorId, PatientId patientId, DateTime date, AppointmentPeriodId periodId)
        : base(id)
    {
        DoctorId = doctorId ?? throw new ArgumentNullException(nameof(doctorId));
        PatientId = patientId ?? throw new ArgumentNullException(nameof(patientId));
        Date = date;
        PeriodId = periodId ?? throw new ArgumentNullException(nameof(periodId));
        Status = AppointmentStatus.Reserved;
    }

    public void Confirm()
    {
        Status = AppointmentStatus.Confirmed;
    }

    public void Cancel()
    {
        Status = AppointmentStatus.Canceled;
    }
}
