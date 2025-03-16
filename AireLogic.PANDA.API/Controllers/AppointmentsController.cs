using System.Net.Mime;
using AireLogic.PANDA.API.Application.Mapping;
using AireLogic.PANDA.API.Application.Services;
using AireLogic.PANDA.API.Domain.Entities;
using AireLogic.PANDA.API.DTOs.Appointments;
using AireLogic.PANDA.API.DTOs.Patients;
using Microsoft.AspNetCore.Mvc;
using static AireLogic.PANDA.API.ApiEndpoints;

namespace AireLogic.PANDA.API.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public sealed class AppointmentsController(IAppointmentService appointmentService) : ControllerBase
{
    [HttpPost(Appointments.Create)]
    public async Task<ActionResult<AppointmentResponseDto>> Create([FromBody] CreateAppointmentDto createAppointmentDto, CancellationToken token)
    {
        Appointment appointment = createAppointmentDto.MapToEntity();
        await appointmentService.CreateAsync(appointment, token);

        AppointmentResponseDto appointmentResponse = appointment.MapToDto();

        return Ok(appointmentResponse);
    }

    [HttpGet(Appointments.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        IEnumerable<Appointment> appointment = await appointmentService.GetAllAsync(token);

        AppointmentResponsesDto appointmentsResponse = appointment.MapToDto();
        return Ok(appointmentsResponse);
    }
}
