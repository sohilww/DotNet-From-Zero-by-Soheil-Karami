using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Application.Contract
{
    public interface IDoctorService
    {
        public Task<Guid> Create(CreateDoctorDto dto);
    }
}
