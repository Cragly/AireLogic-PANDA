using System.Globalization;
using AireLogic.PANDA.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AireLogic.PANDA.API.Infrastructure.Database.Configurations;

public sealed class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).HasColumnType("uniqueidentifier");

        builder.HasOne<Patient>().WithMany().HasForeignKey(a => a.PatientId);
        builder.HasOne<Clinician>().WithMany().HasForeignKey(a => a.ClinicianId);

        builder.Property(a => a.Status).IsRequired();
        builder.Property(a => a.StartTime).IsRequired();
        builder.Property(a => a.EndTime).IsRequired();
        builder.Property(a => a.Duration).IsRequired();
        builder.Property(a => a.Department).IsRequired().HasMaxLength(50).IsUnicode(false);
        builder.Property(a => a.Postcode).IsRequired().HasMaxLength(8).IsUnicode(false);

        builder.HasData(
            new Appointment
            {
                Id = new Guid("343d31d4-5993-47ef-a468-7884a467ae80"),
                PatientId = new Guid("9a9e8d7e-58d2-4ecc-93f1-4425f1e51bec"),
                ClinicianId = new Guid("b7fd5c25-61d6-4634-82f0-e18f27b51f2a"),
                Status = AppointmentStatus.Attended,
                StartTime = DateTimeOffset.ParseExact("2018-01-21T16:30:00+00:00", "yyyy-MM-dd'T'HH:mm:sszzz", CultureInfo.InvariantCulture),
                Duration = 15,
                Department = "oncology",
                Postcode = "UB56 7XQ"
            }, new Appointment
            {
                Id = new Guid("01542f70-929f-4c9a-b4fa-e672310d7e78"),
                PatientId = new Guid("892bde48-96da-4bad-8114-a7fe62109462"),
                ClinicianId = new Guid("9eafd270-8071-4a09-85ba-f040a7b57e90"),
                Status = AppointmentStatus.Active,
                StartTime = DateTimeOffset.ParseExact("2025-06-04T16:30:00+01:00", "yyyy-MM-dd'T'HH:mm:sszzz", CultureInfo.InvariantCulture),
                Duration = 60,
                Department = "oncology",
                Postcode = "IM2N 4LG"
            }, new Appointment
            {
                Id = new Guid("70ead2bc-40c1-42ef-8d00-60c0b38d0a4e"),
                PatientId = new Guid("1929d3cf-83c1-487a-838f-c42c023ec42f"),
                ClinicianId = new Guid("b85fa2f9-faff-4ed2-b69b-7e5c198e65be"),
                Status = AppointmentStatus.Attended,
                StartTime = DateTimeOffset.ParseExact("2018-09-04T13:00:00+01:00", "yyyy-MM-dd'T'HH:mm:sszzz", CultureInfo.InvariantCulture),
                Duration = 60,
                Department = "gastroentology",
                Postcode = "E91 9AE"
            });
    }
}
