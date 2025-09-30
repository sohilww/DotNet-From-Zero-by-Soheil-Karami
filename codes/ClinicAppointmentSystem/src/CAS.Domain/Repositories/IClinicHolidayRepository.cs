namespace CAS.Domain.Repositories;

public interface IClinicHolidayRepository
{
    Task<bool> IsHoliday(DateTime date, CancellationToken cancellationToken);
}


