using AireLogic.PANDA.API.Domain.Entities;

namespace AireLogic.PANDA.API.Application.Contracts;

public interface IPatientRepository
{
    Task<bool> CreateAsync(Patient patient, CancellationToken token = default);

    Task<Patient?> GetByIdAsync(Guid id, CancellationToken token = default);

    Task<IEnumerable<Patient>> GetAllAsync(CancellationToken token = default);

    Task<bool> UpdateAsync(Patient patient, CancellationToken token = default);

    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);

    Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default);
}
