namespace AireLogic.PANDA.API.DTOs.Clinicians;

public sealed record ClinicianResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
}
