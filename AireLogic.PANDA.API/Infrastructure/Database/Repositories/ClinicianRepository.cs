using AireLogic.PANDA.API.Application.Contracts;
using AireLogic.PANDA.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AireLogic.PANDA.API.Infrastructure.Database.Repositories;

public sealed class ClinicianRepository(ApplicationDbContext dbContext) : IClinicianRepository
{
    public async Task<IEnumerable<Clinician>> GetAllAsync(CancellationToken token = default)
    {
        return await dbContext.Clinicians.OrderBy(c => c.Name).ToListAsync(token);
    }
}
