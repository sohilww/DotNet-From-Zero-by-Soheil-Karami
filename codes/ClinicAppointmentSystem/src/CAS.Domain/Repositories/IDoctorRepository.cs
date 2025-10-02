namespace CAS.Domain.Repositories;

public interface IDoctorRepository
{
    Task<DoctorId> Create(Doctor doctor, CancellationToken cancellationToken);
    Task<bool> AlreadyExists(string nationalCode,CancellationToken cancellationToken);
    Task<bool> AlreadyExists(Guid doctorId,CancellationToken cancellationToken);
}