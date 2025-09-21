using System.ComponentModel.DataAnnotations;

namespace CAS.Application.Contract
{
    public class UpdateDoctorModel
    {
        [Required]
        public string NationalCode { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Speciality { get; set; } = null!;
        [Required]
        public string ContactInfo { get; set; } = null!;
    }
}
