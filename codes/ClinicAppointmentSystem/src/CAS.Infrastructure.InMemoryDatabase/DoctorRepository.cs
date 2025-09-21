using CAS.Domain;
using CAS.Domain.Repositories;

namespace CAS.Infrastructure.InMemoryDatabase;

public class DoctorRepository : IDoctorRepository
{
    private static Dictionary<string, Doctor> _doctors = new();

    public Task<IEnumerable<Doctor>> GetAll(CancellationToken cancellationToken)
    {
        return Task.FromResult(_doctors.Values.AsEnumerable());
    }

    public Task<Guid> Create(Doctor doctor, CancellationToken cancellationToken)
    {
        _doctors.Add(doctor.NationalCode, doctor);
        return Task.FromResult(doctor.Id);
    }

    public Task<bool> AlreadyExists(string nationalCode, CancellationToken cancellationToken)
    {
        return Task.FromResult(_doctors.ContainsKey(nationalCode));
    }

    public Task Update(Doctor doctor, CancellationToken cancellationToken)
    {
        _doctors[doctor.NationalCode] = doctor;
        return Task.CompletedTask;
    }

    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var doctor = _doctors.Values.FirstOrDefault(d => d.Id == id);
        if (doctor != null)
        {
            _doctors.Remove(doctor.NationalCode);
        }
        return Task.CompletedTask;
    }

    public Task<Doctor?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var doctor = _doctors.Values.FirstOrDefault(d => d.Id == id);
        return Task.FromResult(doctor);
    }

    public Task<IEnumerable<Doctor>> Search(string? name, string? speciality, CancellationToken cancellationToken)
    {
        var query = _doctors.Values.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
                                   || d.LastName.Contains(name, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrWhiteSpace(speciality))
            query = query.Where(d => d.Expertise.Contains(speciality, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(query);
    }
}