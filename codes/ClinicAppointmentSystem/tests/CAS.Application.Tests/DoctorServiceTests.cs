using System.Runtime.InteropServices.JavaScript;
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

    public DoctorServiceTests()
    {
        var doctorRepositoryStub = new DoctorRepositoryStub();
        _doctorService = new DoctorService(doctorRepositoryStub);
    }

    [Fact]
    public async Task should_create_a_doctor()
    {
        //Arrange,Act,Assert , Triple A
        var id = await _doctorService.Create(new CreateDoctorDto()
        {
            NationalCode="5210010104",
            LastName = "Yousefi",
            Name = "Samaneh",
            Speciality = "Genral",
            Gender = GenderDto.Female,
            MedicalCouncilNumber = "1234567890",
            ContactInfoDto = new ContactInfoDto()
            {
                Address = "somewhere",
                MobileNumber = "0912123456",
                PhoneNumber = "02183333"
            }
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
        
        var service=new DoctorService(repository);
        
        Func<Task> act = async () => { await service.Create(new CreateDoctorDto()
        {
            NationalCode="5210010104",
            LastName = "Yousefi",
            Name = "Samaneh",
            Speciality = "Genral"
        }, CancellationToken.None); };

        await act.Should().ThrowAsync<ArgumentOutOfRangeException>();
    }
}

public class DoctorRepositoryStub : IDoctorRepository
{
    Task<DoctorId> IDoctorRepository.Create(Doctor doctor, CancellationToken cancellationToken)
    {
        return Task.FromResult(doctor.Id);
    }

    public Task<bool> AlreadyExists(string nationalCode, CancellationToken cancellationToken)
    {
        return Task.FromResult(false);
    }
}