using CAS.Domain;
using CAS.Domain.Repositories;

namespace CAS.Infrastructure.InMemoryDatabase;

public class ClinicHolidayRepository : IClinicHolidayRepository
{
    static HashSet<DateTime> _holidays = new();

    public async Task<bool> IsHoliday(DateTime date, CancellationToken cancellationToken)
    {
        return _holidays.Contains(date.Date);
    }
}


