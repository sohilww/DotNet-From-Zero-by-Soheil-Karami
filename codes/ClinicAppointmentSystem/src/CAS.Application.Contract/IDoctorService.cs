using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Application.Contract
{
    public interface IDoctorService
    {
        public Task<Guid> Create(CreateDoctorDto dto, CancellationToken cancellationToken);
        Task AddSchedule(string nationalCode, AddScheduleDto dto, CancellationToken cancellationToken);
        Task<GetDoctorDto> GetByNationalCode(string nationalCode, CancellationToken cancellationToken);

    }
}
