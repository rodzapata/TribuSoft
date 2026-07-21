using System;
using System.Collections.Generic;
using System.Text;
using TribuSoft.Domain.ValueObjects;

namespace TribuSoft.Domain.Entities;


public sealed class PersonaNatural: Tercero
{
    public string PrimerNombre { get; private set; }
    public string? OtrosNombres { get; private set; }
    public string PrimerApellido { get; private set; }
    public string? SegundoApellido { get; private set; }


    [Obsolete("Usar solo para EF Core", error: false)]
    private PersonaNatural() : base(){

    }

    public PersonaNatural(
    string numeroDocumento,
    string direccion,
    string codigoMunicipio,
    string primerNombre,
    string primerApellido,
    string? otrosNombres = null,
    string? segundoApellido = null)
        : base(TipoDocumento.CedulaCiudadania, numeroDocumento, direccion, codigoMunicipio)
    {
        ModificarNombres(primerNombre, otrosNombres, primerApellido, segundoApellido);
    }

    public void ModificarNombres(string primerNombre, string? otrosNombres, string primerApellido, string? segundoApellido)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(primerNombre);
        ArgumentException.ThrowIfNullOrWhiteSpace(primerApellido);

        PrimerNombre = primerNombre;
        OtrosNombres = otrosNombres;
        PrimerApellido = primerApellido;
        SegundoApellido = segundoApellido;
    }
}
