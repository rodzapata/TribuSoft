using System;
using System.Collections.Generic;
using System.Text;
using TribuSoft.Domain.ValueObjects;

namespace TribuSoft.Domain.Entities;

public abstract class Tercero
{
    // Id autoincremental manejado por EF Core
    public long Id { get; private set; }

    // Propiedades de Solo Lectura (Inmutabilidad de Identidad)
    public TipoDocumento TipoDocumento { get; private set; }
    public string NumeroDocumento { get; private set; }

    // Ubicación compartida
    public string Direccion { get; private set; }
    public string CodigoMunicipio { get; private set; }

    // Relación EF Core
    public Municipio Municipio { get; private set; } = null!;

    [Obsolete("Usar solo para EF Core", error: false)]
    protected Tercero() { }

    protected Tercero(TipoDocumento tipoDocumento, string numeroDocumento, string direccion, string codigoMunicipio)
    {
        ArgumentNullException.ThrowIfNull(tipoDocumento);
        ArgumentException.ThrowIfNullOrWhiteSpace(numeroDocumento);
        ArgumentException.ThrowIfNullOrWhiteSpace(direccion);
        ArgumentException.ThrowIfNullOrWhiteSpace(codigoMunicipio);

        TipoDocumento = tipoDocumento;
        NumeroDocumento = numeroDocumento;
        Direccion = direccion;
        CodigoMunicipio = codigoMunicipio;
    }

    public void ActualizarUbicacion(string nuevaDireccion, string nuevoCodigoMunicipio)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nuevaDireccion);
        ArgumentException.ThrowIfNullOrWhiteSpace(nuevoCodigoMunicipio);

        Direccion = nuevaDireccion;
        CodigoMunicipio = nuevoCodigoMunicipio;
    }
}
