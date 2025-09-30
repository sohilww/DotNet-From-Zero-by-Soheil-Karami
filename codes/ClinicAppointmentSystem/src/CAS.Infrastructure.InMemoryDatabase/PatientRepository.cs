using CAS.Domain;
using CAS.Domain.Repositories;

namespace CAS.Infrastructure.InMemoryDatabase;

public class PatientRepository : IPatientRepository
{
    static Dictionary<Guid, Patient> _patients = new();

    public async Task<PatientId> Create(Patient patient, CancellationToken cancellationToken)
    {
        _patients[patient.Id.DbId] = patient;
        return patient.Id;
    }

    public async Task<Patient?> GetById(PatientId id, CancellationToken cancellationToken)
    {
        _patients.TryGetValue(id.DbId, out var value);
        return value;
    }
}


