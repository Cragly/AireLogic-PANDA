using AireLogic.PANDA.API.DTOs.Patients;

namespace AireLogic.PANDA.API.DTOs.Clinicians;

public sealed record ClanicianResponsesDto
{
    public required IEnumerable<ClinicianResponseDto> Items { get; init; } = [];
}
