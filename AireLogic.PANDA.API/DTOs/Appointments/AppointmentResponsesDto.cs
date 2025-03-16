namespace AireLogic.PANDA.API.DTOs.Appointments;

public sealed record AppointmentResponsesDto
{
    public required IEnumerable<AppointmentResponseDto> Items { get; init; } = [];
}
