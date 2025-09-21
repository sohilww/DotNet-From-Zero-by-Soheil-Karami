namespace CAS.Domain;

public class Doctor
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string Expertise { get; private set; }
    public string NationalCode { get; private set; }
    public string ContactInfo { get; private set; }

    public Doctor(string name, string lastname, string expertise, string nationalCode, string contactInfo)
    {
        Id = Guid.NewGuid();
        Name = name;
        LastName = lastname;
        Expertise = expertise;
        NationalCode = nationalCode;
        ContactInfo = contactInfo;
    }

    public void UpdateInfo(string name, string lastName, string speciality, string contactInfo)
    {
        Name = name;
        LastName = lastName;
        Expertise = speciality;
        ContactInfo = contactInfo;
    }
}

