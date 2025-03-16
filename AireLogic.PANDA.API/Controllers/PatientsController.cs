using System.Net.Mime;
using AireLogic.PANDA.API.Application.Mapping;
using AireLogic.PANDA.API.Application.Services;
using AireLogic.PANDA.API.Domain.Entities;
using AireLogic.PANDA.API.DTOs.Patients;
using Microsoft.AspNetCore.Mvc;
using static AireLogic.PANDA.API.ApiEndpoints;

namespace AireLogic.PANDA.API.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public sealed class PatientsController(IPatientService patientService) : ControllerBase
{
    [HttpPost(Patients.Create)]
    public async Task<ActionResult<PatientResponseDto>> Create([FromBody] CreatePatientDto createPatientDto, CancellationToken token)
    {
        Patient patient = createPatientDto.MapToEntity();
        await patientService.CreateAsync(patient, token);

        PatientResponseDto patientResponse = patient.MapToDto();

        return CreatedAtAction(nameof(Get), new { id = patientResponse.Id }, patientResponse);
    }

    [HttpGet(Patients.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
    {
        Patient? patient = await patientService.GetByIdAsync(id, token);
        if (patient is null)
        {
            return NotFound();
        }

        PatientResponseDto response = patient.MapToDto();
        return Ok(response);
    }

    [HttpGet(Patients.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        IEnumerable<Patient> patients = await patientService.GetAllAsync(token);

        PatientResponsesDto patientsResponse = patients.MapToDto();
        return Ok(patientsResponse);
    }

    [HttpPut(Patients.Update)]
    public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePatientDto updatePatientDto, CancellationToken token)
    {
        Patient patient = updatePatientDto.MapToEntity(id);
        Patient? updatedPatient = await patientService.UpdateAsync(patient, token);
        if (updatedPatient is null)
        {
            return NotFound();
        }

        PatientResponseDto response = updatedPatient.MapToDto();
        return Ok(response);
    }

    [HttpDelete(Patients.Delete)]
    public async Task<ActionResult> Delete([FromRoute] Guid id, CancellationToken token)
    {
        bool deleted = await patientService.DeleteByIdAsync(id, token);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
