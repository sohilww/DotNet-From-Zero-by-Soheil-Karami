namespace CAS.Domain.Repositories;

public interface IScheduleRepository
{
    Task<ScheduleId> Create(Schedule schedule, CancellationToken cancellationToken);
    Task<Schedule?> GetById(ScheduleId id, CancellationToken cancellationToken);
}


