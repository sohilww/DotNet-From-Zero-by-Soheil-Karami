using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Application.Contract
{
    public interface IAppointmentService
    {
        public Task<Guid> Create(CreateAppointmentDto dto, CancellationToken cancellationToken);
    }
}
