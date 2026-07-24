using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TribuSoft.Domain.Entities;

namespace TribuSoft.Infrastructure.Persistence.Configurations;

internal sealed class PersonaJuridicaConfiguration : IEntityTypeConfiguration<PersonaJuridica>
{
    public void Configure(EntityTypeBuilder<PersonaJuridica> builder)
    {
        builder.Property(p => p.RazonSocial)
            .HasColumnName("razon_social")
            .HasMaxLength(200);
    }
}
