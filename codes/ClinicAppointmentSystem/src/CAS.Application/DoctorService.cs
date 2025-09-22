using CAS.Application.Contract;
using CAS.Domain;
using CAS.Domain.Repositories;

namespace CAS.Application
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository  doctorRepository)
        {
            _doctorRepository = doctorRepository;// => doc => depend on component
        }
        public async  Task<Guid> Create(CreateDoctorDto dto, CancellationToken cancellationToken)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            if (await _doctorRepository.AlreadyExists(dto.NationalCode,cancellationToken))
                throw new ArgumentOutOfRangeException();
            
            
            var doctor = new Doctor(
               name: dto.Name,
               lastname: dto.LastName,
               expertise: dto.Speciality,
               nationalCode : dto.NationalCode
           );
            
            await _doctorRepository.Create(doctor, cancellationToken);

            return doctor.Id;
        }

   
    }
}
