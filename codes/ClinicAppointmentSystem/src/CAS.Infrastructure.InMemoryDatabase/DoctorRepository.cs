using CAS.Domain;
using CAS.Domain.Repositories;

namespace CAS.Infrastructure.InMemoryDatabase;

public class DoctorRepository : IDoctorRepository
{   
    static Dictionary<string, Doctor> _doctors = new Dictionary<string, Doctor>();  
    public async Task<Guid> Create(Doctor doctor, CancellationToken cancellationToken)
    {
        _doctors.Add(doctor.CodeMeli, doctor);
        return doctor.Id;
    }

    public async Task<bool> AlreadyExists(string codeMeli, CancellationToken cancellationToken)
    {
        return _doctors.ContainsKey(codeMeli);
    }
}