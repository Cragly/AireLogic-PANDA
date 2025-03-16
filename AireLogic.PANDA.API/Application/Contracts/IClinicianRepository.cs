using AireLogic.PANDA.API.Domain.Entities;

namespace AireLogic.PANDA.API.Application.Contracts;

public interface IClinicianRepository
{
    Task<IEnumerable<Clinician>> GetAllAsync(CancellationToken token = default);
}
