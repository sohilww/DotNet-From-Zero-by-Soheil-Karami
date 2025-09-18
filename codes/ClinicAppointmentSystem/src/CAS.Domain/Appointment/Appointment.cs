using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Domain.Appointment
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid DoctorId { get; private set; }
        public Guid PatientId { get; private set; }
      

    }
}
