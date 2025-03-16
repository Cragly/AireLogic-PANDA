using AireLogic.PANDA.API.Domain.Entities;

namespace AireLogic.PANDA.API.Application.Services;

public interface IAppointmentService
{
    Task<bool> CreateAsync(Appointment appointment, CancellationToken token = default);

    Task<IEnumerable<Appointment>> GetAllAsync(CancellationToken token = default);
}
