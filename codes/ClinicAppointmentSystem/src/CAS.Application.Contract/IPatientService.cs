namespace CAS.Application.Contract;

public interface IPatientService
{
    Task<Guid> Create(CreatePatientDto dto, CancellationToken cancellationToken);
}


