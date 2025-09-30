using CAS.Domain;
using CAS.Domain.Repositories;

namespace CAS.Infrastructure.InMemoryDatabase;

public class ScheduleRepository : IScheduleRepository
{
    static Dictionary<Guid, Schedule> _schedules = new();

    public async Task<ScheduleId> Create(Schedule schedule, CancellationToken cancellationToken)
    {
        _schedules[schedule.Id.DbId] = schedule;
        return schedule.Id;
    }

    public async Task<Schedule?> GetById(ScheduleId id, CancellationToken cancellationToken)
    {
        _schedules.TryGetValue(id.DbId, out var value);
        return value;
    }
}


