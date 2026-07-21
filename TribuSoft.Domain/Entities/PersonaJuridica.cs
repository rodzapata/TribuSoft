using System;
using System.Collections.Generic;
using System.Text;
using TribuSoft.Domain.ValueObjects;

namespace TribuSoft.Domain.Entities;

public sealed class PersonaJuridica : Tercero
{
    public string RazonSocial { get; private set; }

    [Obsolete("Usar solo para EF Core", error: false)]
    private PersonaJuridica() : base() { }

    public PersonaJuridica(
        string numeroDocumento,
        string direccion,
        string codigoMunicipio,
        string razonSocial)
        : base(TipoDocumento.Nit, numeroDocumento, direccion, codigoMunicipio)
    {
        ModificarRazonSocial(razonSocial);
    }

    public void ModificarRazonSocial(string nuevaRazonSocial)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nuevaRazonSocial);
        RazonSocial = nuevaRazonSocial;
    }
}
