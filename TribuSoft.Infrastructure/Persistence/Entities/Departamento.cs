using System;
using System.Collections.Generic;

namespace TribuSoft.Infrastructure.Persistence.Entities;

public partial class Departamento
{
    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
