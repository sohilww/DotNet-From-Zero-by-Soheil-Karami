namespace CAS.Application.Contract
{
    public interface IDoctorService
    {
        public Task<Guid> Create(CreateDoctorDto dto, CancellationToken cancellationToken);
        public Task Update(UpdateDoctorDto dto, CancellationToken cancellationToken);
        public Task Delete(Guid id, CancellationToken cancellationToken);
        public Task<IEnumerable<DoctorDto>> Search(string? name, string? speciality, CancellationToken cancellationToken);
        public Task<IEnumerable<DoctorDto>> GetAll(CancellationToken cancellationToken);
    }
}
