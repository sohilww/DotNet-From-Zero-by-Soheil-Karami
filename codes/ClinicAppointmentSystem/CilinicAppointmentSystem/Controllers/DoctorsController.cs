using CAS.Application.Contract;
using CilinicAppointmentSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CilinicAppointmentSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            this._doctorService = doctorService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateDoctor(CreateDoctorModel createDoctor, CancellationToken cancellationToken)
        {
            var dto = createDoctor.MapToDto();
            var id = await _doctorService.Create(dto);
            
            return Ok();
        }
        


    }
}
