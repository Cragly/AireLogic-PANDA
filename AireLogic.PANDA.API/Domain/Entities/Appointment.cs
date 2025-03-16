namespace AireLogic.PANDA.API.Domain.Entities;

public sealed class Appointment
{
    private DateTimeOffset _startTime;
    private int _duration;

    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PatientId { get; set; }
    public Guid ClinicianId { get; set; }
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Active;
    public DateTimeOffset StartTime
    {
        get => _startTime;
        set
        {
            _startTime = value;
            UpdateEndTime();
        }
    }

    public DateTimeOffset EndTime { get; private set; }

    public int Duration
    {
        get => _duration;
        set
        {
            _duration = value;
            UpdateEndTime();
        }
    }
    public string Department { get; set; }
    public string Postcode { get; set; }

    private void UpdateEndTime()
    {
        EndTime = _startTime.AddMinutes(_duration);
        ;
    }
}
