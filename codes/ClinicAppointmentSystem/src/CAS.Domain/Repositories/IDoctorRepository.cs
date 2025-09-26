namespace CAS.Domain.Repositories;

public interface IDoctorRepository
{
    Task<DoctorId> Create(Doctor doctor, CancellationToken cancellationToken);
    Task<bool> AlreadyExists(string nationalCode,CancellationToken cancellationToken);
}