using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TribuSoft.Domain.Entities;

namespace TribuSoft.Infrastructure.Persistence.Configurations;

internal sealed class MunicipioConfiguration: IEntityTypeConfiguration<Municipio>
{
    public void Configure(EntityTypeBuilder<Municipio> builder) {
        builder.HasKey(m => m.Codigo)
            .HasName("pk_municipio");

        builder.ToTable("municipio");

        builder.Property(m => m.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(5)
            .IsFixedLength();

        builder.Property(m => m.CodigoDepartamento)
            .HasColumnName("codigo_departamento")
            .HasMaxLength(2)
            .IsFixedLength();

        builder.Property(m => m.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(120);

        builder.HasOne(m => m.Departamento)
            .WithMany(d => d.Municipios)
            .HasForeignKey(m => m.CodigoDepartamento)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_municipio_departamento");

    }
}
