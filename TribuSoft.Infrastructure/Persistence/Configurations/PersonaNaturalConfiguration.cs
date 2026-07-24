using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TribuSoft.Domain.Entities;

namespace TribuSoft.Infrastructure.Persistence.Configurations;

internal sealed class PersonaNaturalConfiguration : IEntityTypeConfiguration<PersonaNatural>
{
    public void Configure(EntityTypeBuilder<PersonaNatural> builder)
    {
        builder.Property(p => p.PrimerNombre)
            .HasColumnName("primer_nombre")
            .HasMaxLength(60);

        builder.Property(p => p.OtrosNombres)
            .HasColumnName("otros_nombres")
            .HasMaxLength(120);

        builder.Property(p => p.PrimerApellido)
            .HasColumnName("primer_apellido")
            .HasMaxLength(60);

        builder.Property(p => p.SegundoApellido)
            .HasColumnName("segundo_apellido")
            .HasMaxLength(60);
    }
}
