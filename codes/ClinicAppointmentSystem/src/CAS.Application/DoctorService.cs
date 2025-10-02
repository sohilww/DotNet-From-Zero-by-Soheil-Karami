using CAS.Application.Contract;
using CAS.Domain;
using CAS.Domain.Repositories;

namespace CAS.Application
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository; // => doc => depend on component
        }

        public async Task<Guid> Create(CreateDoctorDto dto, CancellationToken cancellationToken)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            if (await _doctorRepository.AlreadyExists(dto.NationalCode, cancellationToken))
                throw new ArgumentOutOfRangeException();

            var id = DoctorId.Generate();

            var doctor = new Doctor(id,
                name: dto.Name,
                lastname: dto.LastName,
                expertise: dto.Speciality,
                nationalityCode: dto.NationalCode,
                medicalCouncilNumber: dto.MedicalCouncilNumber,
                gender: (Gender)dto.Gender, new ContactInfo()
                {
                    Address = dto.ContactInfoDto.Address,
                    MobileNumber = dto.ContactInfoDto.MobileNumber,
                    PhoneNumber = dto.ContactInfoDto.PhoneNumber
                });

            await _doctorRepository.Create(doctor, cancellationToken);

            return doctor.Id.DbId;
        }

        public async Task<Guid> CreateSchedule(CreateScheduleDto dto, CancellationToken cancellationToken)
        {
            //one level of abstraction
            await GuardAgainstInvalidDoctorId(dto.DoctorId, cancellationToken);
            
            
            return Guid.Empty;
        }

        private async Task GuardAgainstInvalidDoctorId(Guid doctorId, CancellationToken cancellationToken)
        {
            if (!await _doctorRepository.AlreadyExists(doctorId, cancellationToken))
                throw new KeyNotFoundException();
        }
    }
}