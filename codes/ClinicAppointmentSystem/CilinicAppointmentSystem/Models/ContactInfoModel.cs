using CAS.Application.Contract;

namespace CilinicAppointmentSystem.Models;

public class ContactInfoModel
{
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string MobileNumber { get; set; }

    public ContactInfoDto MapToDto()
    {
        return new ContactInfoDto()
        {
            Address = Address,
            MobileNumber = MobileNumber,
            PhoneNumber = PhoneNumber,
        };
    }
}