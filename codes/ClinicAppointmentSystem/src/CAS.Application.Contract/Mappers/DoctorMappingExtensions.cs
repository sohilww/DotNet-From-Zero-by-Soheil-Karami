using CAS.Application.Contract;

public static class DoctorMappingExtensions
{
    public static UpdateDoctorDto MapToDto(this UpdateDoctorModel model, Guid id)
    {
        return new UpdateDoctorDto
        {
            Id = id,
            Name = model.Name,
            LastName = model.LastName,
            Speciality = model.Speciality,
            NationalCode = model.NationalCode,
            ContactInfo =  model.ContactInfo
        };
    }
}