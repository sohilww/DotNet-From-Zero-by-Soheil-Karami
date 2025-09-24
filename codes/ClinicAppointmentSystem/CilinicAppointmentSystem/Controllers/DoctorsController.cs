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
        public async Task<ActionResult> CreateDoctor(CreateDoctorModel createDoctor,
            CancellationToken cancellationToken)
        {
            var dto = createDoctor.MapToDto();
            var nationalCode = await _doctorService.Create(dto,cancellationToken);

            return CreatedAtAction(nameof(GetByNationalCode), new { nationalCode }, dto);


        }

        [HttpGet("{nationalCode}")]
        public async Task<ActionResult> GetByNationalCode(string nationalCode, CancellationToken cancellationToken)
        {

            var doctor = await _doctorService.GetByNationalCode(nationalCode, cancellationToken);
            return Ok(doctor);
        }

        [HttpPost("{nationalCode}/schedules")]
        public async Task<IActionResult> AddSchedule(string nationalCode, [FromBody] AddScheduleModel addWorkSchedule, CancellationToken cancellationToken)
        {
            try
            {
                await _doctorService.AddSchedule(nationalCode, addWorkSchedule.MapToDto(), cancellationToken);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Invalid schedule data");
            }
        }

    }
}