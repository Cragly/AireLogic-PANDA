using AireLogic.PANDA.API.Application.Contracts;
using AireLogic.PANDA.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AireLogic.PANDA.API.Infrastructure.Database.Repositories;

public sealed class AppointmentRepository(ApplicationDbContext dbContext) : IAppointmentRepository
{
    public async Task<bool> CreateAsync(Appointment appointment, CancellationToken token = default)
    {
        dbContext.Appointments.Add(appointment);

        return await dbContext.SaveChangesAsync(token) >= 0;
    }

    public async Task<IEnumerable<Appointment>> GetAllAsync(CancellationToken token = default)
    {
        return await dbContext.Appointments.OrderBy(a => a.StartTime).ToListAsync(token);
    }
}
