using CAS.Application.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CilinicAppointmentSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAppointmentDto dto, CancellationToken cancellationToken)
    {
        var id = await _appointmentService.Create(dto, cancellationToken);
        return Ok(id);
    }

    [HttpPost("{id:guid}/confirm")]
    public async Task<IActionResult> Confirm([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await _appointmentService.Confirm(id, cancellationToken);
        return NoContent();
    }

    [HttpPost("{id:guid}/cancel")]
    public async Task<IActionResult> Cancel([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await _appointmentService.Cancel(id, cancellationToken);
        return NoContent();
    }
}


