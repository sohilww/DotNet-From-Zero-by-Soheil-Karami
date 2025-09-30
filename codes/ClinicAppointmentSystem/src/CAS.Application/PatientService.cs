using CAS.Application.Contract;
using CAS.Domain;
using CAS.Domain.Repositories;

namespace CAS.Application
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Guid> Create(CreatePatientDto dto, CancellationToken cancellationToken)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var id = PatientId.Generate();
            var patient = new Patient(id, dto.FirstName, dto.LastName, new ContactInfo(
                dto.ContactInfoDto.PhoneNumber,
                dto.ContactInfoDto.MobileNumber,
                dto.ContactInfoDto.Address));

            await _patientRepository.Create(patient, cancellationToken);
            return patient.Id.DbId;
        }
    }
}


