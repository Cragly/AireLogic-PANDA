using System.Globalization;
using AireLogic.PANDA.API.Domain.Entities;
using FluentValidation.TestHelper;

namespace AireLogic.PANDA.API.UnitTests;

public class PatientValidator
{
    private readonly Application.Validators.PatientValidator _validator = new();

    #region Happy Paths :)
    [Fact]
    public async Task Validate_ShouldNotReturnError_WhenPatientValid()
    {
        // Arrange
        var dto = new Patient
        {
            Id = Guid.NewGuid(),
            NhsNumber = "1953262716",
            Title = "Dr",
            FirstName = "Ian",
            Surname = "Hall",
            DateOfBirth = DateOnly.Parse("1963-08-27", CultureInfo.InvariantCulture),
            Postcode = "WA55 8HE",
        };

        // Act
        TestValidationResult<Patient>? result = await _validator.TestValidateAsync(dto);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
    #endregion

    #region Sad Paths :(
    [Fact]
    public async Task Validate_ShouldReturnError_WhenTitleIsNotProvided()
    {
        // Arrange
        var dto = new Patient
        {
            Id = Guid.NewGuid(),
            NhsNumber = "1953262716",
            Title = "",
            FirstName = "Ian",
            Surname = "Hall",
            DateOfBirth = DateOnly.Parse("1963-08-27", CultureInfo.InvariantCulture),
            Postcode = "WA55 8HE",
        };

        // Act
        TestValidationResult<Patient>? result = await _validator.TestValidateAsync(dto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    [Fact]
    public async Task Validate_ShouldReturnError_WhenNhsNumberIsInvalid()
    {
        // Arrange
        var dto = new Patient
        {
            Id = Guid.NewGuid(),
            NhsNumber = "195326271",
            Title = "Dr",
            FirstName = "Ian",
            Surname = "Hall",
            DateOfBirth = DateOnly.Parse("1963-08-27", CultureInfo.InvariantCulture),
            Postcode = "WA55 8HE",
        };

        // Act
        TestValidationResult<Patient>? result = await _validator.TestValidateAsync(dto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.NhsNumber);
    }

    [Fact]
    public async Task Validate_ShouldReturnError_WhenPostcodeIsInvalid()
    {
        // Arrange
        var dto = new Patient
        {
            Id = Guid.NewGuid(),
            NhsNumber = "1953262716",
            Title = "Dr",
            FirstName = "Ian",
            Surname = "Hall",
            DateOfBirth = DateOnly.Parse("1963-08-27", CultureInfo.InvariantCulture),
            Postcode = "WA55 8H",
        };

        // Act
        TestValidationResult<Patient>? result = await _validator.TestValidateAsync(dto);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Postcode);
    }
    #endregion
}
