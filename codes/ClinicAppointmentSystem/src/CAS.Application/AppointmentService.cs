using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAS.Application.Contract;
using CAS.Domain;
using CAS.Domain.Enum;
using CAS.Domain.Repositories;

namespace CAS.Application
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Guid> Create(CreateAppointmentDto dto, CancellationToken cancellationToken)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            if (await _appointmentRepository.AlreadyExists(dto.DoctorId, cancellationToken))
                throw new ArgumentOutOfRangeException();
            var appointment = new Appointment(
                id: dto.Id,
                doctorId: dto.DoctorId,
                patientId: dto.PatientId,
                date: dto.Date,
                periodId: dto.PeriodId
            );
            await _appointmentRepository.Create(appointment, cancellationToken);
            return appointment.Id;
        }
    }
}
