namespace AireLogic.PANDA.API.DTOs.Appointments;

public sealed record CreateAppointmentDto
{
    public Guid PatientId { get; set; }
    public Guid ClinicianId { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public int Duration { get; set; }
    public string Department { get; set; }
    public string Postcode { get; set; }
}
