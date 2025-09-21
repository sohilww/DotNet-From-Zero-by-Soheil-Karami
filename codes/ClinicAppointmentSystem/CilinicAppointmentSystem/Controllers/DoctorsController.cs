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
            _doctorService = doctorService;
        }

        // POST /doctors
        [HttpPost]
        public async Task<ActionResult> CreateDoctor(CreateDoctorModel createDoctor,
            CancellationToken cancellationToken)
        {
            if (createDoctor == null)
                return BadRequest("اطلاعات پزشک نامعتبر است");

            var dto = createDoctor.MapToDto();
            var id = await _doctorService.Create(dto, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }


        // GET /doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _doctorService.GetAll(cancellationToken);
            return Ok(result);
        }

        // GET /doctors/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DoctorDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _doctorService.Search(null, null, cancellationToken);

            var doctor = result.FirstOrDefault(d => d.Id == id);
            if (doctor == null)
                return NotFound("پزشک یافت نشد");

            return Ok(doctor);
        }

        // GET /doctors/search?name=Ali&speciality=Heart
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> Search(string? name, string? speciality,
            CancellationToken cancellationToken)
        {
            var results = await _doctorService.Search(name, speciality, cancellationToken);
            return Ok(results);
        }

        // PUT /doctors/{id}
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateDoctor(Guid id, UpdateDoctorModel updateDoctor,
      CancellationToken cancellationToken)
        {
            if (updateDoctor == null)
                return BadRequest("اطلاعات ویرایش نامعتبر است");

            var dto = updateDoctor.MapToDto(id);
            await _doctorService.Update(dto, cancellationToken);

            return NoContent();
        }

        // DELETE /doctors/{nationalCode}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteDoctor(Guid id, CancellationToken cancellationToken)
        {
            await _doctorService.Delete(id, cancellationToken);
            return NoContent();
        }
    }
}
