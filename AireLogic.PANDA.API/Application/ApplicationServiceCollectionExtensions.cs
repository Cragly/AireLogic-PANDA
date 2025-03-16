using AireLogic.PANDA.API.Application.Contracts;
using AireLogic.PANDA.API.Application.Services;
using AireLogic.PANDA.API.Infrastructure.Database.Repositories;
using FluentValidation;

namespace AireLogic.PANDA.API.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationExtensions(this IServiceCollection services)
    {
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IPatientRepository, PatientRepository>();

        services.AddScoped<IClinicianService, ClinicianService>();
        services.AddScoped<IClinicianRepository, ClinicianRepository>();

        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();

        services.AddValidatorsFromAssemblyContaining<Program>();
        return services;
    }
}
