namespace CAS.Domain.Repositories;

public interface IDoctorRepository
{
    Task<Guid> Create(Doctor doctor, CancellationToken cancellationToken);
    Task<bool> AlreadyExists(string nationalCode,CancellationToken cancellationToken);
    Task Update(Doctor doctor, CancellationToken cancellationToken);
    Task Delete(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Doctor>> GetAll(CancellationToken cancellationToken);
    Task<Doctor?> GetById(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Doctor>> Search(string? name, string? speciality, CancellationToken cancellationToken);
}