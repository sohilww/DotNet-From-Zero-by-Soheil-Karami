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
        public async Task<ActionResult<Guid>> CreateDoctor(CreateDoctorModel createDoctor,
            CancellationToken cancellationToken)
        {
            var dto = createDoctor.MapToDto();
            var id = await _doctorService.Create(dto,cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = id }, dto);
        }

        [HttpPost]
        [Route("{id:guid}/Schedules")]
        public async Task<ActionResult<object>> CreateSchedule(Guid id,CreateScheduleModel createSchedule,CancellationToken cancellationToken)
        {
            var dto = createSchedule.MapToDto(id);
            var scheduleId = await _doctorService.CreateSchedule(dto,cancellationToken);
            return CreatedAtAction(nameof(GetScheduleById), new { id = scheduleId }, dto);
        }

        [HttpGet]
        public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            return Ok();
        }
        
        //Doctors/doctorId/schedules/scheduleId
        [HttpGet]
        [Route("{id:guid}/Schedules/{scheduleId:guid}")]
        public async Task<ActionResult> GetScheduleById(Guid id, CancellationToken cancellationToken)
        {
            return Ok();
        }
    }
}