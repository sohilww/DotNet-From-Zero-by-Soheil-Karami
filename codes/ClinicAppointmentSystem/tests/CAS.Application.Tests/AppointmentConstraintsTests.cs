using CAS.Application;
using CAS.Application.Contract;
using CAS.Domain.Repositories;
using CAS.Infrastructure.InMemoryDatabase;
using FluentAssertions;
using Xunit;

namespace CAS.Application.Tests;

public class AppointmentConstraintsTests
{
    [Fact]
    public async Task create_should_fail_on_holiday()
    {
        var appointmentRepo = new AppointmentRepository();
        var scheduleRepo = new ScheduleRepository();
        var holidayRepo = new ClinicHolidayRepository();
        var vacationRepo = new DoctorVacationRepository();
        var activeDaysRepo = new DoctorActiveDaysRepository();

        var service = new AppointmentService(appointmentRepo, scheduleRepo, holidayRepo, vacationRepo, activeDaysRepo);

        var dto = new CreateAppointmentDto
        {
            DoctorId = Guid.NewGuid(),
            PatientId = Guid.NewGuid(),
            Date = new DateTime(2030, 1, 1),
            PeriodId = Guid.NewGuid()
        };

        Func<Task> act = async () => await service.Create(dto, CancellationToken.None);

        await act.Should().ThrowAsync<ArgumentOutOfRangeException>();
    }
}


