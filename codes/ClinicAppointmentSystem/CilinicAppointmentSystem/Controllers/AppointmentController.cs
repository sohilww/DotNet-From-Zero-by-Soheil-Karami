using CAS.Application;
using CAS.Application.Contract;
using CilinicAppointmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CilinicAppointmentSystem.Controllers
{
   
        [ApiController]
        [Route("[controller]")]
        public class AppointmentController : ControllerBase
        {
            private readonly IAppointmentService _appointmentService;
            public AppointmentController(IAppointmentService appointmentService)
            {
                this._appointmentService = appointmentService;
            }

            [HttpPost]
            public async Task<ActionResult> CreateAppointment(CreateAppointmentModel appointmentModel,CancellationToken cancellationToken)
            {
                var dto = appointmentModel.MapToDto();
                var id = await _appointmentService.Create(dto, cancellationToken);

                return CreatedAtAction(nameof(GetById), new { id = id }, dto);
            }


            [HttpGet]
            public async Task<ActionResult> GetById(string id, CancellationToken cancellationToken)
            {
                return Ok();
            }
        }
    
}
