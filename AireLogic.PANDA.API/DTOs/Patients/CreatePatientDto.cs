﻿namespace AireLogic.PANDA.API.DTOs.Patients;

public sealed record CreatePatientDto
{
    public string NhsNumber { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Postcode { get; set; }
}
