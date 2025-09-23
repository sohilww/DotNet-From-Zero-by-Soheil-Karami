using CAS.Application.Contract;

namespace CilinicAppointmentSystem.Models
{
    public class CreateDoctorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Expertise { get; set; }
        public string NationalCode { get; set; }
        public string CodeMeli { get; set; }

        public CreateDoctorDto MapToDto()
        {
            return new CreateDoctorDto()
            {
                Name = Name,
                LastName = LastName,
                Expertise = Expertise,
                NationalCode = NationalCode,
                MedicalRecordNumber = CodeMeli,
            };
        }
    }
}