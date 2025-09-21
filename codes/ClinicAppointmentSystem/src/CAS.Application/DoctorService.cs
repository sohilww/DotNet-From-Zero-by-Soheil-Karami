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
            _doctorRepository = doctorRepository;// => doc => depend on component
        }

        public async Task<IEnumerable<DoctorDto>> GetAll(CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetAll(cancellationToken);
            return doctors.Select(d => new DoctorDto
            {
                Id = d.Id,
                NationalCode = d.NationalCode,
                Name = d.Name,
                LastName = d.LastName,
                Speciality = d.Expertise,
                ContactInfo = d.ContactInfo
            });
        }

        public async Task<Guid> Create(CreateDoctorDto dto, CancellationToken cancellationToken)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            if (await _doctorRepository.AlreadyExists(dto.NationalCode, cancellationToken))
                throw new ArgumentOutOfRangeException();


            var doctor = new Doctor(
                name: dto.Name,
                lastname: dto.LastName,
                expertise: dto.Speciality,
                nationalCode: dto.NationalCode,
                contactInfo: dto.ContactInfo
            );

            await _doctorRepository.Create(doctor, cancellationToken);

            return doctor.Id;
        }

        public async Task Update(UpdateDoctorDto dto, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetById(dto.Id, cancellationToken);
            if (doctor == null) throw new KeyNotFoundException("Doctor not found");

            doctor.UpdateInfo(dto.Name, dto.LastName, dto.Speciality, dto.ContactInfo);

            await _doctorRepository.Update(doctor, cancellationToken);
        }
      

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetById(id, cancellationToken);
            if (doctor == null) throw new KeyNotFoundException("Doctor not found");

            await _doctorRepository.Delete(id, cancellationToken);
        }

        public async Task<IEnumerable<DoctorDto>> Search(string? name, string? speciality, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.Search(name, speciality, cancellationToken);
            return doctors.Select(d => new DoctorDto
            {
                Id = d.Id,
                Name = d.Name,
                LastName = d.LastName,
                Speciality = d.Expertise,
                ContactInfo = d.ContactInfo,
                NationalCode = d.NationalCode
            });
        }


    }
}
