using AireLogic.PANDA.API.Domain.Entities;
using AireLogic.PANDA.API.DTOs.Appointments;

namespace AireLogic.PANDA.API.Application.Mapping;

internal static class AppointmentMappings
{
    public static AppointmentResponseDto MapToDto(this Appointment appointment)
    {
        return new AppointmentResponseDto
        {
            Id = appointment.Id,
            PatientId = appointment.PatientId,
            ClinicianId = appointment.ClinicianId,
            Status = appointment.Status,
            StartTime = appointment.StartTime,
            Duration = appointment.Duration,
            Department = appointment.Department,
            Postcode = appointment.Postcode
        };
    }

    public static AppointmentResponsesDto MapToDto(this IEnumerable<Appointment> appointments)
    {
        return new AppointmentResponsesDto
        {
            Items = appointments.Select(MapToDto)
        };
    }

    public static Appointment MapToEntity(this CreateAppointmentDto dto)
    {
        Appointment appointment = new()
        {
            PatientId = dto.PatientId,
            ClinicianId = dto.ClinicianId,
            StartTime = dto.StartTime,
            Duration = dto.Duration,
            Department = dto.Department,
            Postcode = dto.Postcode
        };

        return appointment;
    }

}
