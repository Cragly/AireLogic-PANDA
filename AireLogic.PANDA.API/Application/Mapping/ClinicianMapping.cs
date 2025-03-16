using AireLogic.PANDA.API.Domain.Entities;
using AireLogic.PANDA.API.DTOs.Clinicians;

namespace AireLogic.PANDA.API.Application.Mapping;

internal static class ClinicianMapping
{
    public static ClinicianResponseDto MapToDto(this Clinician clinician)
    {
        return new ClinicianResponseDto
        {
            Id = clinician.Id,
            Name = clinician.Name,
            Department = clinician.Department
        };
    }

    public static ClanicianResponsesDto MapToDto(this IEnumerable<Clinician> clinicians)
    {
        return new ClanicianResponsesDto
        {
            Items = clinicians.Select(MapToDto)
        };
    }
}
