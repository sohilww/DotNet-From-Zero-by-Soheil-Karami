using Framework.Domain;

namespace CAS.Domain;

public class ContactInfo : ValueObject
{
    public string PhoneNumber { get; }
    public string Address { get; }
    public string MobileNumber { get; }

    public ContactInfo(string phoneNumber, string mobileNumber, string address)
    {
        PhoneNumber = phoneNumber ?? string.Empty;
        MobileNumber = mobileNumber ?? string.Empty;
        Address = address ?? string.Empty;
    }
}