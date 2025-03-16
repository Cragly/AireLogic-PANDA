using AireLogic.PANDA.API.Application.Contracts;
using AireLogic.PANDA.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AireLogic.PANDA.API.Infrastructure.Database.Repositories;

public sealed class PatientRepository(ApplicationDbContext dbContext) : IPatientRepository
{
    public async Task<bool> CreateAsync(Patient patient, CancellationToken token = default)
    {
        dbContext.Patients.Add(patient);

        return await dbContext.SaveChangesAsync(token) >= 0;
    }

    public async Task<Patient?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await dbContext.Patients.SingleOrDefaultAsync(p => p.Id == id, token);
    }

    public async Task<IEnumerable<Patient>> GetAllAsync(CancellationToken token = default)
    {
        return await dbContext.Patients.OrderBy(p => p.Surname).ToListAsync(token);
    }

    public async Task<bool> UpdateAsync(Patient patient, CancellationToken token = default)
    {
        dbContext.Patients.Update(patient);
        return await dbContext.SaveChangesAsync(token) >= 0;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        var patient = new Patient() { Id = id };
        dbContext.Patients.Remove(patient);

        int result = await dbContext.SaveChangesAsync(token);

        return result >= 0;
    }
    public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default)
    {
        return await dbContext.Patients.AnyAsync(p => p.Id == id, token);
    }
}
