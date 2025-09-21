namespace CAS.Application.Contract
{
    public class DoctorDto
    {
        public Guid Id { get; set; }
        public string NationalCode { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Speciality { get; set; }
        public string ContactInfo { get; set; }
    }
}