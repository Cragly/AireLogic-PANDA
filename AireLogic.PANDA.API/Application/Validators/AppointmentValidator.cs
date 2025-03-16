using System.Text.RegularExpressions;
using AireLogic.PANDA.API.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace AireLogic.PANDA.API.Application.Validators;

public sealed class AppointmentValidator : AbstractValidator<Appointment>
{
    public AppointmentValidator()
    {
        RuleFor(x => x.PatientId)
            .NotNull()
            .NotEmpty()
            .WithMessage("A patientId is required to create an appointment.");

        RuleFor(x => x.ClinicianId)
            .NotEmpty()
            .WithMessage("A ClinicianId is required to create an appointment.");

        RuleFor(x => x.StartTime)
            .Must(BeAValidStartTime)
            .WithMessage("Start date must be in the future.");

        RuleFor(x => x.Duration)
            .NotEmpty()
            .WithMessage("Duration is required to create an appointment.");

        RuleFor(x => x.Department)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("Department is required to create an appointment and must not be greater than 50 characters");

        RuleFor(x => x.Postcode)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(8)
            .WithMessage("Postcode must be between 5 and 8 characters");

        RuleFor(x => x.Postcode)
            .NotEmpty()
            .Must(BeAValidUkPostcode)
            .WithMessage("Postcode format is invalid");
    }

    protected override bool PreValidate(ValidationContext<Appointment> context, ValidationResult result)
    {
        if (context.InstanceToValidate != null)
        {
            return true;
        }

        result.Errors.Add(new ValidationFailure("", "Please ensure an appointment"));
        return false;
    }

    private static bool BeAValidStartTime(DateTimeOffset startTime)
    {
        return startTime > DateTimeOffset.UtcNow;
    }

    private static bool BeAValidUkPostcode(string postcode)
    {
        if (string.IsNullOrWhiteSpace(postcode))
        {
            return false;
        }

        postcode = postcode.Replace(" ", "").ToUpper();

        // UK postcode regex pattern
        string pattern = @"^[A-Z]{1,2}[0-9R][0-9A-Z]?[0-9][A-Z]{2}$";

        return Regex.IsMatch(postcode, pattern);
    }
}
