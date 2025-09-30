using CAS.Domain;
using CAS.Domain.Repositories;

namespace CAS.Infrastructure.InMemoryDatabase;

public class DoctorVacationRepository : IDoctorVacationRepository
{
    static List<DoctorVacation> _vacations = new();

    public async Task<bool> IsDoctorOnVacation(DoctorId doctorId, DateTime date, CancellationToken cancellationToken)
    {
        return _vacations.Any(v => v.DoctorId.DbId == doctorId.DbId && date.Date >= v.StartDate.Date && date.Date <= v.EndDate.Date);
    }
}


