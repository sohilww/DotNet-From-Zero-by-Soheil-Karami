using CAS.Application;
using CAS.Application.Contract;
using CAS.Domain;
using CAS.Domain.Repositories;
using CAS.Infrastructure.InMemoryDatabase;
using FluentAssertions;
using Xunit;

namespace CAS.Application.Tests;

public class AppointmentServiceTests
{
    [Fact]
    public async Task create_should_store_appointment_and_return_id()
    {
        IAppointmentRepository appointmentRepo = new AppointmentRepository();
        IScheduleRepository scheduleRepo = new ScheduleRepository();
        IClinicHolidayRepository clinicHolidayRepo = new ClinicHolidayRepository();
        IDoctorVacationRepository doctorVacationRepo = new DoctorVacationRepository();
        IDoctorActiveDaysRepository doctorActiveDaysRepo = new DoctorActiveDaysRepository();
        var service = new AppointmentService(
            appointmentRepo
            , scheduleRepo
            , clinicHolidayRepo
            , doctorVacationRepo, doctorActiveDaysRepo);

        var dto = new CreateAppointmentDto
        {
            DoctorId = DoctorId.Generate().DbId,
            PatientId = PatientId.Generate().DbId,
            Date = DateTime.Today,
            PeriodId = AppointmentPeriodId.Generate().DbId
        };

        var id = await service.Create(dto, CancellationToken.None);
        id.Should().NotBe(Guid.Empty);
    }
}


