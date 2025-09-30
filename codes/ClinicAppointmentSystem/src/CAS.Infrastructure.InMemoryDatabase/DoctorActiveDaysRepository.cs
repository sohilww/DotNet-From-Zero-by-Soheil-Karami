using CAS.Domain;
using CAS.Domain.Repositories;

namespace CAS.Infrastructure.InMemoryDatabase;

public class DoctorActiveDaysRepository : IDoctorActiveDaysRepository
{
    static List<DoctorActiveDays> _activeDays = new();

    public async Task<bool> IsWithinActiveDays(DoctorId doctorId, DateTime date, CancellationToken cancellationToken)
    {
        return _activeDays.Any(a => a.DoctorId.DbId == doctorId.DbId && date.Date >= a.ActivityStartDate.Date && date.Date <= a.ActivityEndDate.Date);
    }
}


