namespace AireLogic.PANDA.API.DTOs.Patients;

public sealed record PatientResponseDto
{
    public required Guid Id { get; init; }
    public required string NhsNumber { get; init; }
    public required string Title { get; init; }
    public required string FirstName { get; init; }
    public required string Surname { get; init; }
    public required DateOnly DateOfBirth { get; init; }
    public required string Postcode { get; init; }
}
