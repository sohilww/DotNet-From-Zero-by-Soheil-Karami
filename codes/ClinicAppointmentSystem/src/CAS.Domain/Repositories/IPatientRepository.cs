namespace CAS.Domain.Repositories;

public interface IPatientRepository
{
    Task<PatientId> Create(Patient patient, CancellationToken cancellationToken);
    Task<Patient?> GetById(PatientId id, CancellationToken cancellationToken);
}


