namespace CAS.Application.Contract
{
    public class CreateDoctorDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Speciality { get; set; }
        public string NationalCode { get; set; }
        public string MedicalCouncilNumber { get; set; }
        public GenderDto Gender { get; set; }
        public ContactInfoDto ContactInfoDto { get; set; }
    }
}
