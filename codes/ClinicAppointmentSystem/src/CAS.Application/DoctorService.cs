using CAS.Application.Contract;

namespace CAS.Application
{
    public class DoctorService : IDoctorService
    {
        public Task<Guid> Create(CreateDoctorDto dto)
        {
            Guid id = Guid.NewGuid();
            Doctor doctor = new Doctor();

            return Task.FromResult(id);
        }
    }
}
