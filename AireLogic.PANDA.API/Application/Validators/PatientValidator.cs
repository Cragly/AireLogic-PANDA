using System.Globalization;
using System.Text.RegularExpressions;
using AireLogic.PANDA.API.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace AireLogic.PANDA.API.Application.Validators;

public sealed class PatientValidator : AbstractValidator<Patient>
{
    public PatientValidator()
    {
        RuleFor(x => x.NhsNumber)
            .NotEmpty()
            .Length(10)
            .WithMessage("NHS Number must be 10 characters");

        RuleFor(x => x.NhsNumber)
            .NotEmpty()
            .Must(BeAValidNhsNumber)
            .WithMessage("You must enter a valid NHS Number");

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(20)
            .WithMessage("Title must be between 1 and 20 characters");

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("Firstname name must be between 1 and 50 characters");

        RuleFor(x => x.Surname)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("Surname name must be between 1 and 50 characters");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty()
            .Must(BeInTheCorrectDateOfBirthFormat)
            .WithMessage("Date of Birth must be in the format yyyy-MM-dd.");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty()
            .Must(BeAValidDataOfBirth)
            .WithMessage("Date of Birth is not valid");

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

    protected override bool PreValidate(ValidationContext<Patient> context, ValidationResult result)
    {
        if (context.InstanceToValidate != null)
        {
            return true;
        }

        result.Errors.Add(new ValidationFailure("", "Please ensure a patient"));
        return false;
    }
    private static bool BeAValidNhsNumber(string nhsNumber)
    {
        // Comments have been added to provide clarity
        // Implements Data Dictionary steps 1-5 (https://www.datadictionary.nhs.uk/attributes/nhs_number.html)
        
        // Clean up input and validate string contains all numbers
        nhsNumber = nhsNumber.Replace(" ", "").Replace("-", "");
        if (nhsNumber.Length != 10 || !nhsNumber.All(char.IsDigit))
        {
            return false;
        }

        // Step 1 Multiply each of the first nine digits by a weighting factor
        // Step 2 Add the results of each multiplication together
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            int digit = int.Parse(nhsNumber[i].ToString(), CultureInfo.InvariantCulture);
            sum += digit * (10 - i);
        }

        // Step 3 Divide the total by 11 and establish the remainder.
        // Step 4 Subtract the remainder from 11 to give the check digit.
        // If the result is 11 then a check digit of 0 is used. If the result is 10 then the NHS NUMBER is invalid and not used.
        int checkDigit = 11 - sum % 11;
        if (checkDigit == 11)
        {
            checkDigit = 0;
        }

        // Step 5 Check the remainder matches the check digit. If it does not, the NHS NUMBER is invalid.
        int lastDigit = int.Parse(nhsNumber[9].ToString(), CultureInfo.InvariantCulture);
        return checkDigit == lastDigit;
    }

    private static bool BeAValidDataOfBirth(DateOnly date)
    {
        int currentYear = DateTime.Now.Year;
        int dobYear = date.Year;

        // Oldest person in the world ever was 122 so +8 just in case
        return dobYear <= currentYear && dobYear > currentYear - 130;
    }

    private static bool BeInTheCorrectDateOfBirthFormat(DateOnly dob)
    {
        string date = dob.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        bool output =  DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        return output;
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
