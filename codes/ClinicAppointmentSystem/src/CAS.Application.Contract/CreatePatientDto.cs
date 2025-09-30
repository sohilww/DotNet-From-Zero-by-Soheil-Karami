namespace CAS.Application.Contract;

public class CreatePatientDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public ContactInfoDto ContactInfoDto { get; set; } = new();
}


