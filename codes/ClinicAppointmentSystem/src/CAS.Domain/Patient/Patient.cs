using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Domain.Patient
{
    public class Patient
    {
        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public string LastName { get;  set; }
        public string ContactInfo { get;  set; }
    }
}
