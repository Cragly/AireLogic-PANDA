using System.Net.Mime;
using AireLogic.PANDA.API.Application.Mapping;
using AireLogic.PANDA.API.Application.Services;
using AireLogic.PANDA.API.Domain.Entities;
using AireLogic.PANDA.API.DTOs.Clinicians;
using Microsoft.AspNetCore.Mvc;
using static AireLogic.PANDA.API.ApiEndpoints;

namespace AireLogic.PANDA.API.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public sealed class CliniciansController(IClinicianService clinicianService) : ControllerBase
{
    [HttpGet(Clinicians.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        IEnumerable<Clinician> clinician = await clinicianService.GetAllAsync(token);

        ClanicianResponsesDto cliniciansResponse = clinician.MapToDto();
        return Ok(cliniciansResponse);
    }
}
