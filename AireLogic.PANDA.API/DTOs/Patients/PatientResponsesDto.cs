namespace AireLogic.PANDA.API.DTOs.Patients;

public sealed record PatientResponsesDto
{
    public required IEnumerable<PatientResponseDto> Items { get; init; } = [];
}
