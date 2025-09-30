using CAS.Application.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CilinicAppointmentSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchedulesController : ControllerBase
{
    private readonly IScheduleService _scheduleService;

    public SchedulesController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateScheduleDto dto, CancellationToken cancellationToken)
    {
        var id = await _scheduleService.Create(dto, cancellationToken);
        return Ok(id);
    }
}


