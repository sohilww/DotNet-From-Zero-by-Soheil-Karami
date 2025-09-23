using CAS.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Application.Contract
{
    public class CreateAppointmentDto
    {
        public Guid Id { get;  set; }
        public Guid DoctorId { get;  set; }
        public Guid PatientId { get;  set; }
        public DateTime Date { get;  set; }
        public Guid PeriodId { get;  set; }
        public AppointmentStatus Status { get;  set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ModifiedAt { get; private set; } = DateTime.Now;
    }

 
}
