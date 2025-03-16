using AireLogic.PANDA.API.Application.Contracts;
using AireLogic.PANDA.API.Domain.Entities;

namespace AireLogic.PANDA.API.Application.Services;

public sealed class ClinicianService(IClinicianRepository clinicianRepository) : IClinicianService
{
    public Task<IEnumerable<Clinician>> GetAllAsync(CancellationToken token = default)
    {
        return clinicianRepository.GetAllAsync(token);
    }
}
