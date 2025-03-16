using AireLogic.PANDA.API.Application.Contracts;
using AireLogic.PANDA.API.Domain.Entities;
using FluentValidation;

namespace AireLogic.PANDA.API.Application.Services;

public sealed class AppointmentService(IAppointmentRepository appointmentRepository, IValidator<Appointment> appointmentValidator) : IAppointmentService
{
    public async Task<bool> CreateAsync(Appointment appointment, CancellationToken token = default)
    {
        await appointmentValidator.ValidateAndThrowAsync(appointment, cancellationToken: token);
        return await appointmentRepository.CreateAsync(appointment, token);
    }

    public Task<IEnumerable<Appointment>> GetAllAsync(CancellationToken token = default)
    {
        return appointmentRepository.GetAllAsync(token);
    }
}
