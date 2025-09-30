namespace CAS.Application.Contract;

public interface IScheduleService
{
    Task<Guid> Create(CreateScheduleDto dto, CancellationToken cancellationToken);
}


