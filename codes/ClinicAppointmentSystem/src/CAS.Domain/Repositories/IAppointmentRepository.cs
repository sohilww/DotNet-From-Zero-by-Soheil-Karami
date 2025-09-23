using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Guid> Create(Appointment appointment, CancellationToken cancellationToken);
        Task<bool> AlreadyExists(Guid doctorId, CancellationToken cancellationToken);
    }
}
