using CAS.Domain;
using CAS.Domain.Repositories;

namespace CAS.Infrastructure.InMemoryDatabase;

public class AppointmentRepository : IAppointmentRepository
{
    static Dictionary<Guid, Appointment> _appointments = new();

    public async Task<AppointmentId> Create(Appointment appointment, CancellationToken cancellationToken)
    {
        _appointments[appointment.Id.DbId] = appointment;
        return appointment.Id;
    }

    public async Task<Appointment?> GetById(AppointmentId id, CancellationToken cancellationToken)
    {
        _appointments.TryGetValue(id.DbId, out var value);
        return value;
    }

    public async Task<bool> ExistsForDoctorAt(DoctorId doctorId, DateTime date, AppointmentPeriodId periodId, CancellationToken cancellationToken)
    {
        return _appointments.Values.Any(a => a.DoctorId.DbId == doctorId.DbId && a.Date.Date == date.Date && a.PeriodId.DbId == periodId.DbId);
    }
}


