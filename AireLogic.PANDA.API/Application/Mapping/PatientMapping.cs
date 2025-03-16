using AireLogic.PANDA.API.Domain.Entities;
using AireLogic.PANDA.API.DTOs.Patients;

namespace AireLogic.PANDA.API.Application.Mapping;

internal static class PatientMapping
{
    public static PatientResponseDto MapToDto(this Patient patient)
    {
        return new PatientResponseDto
        {
            Id = patient.Id,
            NhsNumber = patient.NhsNumber,
            Title = patient.Title,
            FirstName = patient.FirstName,
            Surname = patient.Surname,
            DateOfBirth = patient.DateOfBirth,
            Postcode = patient.Postcode
        };
    }

    public static PatientResponsesDto MapToDto(this IEnumerable<Patient> patients)
    {
        return new PatientResponsesDto
        {
            Items = patients.Select(MapToDto)
        };
    }

    public static Patient MapToEntity(this CreatePatientDto dto)
    {
        Patient patient = new()
        {
            NhsNumber = dto.NhsNumber,
            Title = dto.Title,
            FirstName = dto.FirstName,
            Surname = dto.Surname,
            DateOfBirth = dto.DateOfBirth,
            Postcode = dto.Postcode
        };

        return patient;
    }

    public static Patient MapToEntity(this UpdatePatientDto dto, Guid id)
    {
        Patient patient = new()
        {
            Id = id,
            NhsNumber = dto.NhsNumber,
            Title = dto.Title,
            FirstName = dto.FirstName,
            Surname = dto.Surname,
            DateOfBirth = dto.DateOfBirth,
            Postcode = dto.Postcode
        };

        return patient;
    }
}
