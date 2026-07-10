using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TribuSoft.Infrastructure.Persistence.Entities;

namespace TribuSoft.Infrastructure.Persistence;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Tercero> Terceros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("pk_departamento");

            entity.ToTable("departamento");

            entity.Property(e => e.Codigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("pk_municipio");

            entity.ToTable("municipio");

            entity.Property(e => e.Codigo)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("codigo");
            entity.Property(e => e.CodigoDepartamento)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("codigo_departamento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");

            entity.HasOne(d => d.CodigoDepartamentoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.CodigoDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_municipio_departamento");
        });

        modelBuilder.Entity<Tercero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tercero");

            entity.ToTable("tercero");

            entity.HasIndex(e => e.NumeroDocumento, "uq_tercero_documento").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CodigoMunicipio)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("codigo_municipio");
            entity.Property(e => e.Direccion)
                .HasMaxLength(130)
                .HasColumnName("direccion");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(20)
                .HasColumnName("numero_documento");
            entity.Property(e => e.OtrosNombres)
                .HasMaxLength(120)
                .HasColumnName("otros_nombres");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(60)
                .HasColumnName("primer_apellido");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(60)
                .HasColumnName("primer_nombre");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(200)
                .HasColumnName("razon_social");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(60)
                .HasColumnName("segundo_apellido");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("tipo_documento");

            entity.HasOne(d => d.CodigoMunicipioNavigation).WithMany(p => p.Terceros)
                .HasForeignKey(d => d.CodigoMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tercero_municipio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
