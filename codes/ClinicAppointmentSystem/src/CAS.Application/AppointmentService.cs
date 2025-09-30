using CAS.Application.Contract;
using CAS.Domain;
using CAS.Domain.Repositories;

namespace CAS.Application
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IClinicHolidayRepository _clinicHolidayRepository;
        private readonly IDoctorVacationRepository _doctorVacationRepository;
        private readonly IDoctorActiveDaysRepository _doctorActiveDaysRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, IScheduleRepository scheduleRepository,
            IClinicHolidayRepository clinicHolidayRepository, IDoctorVacationRepository doctorVacationRepository,
            IDoctorActiveDaysRepository doctorActiveDaysRepository)
        {
            _appointmentRepository = appointmentRepository;
            _scheduleRepository = scheduleRepository;
            _clinicHolidayRepository = clinicHolidayRepository;
            _doctorVacationRepository = doctorVacationRepository;
            _doctorActiveDaysRepository = doctorActiveDaysRepository;
        }

        public async Task<Guid> Create(CreateAppointmentDto dto, CancellationToken cancellationToken)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            if (await _clinicHolidayRepository.IsHoliday(dto.Date.Date, cancellationToken))
                throw new ArgumentOutOfRangeException();

            var doctorId = new DoctorId(dto.DoctorId);

            if (await _doctorVacationRepository.IsDoctorOnVacation(doctorId, dto.Date.Date, cancellationToken))
                throw new ArgumentOutOfRangeException();

            if (!await _doctorActiveDaysRepository.IsWithinActiveDays(doctorId, dto.Date.Date, cancellationToken))
                throw new ArgumentOutOfRangeException();

            var appointmentId = AppointmentId.Generate();
            var appointment = new Appointment(
                appointmentId,
                doctorId,
                new PatientId(dto.PatientId),
                dto.Date,
                new AppointmentPeriodId(dto.PeriodId));

            if (await _appointmentRepository.ExistsForDoctorAt(doctorId, dto.Date, new AppointmentPeriodId(dto.PeriodId), cancellationToken))
                throw new ArgumentOutOfRangeException();

            await _appointmentRepository.Create(appointment, cancellationToken);
            return appointment.Id.DbId;
        }

        public async Task Confirm(Guid appointmentId, CancellationToken cancellationToken)
        {
            var id = new AppointmentId(appointmentId);
            var appointment = await _appointmentRepository.GetById(id, cancellationToken) ?? throw new ArgumentOutOfRangeException();
            appointment.Confirm();
        }

        public async Task Cancel(Guid appointmentId, CancellationToken cancellationToken)
        {
            var id = new AppointmentId(appointmentId);
            var appointment = await _appointmentRepository.GetById(id, cancellationToken) ?? throw new ArgumentOutOfRangeException();
            appointment.Cancel();
        }
    }
}


