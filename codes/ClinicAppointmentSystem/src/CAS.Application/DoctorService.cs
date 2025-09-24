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
            _doctorRepository = doctorRepository; 
        }

        public async Task AddSchedule(string nationalCode, AddScheduleDto dto, CancellationToken cancellationToken)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            var doctor = await _doctorRepository.GetByNationalCode(nationalCode, cancellationToken);

            if (doctor is null)
                throw new InvalidOperationException($"Doctor with nationalCode {nationalCode} not found");

            doctor.AddSchedule(new(dto.DayOfWeek, dto.StartTime, dto.EndTime));
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

        public async Task<CAS.Application.Contract.GetDoctorDto> GetByNationalCode(string nationalCode, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetByNationalCode(nationalCode, cancellationToken);
            if (doctor is null)
                throw new InvalidOperationException($"Doctor with codeMeli {nationalCode} not found");

         
            return new CAS.Application.Contract.GetDoctorDto
            {
                Name = doctor.Name,
                LastName = doctor.Lastname,
                Speciality = doctor.Expertise,
                NationalCode = doctor.NationalCode,
                Schedules = doctor.Schedules.Select(s => new CAS.Application.Contract.ScheduleDto
                {
                    DayOfWeek = s.DayOfWeek,
                    StartTime = s.TimeRange.StartTime,
                    EndTime = s.TimeRange.EndTime
                }).ToList()
            };

        }
 
    }
}
