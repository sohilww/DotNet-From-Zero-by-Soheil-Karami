using CAS.Application.Contract;
using CAS.Domain;
using CAS.Domain.Repositories;

namespace CAS.Application
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<Guid> Create(CreateScheduleDto dto, CancellationToken cancellationToken)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var id = ScheduleId.Generate();
            var schedule = new Schedule(id, new DoctorId(dto.DoctorId), dto.DayOfWeek, dto.StartTime, dto.EndTime, dto.Duration);
            schedule.GeneratePeriods();

            await _scheduleRepository.Create(schedule, cancellationToken);
            return schedule.Id.DbId;
        }
    }
}


