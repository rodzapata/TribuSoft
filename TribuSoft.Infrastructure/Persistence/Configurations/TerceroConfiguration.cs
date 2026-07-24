using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TribuSoft.Domain.Entities;
using TribuSoft.Domain.ValueObjects;

namespace TribuSoft.Infrastructure.Persistence.Configurations;

public sealed class TerceroConfiguration : IEntityTypeConfiguration<Tercero>
{
    public void Configure(EntityTypeBuilder<Tercero> builder)
    {
        builder.ToTable("tercero");

        builder.HasKey(t => t.Id)
            .HasName("pk_tercero");

        builder.Property(t => t.Id)
            .UseIdentityAlwaysColumn()
            .HasColumnName("id");

        builder.Property(t => t.NumeroDocumento)
            .HasColumnName("numero_documento")
            .HasMaxLength(20);

        builder.HasIndex(t => t.NumeroDocumento)
            .IsUnique()
            .HasDatabaseName("uq_tercero_documento");

        builder.Property(t => t.Direccion)
            .HasColumnName("direccion")
            .HasMaxLength(130);

        builder.Property(t => t.CodigoMunicipio)
            .HasColumnName("codigo_municipio")
            .HasMaxLength(5)
            .IsFixedLength();

        builder.Property(t => t.TipoDocumento)
            .HasConversion(
                td => td.Codigo,
                codigo => TipoDocumento.FromCodigo(codigo))
            .HasColumnName("tipo_documento")
            .HasMaxLength(2)
            .IsFixedLength();

        builder.HasOne(t => t.Municipio)
            .WithMany(m => m.Terceros)
            .HasForeignKey(t => t.CodigoMunicipio)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasDiscriminator<string>("tipo_persona")
            .HasValue<PersonaNatural>("N")
            .HasValue<PersonaJuridica>("J");


    }
}
