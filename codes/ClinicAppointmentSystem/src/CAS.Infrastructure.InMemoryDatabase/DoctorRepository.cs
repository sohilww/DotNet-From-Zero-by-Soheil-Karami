﻿using CAS.Domain;
using CAS.Domain.Repositories;

namespace CAS.Infrastructure.InMemoryDatabase;

public class DoctorRepository : IDoctorRepository
{   
    static Dictionary<string, Doctor> _doctors = new Dictionary<string, Doctor>();  
    public async Task<Guid> Create(Doctor doctor, CancellationToken cancellationToken)
    {
        _doctors.Add(doctor.NationalCode, doctor);
        return doctor.Id;
    }

    public async Task<bool> AlreadyExists(string nationalCode, CancellationToken cancellationToken)
    {
        return _doctors.ContainsKey(nationalCode);
    }
}