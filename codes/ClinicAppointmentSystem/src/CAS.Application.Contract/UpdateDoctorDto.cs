namespace CAS.Application.Contract
{
    public class UpdateDoctorDto
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Speciality { get; set; }
        public string ContactInfo { get; set; }
        public string NationalCode { get; set; }
    }
}