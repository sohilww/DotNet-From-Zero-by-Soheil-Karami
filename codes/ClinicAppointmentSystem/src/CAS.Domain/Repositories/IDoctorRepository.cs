namespace CAS.Domain.Repositories;

public interface IDoctorRepository
{
    Task<Guid> Create(Doctor doctor, CancellationToken cancellationToken);
    Task<bool> AlreadyExists(string medicalRecordNumber, CancellationToken cancellationToken);
}