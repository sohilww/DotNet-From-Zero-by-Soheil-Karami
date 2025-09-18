using CAS.Application.Contract;
using CAS.Domain;

namespace CAS.Application
{
    public class DoctorService : IDoctorService
    {
        public Task<Guid> Create(CreateDoctorDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var doctor = new Doctor(
               name: dto.Name,
               lastname: dto.LastName,
               expertise: dto.Speciality,
               workingDays: new List<int>()
           );

            return Task.FromResult(doctor.Id);
        }
    }
}
