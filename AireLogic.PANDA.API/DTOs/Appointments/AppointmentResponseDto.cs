using AireLogic.PANDA.API.Domain.Entities;

namespace AireLogic.PANDA.API.DTOs.Appointments;

public sealed record AppointmentResponseDto
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid ClinicianId { get; set; }
    public AppointmentStatus Status { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public int Duration { get; set; }
    public string Department { get; set; }
    public string Postcode { get; set; }
}
