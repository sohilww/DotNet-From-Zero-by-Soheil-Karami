using CAS.Application.Contract;

namespace CilinicAppointmentSystem.Models
{
    public class CreateDoctorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Speciality { get; set; }
        public string NationalCode { get; set; }

        public CreateDoctorDto MapToDto()
        {
            return new CreateDoctorDto()
            {
                Name = Name,
                LastName = LastName,
                Speciality = Speciality,
                NationalCode = NationalCode
            };
        }
    }
}