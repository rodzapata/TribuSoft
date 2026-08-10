using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TribuSoft.Domain.Entities;

namespace TribuSoft.Infrastructure.Persistence;

public sealed class AppDbContext_ant2 : DbContext
{
    public AppDbContext_ant2(DbContextOptions<AppDbContext_ant2> options)
        : base(options)
    {
    }

    public DbSet<Departamento> Departamentos => Set<Departamento>();

    public DbSet<Municipio> Municipios => Set<Municipio>();

    public  DbSet<Tercero> Terceros => Set<Tercero>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext_ant2).Assembly);

        base.OnModelCreating(modelBuilder);
    }


}
