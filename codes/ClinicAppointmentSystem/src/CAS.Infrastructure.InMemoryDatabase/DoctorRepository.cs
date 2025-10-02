using CAS.Domain;
using CAS.Domain.Repositories;

namespace CAS.Infrastructure.InMemoryDatabase;

public class DoctorRepository : IDoctorRepository
{   
    static Dictionary<string, Doctor> _doctors = new Dictionary<string, Doctor>();  
    static List<Doctor> _doctorsList = new List<Doctor>();
    public async Task<DoctorId> Create(Doctor doctor, CancellationToken cancellationToken)
    {
        _doctors.Add(doctor.NationalityCode, doctor);
        _doctorsList.Add(doctor);
        return doctor.Id;
    }

    public async Task<bool> AlreadyExists(string nationalCode, CancellationToken cancellationToken)
    {
        return _doctors.ContainsKey(nationalCode);
    }

    public async Task<bool> AlreadyExists(Guid doctorId, CancellationToken cancellationToken)
    {
        return _doctorsList.Any(a=>Equals(a.Id, DoctorId.Generate(doctorId)));
    }
}