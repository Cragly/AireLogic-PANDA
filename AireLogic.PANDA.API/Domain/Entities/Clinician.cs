namespace AireLogic.PANDA.API.Domain.Entities;

public sealed class Clinician
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Department { get; set; }
}
