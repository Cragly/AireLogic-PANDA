namespace AireLogic.PANDA.API.Domain.Entities;

public sealed class Patient
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NhsNumber { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Postcode { get; set; }
}
