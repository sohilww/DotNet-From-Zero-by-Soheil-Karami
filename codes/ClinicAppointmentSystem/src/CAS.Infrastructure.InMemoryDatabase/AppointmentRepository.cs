using CAS.Domain;
using CAS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Infrastructure.InMemoryDatabase
{
    public class AppointmentRepository:IAppointmentRepository
    {
        static Dictionary<string, Appointment> _appointments = new Dictionary<string, Appointment>();
        public async Task<Guid> Create(Appointment appointment, CancellationToken cancellationToken)
        {
            _appointments.Add(appointment.DoctorId.ToString(), appointment);
            return appointment.Id;
        }

        public async Task<bool> AlreadyExists(Guid doctorId, CancellationToken cancellationToken)
        {
            return _appointments.ContainsKey(doctorId.ToString());
        }
    }
}
