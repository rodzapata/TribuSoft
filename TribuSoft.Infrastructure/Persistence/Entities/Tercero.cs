using System;
using System.Collections.Generic;

namespace TribuSoft.Infrastructure.Persistence.Entities;

public partial class Tercero
{
    public long Id { get; set; }

    public string TipoDocumento { get; set; } = null!;

    public string NumeroDocumento { get; set; } = null!;

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string? PrimerNombre { get; set; }

    public string? OtrosNombres { get; set; }

    public string? RazonSocial { get; set; }

    public string? Direccion { get; set; }

    public string CodigoMunicipio { get; set; } = null!;

    public virtual Municipio CodigoMunicipioNavigation { get; set; } = null!;
}
