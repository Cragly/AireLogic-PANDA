using System.Globalization;
using AireLogic.PANDA.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AireLogic.PANDA.API.Infrastructure.Database.Configurations;

public sealed class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnType("uniqueidentifier");

        builder.Property(p => p.NhsNumber).IsRequired().HasMaxLength(16).IsUnicode(false);
        builder.Property(p => p.Title).IsRequired().HasMaxLength(20);
        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Surname).IsRequired().HasMaxLength(50);
        builder.Property(p => p.DateOfBirth).IsRequired();
        builder.Property(p => p.Postcode).IsRequired().HasMaxLength(8).IsUnicode(false);

        builder.HasData(
            new Patient
            {
                Id = new Guid("9a9e8d7e-58d2-4ecc-93f1-4425f1e51bec"),
                NhsNumber = "1373645350",
                Title = "Dr",
                FirstName = "Glenn",
                Surname = "Clark",
                DateOfBirth = DateOnly.ParseExact("1996-02-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Postcode = "N6 2FA"
            },
            new Patient
            {
                Id = new Guid("892bde48-96da-4bad-8114-a7fe62109462"),
                NhsNumber = "1953262716",
                Title = "Dr",
                FirstName = "Ian",
                Surname = "Hall",
                DateOfBirth = DateOnly.ParseExact("1963-08-27", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Postcode = "WA55 8HE"
            }, new Patient
            {
                Id = new Guid("1929d3cf-83c1-487a-838f-c42c023ec42f"),
                NhsNumber = "0021403597",
                Title = "Dr",
                FirstName = "Bryan",
                Surname = "Hall",
                DateOfBirth = DateOnly.ParseExact("2002-02-12", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Postcode = "M4 2ST"
            });
    }
}

