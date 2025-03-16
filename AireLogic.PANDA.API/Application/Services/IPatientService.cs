using AireLogic.PANDA.API.Domain.Entities;

namespace AireLogic.PANDA.API.Application.Services;

public interface IPatientService
{
    Task<bool> CreateAsync(Patient patient, CancellationToken token = default);

    Task<Patient?> GetByIdAsync(Guid id, CancellationToken token = default);

    Task<IEnumerable<Patient>> GetAllAsync(CancellationToken token = default);

    Task<Patient?> UpdateAsync(Patient patient, CancellationToken token = default);

    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
}
