using System;
using System.Collections.Generic;

namespace TribuSoft.Infrastructure.Persistence.Entities;

public partial class Municipio
{
    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string CodigoDepartamento { get; set; } = null!;

    public virtual Departamento CodigoDepartamentoNavigation { get; set; } = null!;

    public virtual ICollection<Tercero> Terceros { get; set; } = new List<Tercero>();
}

