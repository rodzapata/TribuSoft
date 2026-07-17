using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TribuSoft.Domain.Entities;

namespace TribuSoft.Infrastructure.Persistence.Configurations;

internal sealed class DepartamentoConfiguration: IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder) {
        builder.HasKey(d => d.Codigo)
            .HasName("pk_departamento");

        builder.ToTable("departamento");

        builder.Property(d => d.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(2)
            .IsFixedLength();

        builder.Property(d => d.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(80);

 /*
        builder.HasMany(d => d.Municipios)
       .WithOne(m => m.Departamento)
       .HasForeignKey(m => m.DepartamentoCodigo)
       .OnDelete(DeleteBehavior.Restrict);
  */
    }
}
