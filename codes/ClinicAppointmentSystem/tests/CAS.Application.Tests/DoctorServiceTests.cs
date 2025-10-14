using CAS.Application.Contract;
using CAS.Domain;
using CAS.Domain.DoctorAggregate;
using CAS.Domain.DoctorAggregate.Repositories;
using CAS.Domain.TestHelpers;
using CAS.Domain.Tests;
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
            NationalCode = "5210010104",
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

        var service = new DoctorService(repository);

        Func<Task> act = async () =>
        {
            await service.Create(new CreateDoctorDto()
            {
                NationalCode = "5210010104",
                LastName = "Yousefi",
                Name = "Samaneh",
                Speciality = "Genral"
            }, CancellationToken.None);
        };

        await act.Should().ThrowAsync<ArgumentOutOfRangeException>();
    }

    [Fact]
    public async Task should_throw_an_exception_when_could_not_find_a_doctor()
    {
        var service = new DoctorService(CreateRepositoryThatSaysDoctorHasNotCreatedYet());

        var act = async () =>
        {
            await service.CreateSchedule(new CreateScheduleDto()
            {
                DoctorId = Guid.NewGuid(),
            }, CancellationToken.None);
        };

        await act.Should().ThrowAsync<KeyNotFoundException>();
    }

    [Fact]
    public async Task should_throw_an_exception_when_schedule_already_exists()
    {
        var scheduleStartDate = DateTime.Now;
        var scheduleEndDate = scheduleStartDate.AddMonths(1);

        var doctorService = new DoctorService(CreateRepositoryThatReturnsDoctorWithSchedule(scheduleStartDate, scheduleEndDate));
        var schedule = CreateScheduleDto(scheduleStartDate, scheduleEndDate);

        var act = async () => await doctorService.CreateSchedule(schedule, CancellationToken.None);

        await act.Should().ThrowAsync<ArgumentException>();
    }

    private IDoctorRepository CreateRepositoryThatReturnsDoctorWithSchedule(DateTime startDate, DateTime endDate)
    {
        var doctor = new DoctorTestBuilder().WithSchedule(CreateSchedule(startDate, endDate)).Build();
        var repository = Substitute.For<IDoctorRepository>();
        repository.GetById(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(doctor);
        repository.AlreadyExists(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(true);
        return repository;
    }

    private static CreateScheduleDto CreateScheduleDto(DateTime startDate, DateTime endDate)
    {
        var schedule = new CreateScheduleDto()
        {
            DoctorId = Guid.NewGuid(),
            StartDate = startDate,
            EndDate = endDate,
            SessionDuration = 30,
            RestDuration = 10,
            DaySchedules = new List<DayScheduleDto>()
            {
                new DayScheduleDto()
                {
                    WorkDay = DayOfWeek.Saturday,
                    Hours = new List<WorkingHoursDto>()
                    {
                        new WorkingHoursDto()
                        {
                            StartTime = TimeSpan.Parse("09:00"),
                            EndTime = TimeSpan.Parse("14:00"),
                        }
                    }
                }
            }
        };
        return schedule;
    }

    private IDoctorRepository CreateRepositoryThatSaysDoctorHasNotCreatedYet()
    {
        var repository = Substitute.For<IDoctorRepository>();
        repository.AlreadyExists(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(false);
        return repository;
    }

    private Schedule CreateSchedule(DateTime startDate, DateTime endDate)
    {
        return ScheduleFactory.CreateDefault(startDate, endDate);
    }
}

public class DoctorRepositoryStub : IDoctorRepository
{
    public Task<DoctorId> Create(Doctor doctor, CancellationToken cancellationToken)
    {
        return Task.FromResult(doctor.Id);
    }

    public Task<bool> AlreadyExists(string nationalCode, CancellationToken cancellationToken)
    {
        return Task.FromResult(false);
    }

    public Task<bool> AlreadyExists(Guid doctorId, CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }

    public Task<Doctor> GetById(Guid doctorId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}