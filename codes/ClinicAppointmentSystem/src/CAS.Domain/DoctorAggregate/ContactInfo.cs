using Framework.Domain;

namespace CAS.Domain.DoctorAggregate;

public class ContactInfo : ValueObject
{
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string MobileNumber { get; set; }
}