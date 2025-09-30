namespace CAS.Application.Contract;

public interface IAppointmentService
{
    Task<Guid> Create(CreateAppointmentDto dto, CancellationToken cancellationToken);
    Task Confirm(Guid appointmentId, CancellationToken cancellationToken);
    Task Cancel(Guid appointmentId, CancellationToken cancellationToken);
}


