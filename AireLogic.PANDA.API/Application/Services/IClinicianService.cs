using AireLogic.PANDA.API.Domain.Entities;

namespace AireLogic.PANDA.API.Application.Services;

public interface IClinicianService
{
    Task<IEnumerable<Clinician>> GetAllAsync(CancellationToken token = default);
}
