using CAS.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Domain.Models;

public class Appointment
{
    public Guid Id { get; private set; }
    public Guid DoctorId { get; private set; }
    public Guid PatientId { get; private set; }
    public DateTime Date { get; private set; }
    public Guid PeriodId { get; private set; }
    public AppointmentStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime ModifiedAt { get; private set; }

    public Appointment(Guid id, Guid doctorId, Guid patientId, DateTime date, Guid periodId)
    {
        Id = id;
        DoctorId = doctorId;
        PatientId = patientId;
        Date = date;
        PeriodId = periodId;
        Status = AppointmentStatus.Reserved;
        CreatedAt = DateTime.UtcNow;
        ModifiedAt = DateTime.UtcNow;
    }

    public void Confirm()
    {
        Status = AppointmentStatus.Confirmed;
        ModifiedAt = DateTime.UtcNow;
    }

    public void Cancel()
    {
        Status = AppointmentStatus.Canceled;
        ModifiedAt = DateTime.UtcNow;
    }
}
