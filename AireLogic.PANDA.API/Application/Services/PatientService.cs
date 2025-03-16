using AireLogic.PANDA.API.Application.Contracts;
using AireLogic.PANDA.API.Domain.Entities;
using FluentValidation;

namespace AireLogic.PANDA.API.Application.Services;

public sealed class PatientService(IPatientRepository patientRepository, IValidator<Patient> patientValidator)
    : IPatientService
{
    public async Task<bool> CreateAsync(Patient patient, CancellationToken token = default)
    {
        await patientValidator.ValidateAndThrowAsync(patient, cancellationToken: token);
        return await patientRepository.CreateAsync(patient, token);
    }

    public Task<Patient?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return patientRepository.GetByIdAsync(id, token);
    }

    public Task<IEnumerable<Patient>> GetAllAsync(CancellationToken token = default)
    {
        return patientRepository.GetAllAsync(token);
    }

    public async Task<Patient?> UpdateAsync(Patient patient, CancellationToken token = default)
    {
        await patientValidator.ValidateAndThrowAsync(patient, cancellationToken: token);
        bool patientExists = await patientRepository.ExistsByIdAsync(patient.Id, token);
        if (!patientExists)
        {
            return null;
        }

        await patientRepository.UpdateAsync(patient, token);
        return patient;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        bool patientExists = await patientRepository.ExistsByIdAsync(id, token);
        if (!patientExists)
        {
            return false;
        }
        return await patientRepository.DeleteByIdAsync(id, token);
    }
}
