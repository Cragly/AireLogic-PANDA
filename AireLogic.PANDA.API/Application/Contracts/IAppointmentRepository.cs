using AireLogic.PANDA.API.Domain.Entities;

namespace AireLogic.PANDA.API.Application.Contracts;

public interface IAppointmentRepository
{
    Task<bool> CreateAsync(Appointment appointment, CancellationToken token = default);

    Task<IEnumerable<Appointment>> GetAllAsync(CancellationToken token = default);
}
