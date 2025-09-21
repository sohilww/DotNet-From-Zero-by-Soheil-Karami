using CAS.Application.Contract;
using CAS.Domain;
using CAS.Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CAS.Application.Tests;

public class DoctorServiceTests
{
    private readonly DoctorService _doctorService;
    private readonly DoctorRepositoryStub _doctorRepositoryStub;

    public DoctorServiceTests()
    {
        _doctorRepositoryStub = new DoctorRepositoryStub();
        _doctorService = new DoctorService(_doctorRepositoryStub);
    }

    [Fact]
    public async Task should_create_a_doctor()
    {
        var id = await _doctorService.Create(new CreateDoctorDto()
        {
            NationalCode = "5210010104",
            LastName = "Yousefi",
            Name = "Samaneh",
            Speciality = "General",
            ContactInfo = "0912000000"
        }, CancellationToken.None);

        id.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public async Task should_throw_an_exception_when_dto_is_null()
    {
        Func<Task> act = async () => { await _doctorService.Create(null, CancellationToken.None); };
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task should_throw_an_exception_when_doctor_already_exists()
    {
        var repository = Substitute.For<IDoctorRepository>();
        repository.AlreadyExists(Arg.Any<string>(), Arg.Any<CancellationToken>())
            .Returns(true);

        var service = new DoctorService(repository);

        Func<Task> act = async () => {
            await service.Create(new CreateDoctorDto()
            {
                NationalCode = "5210010104",
                LastName = "Yousefi",
                Name = "Samaneh",
                Speciality = "General",
                ContactInfo = "0912000000"
            }, CancellationToken.None);
        };

        await act.Should().ThrowAsync<ArgumentOutOfRangeException>();
    }

    [Fact]
    public async Task should_update_a_doctor()
    {
        // Arrange
        var createDto = new CreateDoctorDto
        {
            NationalCode = "1234567890",
            Name = "Ali",
            LastName = "Rezaei",
            Speciality = "Cardiology",
            ContactInfo = "0912000000"
        };
        var id = await _doctorService.Create(createDto, CancellationToken.None);

        // Act
        var updateDto = new UpdateDoctorDto
        {
            Id = id,
            Name = "Ali",
            LastName = "Rezazadeh",
            Speciality = "Neurology",
            ContactInfo = "09123334444"
        };
        await _doctorService.Update(updateDto, CancellationToken.None);

        var doctor = await _doctorRepositoryStub.GetById(id, CancellationToken.None);

        // Assert
        doctor.LastName.Should().Be("Rezazadeh");
        doctor.Expertise.Should().Be("Neurology");
        doctor.ContactInfo.Should().Be("09123334444");
    }

    [Fact]
    public async Task should_delete_a_doctor()
    {
        // Arrange
        var createDto = new CreateDoctorDto
        {
            NationalCode = "9999999999",
            Name = "Sara",
            LastName = "Ahmadi",
            Speciality = "Dermatology",
            ContactInfo = "0935000000"
        };
        var id = await _doctorService.Create(createDto, CancellationToken.None);

        // Act
        await _doctorService.Delete(id, CancellationToken.None);

        // Assert
        var doctor = await _doctorRepositoryStub.GetById(id, CancellationToken.None);
        doctor.Should().BeNull();
    }

    [Fact]
    public async Task should_search_doctors_by_speciality()
    {
        // Arrange
        await _doctorService.Create(new CreateDoctorDto
        {
            NationalCode = "1111111111",
            Name = "Reza",
            LastName = "Karimi",
            Speciality = "Orthopedics",
            ContactInfo = "0922000000"
        }, CancellationToken.None);

        await _doctorService.Create(new CreateDoctorDto
        {
            NationalCode = "2222222222",
            Name = "Mina",
            LastName = "Hosseini",
            Speciality = "Neurology",
            ContactInfo = "0922111111"
        }, CancellationToken.None);

        // Act
        var result = await _doctorService.Search(null, "Neurology", CancellationToken.None);

        // Assert
        result.Should().ContainSingle();
        result.First().LastName.Should().Be("Hosseini");
    }
}

public class DoctorRepositoryStub : IDoctorRepository
{
    private static Dictionary<string, Doctor> _doctors = new();

    public Task<IEnumerable<Doctor>> GetAll(CancellationToken cancellationToken)
    {
        return Task.FromResult(_doctors.Values.AsEnumerable());
    }

    public Task<Guid> Create(Doctor doctor, CancellationToken cancellationToken)
    {
        _doctors.Add(doctor.NationalCode, doctor);
        return Task.FromResult(doctor.Id);
    }

    public Task<bool> AlreadyExists(string nationalCode, CancellationToken cancellationToken)
    {
        return Task.FromResult(_doctors.ContainsKey(nationalCode));
    }

    public Task Update(Doctor doctor, CancellationToken cancellationToken)
    {
        _doctors[doctor.NationalCode] = doctor;
        return Task.CompletedTask;
    }

    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var doctor = _doctors.Values.FirstOrDefault(d => d.Id == id);
        if (doctor != null)
        {
            _doctors.Remove(doctor.NationalCode);
        }
        return Task.CompletedTask;
    }

    public Task<Doctor?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var doctor = _doctors.Values.FirstOrDefault(d => d.Id == id);
        return Task.FromResult(doctor);
    }

    public Task<IEnumerable<Doctor>> Search(string? name, string? speciality, CancellationToken cancellationToken)
    {
        var query = _doctors.Values.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
                                   || d.LastName.Contains(name, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrWhiteSpace(speciality))
            query = query.Where(d => d.Expertise.Contains(speciality, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(query);
    }
}