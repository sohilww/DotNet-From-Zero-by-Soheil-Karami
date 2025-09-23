using CAS.Application.Contract;
using CAS.Domain;
using CAS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using CAS.Domain.Enum;
using FluentAssertions;
using NSubstitute.Core;
using Xunit;

namespace CAS.Application.Tests
{
    public class AppointmentServiceTests
    {
        private readonly AppointmentService _appointmentService;
        private readonly Faker<CreateAppointmentDto> _appointmentFaker;
        public AppointmentServiceTests()
        {
            var appointmentRepositoryStub = new AppointmentRepositoryStub();
            _appointmentService = new AppointmentService(appointmentRepositoryStub);
            _appointmentFaker = new Faker<CreateAppointmentDto>()
                .RuleFor(x => x.Id, f => Guid.NewGuid())
                .RuleFor(x => x.DoctorId, f => Guid.NewGuid())
                .RuleFor(x => x.PatientId, f => Guid.NewGuid())
                .RuleFor(x => x.PeriodId, f => Guid.NewGuid())
                .RuleFor(x => x.Date, f => f.Date.Future())
                .RuleFor(x => x.Status, f => AppointmentStatus.Confirmed);
        }

        [Fact]
        public async Task should_create_a_appointment()
        {
            var dto = _appointmentFaker.Generate();
            var appointmentId = await _appointmentService.Create(dto, CancellationToken.None);
            appointmentId.Should().NotBe(Guid.Empty);
        }

    }

public class AppointmentRepositoryStub : IAppointmentRepository
{
    public Task<Guid> Create(Appointment appointment, CancellationToken cancellationToken)
    {
        return Task.FromResult(appointment.Id);
    }

    public Task<bool> AlreadyExists(Guid doctorId, CancellationToken cancellationToken)
    {
        return Task.FromResult(false);
    }
}

}