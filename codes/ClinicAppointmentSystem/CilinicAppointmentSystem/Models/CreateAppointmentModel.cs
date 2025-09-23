using Bogus.DataSets;
using CAS.Application.Contract;
using CAS.Domain.Enum;

namespace CilinicAppointmentSystem.Models
{
    public class CreateAppointmentModel
    {
        public Guid Id { get; private set; }
        public Guid DoctorId { get; private set; }
        public Guid PatientId { get; private set; }
        public DateTime Date { get; private set; }
        public Guid PeriodId { get; private set; }
        public AppointmentStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ModifiedAt { get; private set; } = DateTime.Now;



        public CreateAppointmentDto MapToDto()
        {
            return new CreateAppointmentDto()
            {
                Id = Id,
                DoctorId = DoctorId,
                Date = Date,
                PatientId = PatientId,
                PeriodId = PeriodId,
                Status = Status
            };
        }
    }
}
