using System.ComponentModel.DataAnnotations;
using CAS.Application.Contract;
using CilinicAppointmentSystem.Attributes;

namespace CilinicAppointmentSystem.Models
{
    public class CreateDoctorModel 
    {
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Speciality { get; set; }
        [NationalityCodeValidation]
        public string NationalCode { get; set; }
        public string MedicalCouncilNumber { get; set; }
        public ContactInfoModel ContactInfoModel { get; set; }

        public GenderDto Gender { get; set; }
        
        public CreateDoctorDto MapToDto()
        {
            return new CreateDoctorDto()
            {
                Name = Name,
                LastName = LastName,
                Speciality = Speciality,
                NationalCode = NationalCode,
                MedicalCouncilNumber = MedicalCouncilNumber,
                ContactInfoDto = ContactInfoModel.MapToDto(),
                Gender = Gender
            };
        }
    }
}