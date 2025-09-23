using CAS.Domain;

namespace CAS.Application.Contract
{
    public class CreateDoctorDto
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Expertise { get; set; }
        public string NationalCode { get; set; }
        public string MedicalRecordNumber { get; set; } = string.Empty;
        public List<Schedule> Schedule { get; }


      

      
    }
}
