using CAS.Application.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CilinicAppointmentSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientsController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePatientDto dto, CancellationToken cancellationToken)
    {
        var id = await _patientService.Create(dto, cancellationToken);
        return Ok(id);
    }
}


