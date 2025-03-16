using AireLogic.PANDA.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AireLogic.PANDA.API.Infrastructure.Database.Configurations;

public sealed class ClinicianConfiguration : IEntityTypeConfiguration<Clinician>
{
    public void Configure(EntityTypeBuilder<Clinician> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnType("uniqueidentifier");

        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Department).IsRequired().HasMaxLength(100).IsUnicode(false);

        builder.HasData(
            new Clinician
            {
                Id = new Guid("b7fd5c25-61d6-4634-82f0-e18f27b51f2a"),
                Name = "Jason Holloway",
                Department = "oncology"
            },
            new Clinician
            {
                Id = new Guid("9eafd270-8071-4a09-85ba-f040a7b57e90"),
                Name = "Bethany Rice-Hammond",
                Department = "oncology"
            }, new Clinician
            {
                Id = new Guid("b85fa2f9-faff-4ed2-b69b-7e5c198e65be"),
                Name = "Joseph Savage",
                Department = "gastroentology"
            });
    }
}
