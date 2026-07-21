using System;
using System.Collections.Generic;
using System.Text;

namespace TribuSoft.Domain.ValueObjects;

public sealed record TipoDocumento
{
    public static readonly TipoDocumento CedulaCiudadania = new("13");

    public static readonly TipoDocumento Nit = new("31");

    public string Codigo { get; }

    private TipoDocumento(string codigo)
    {
        Codigo = codigo;
    }

    public bool EsPersonaNatural =>
        Codigo is "11" or "12" or "13" or "21" or "22";

    public bool EsPersonaJuridica =>
        Codigo == "31";

    public static TipoDocumento From(string codigo)
        => codigo switch
        {
            "13" => CedulaCiudadania,
            "31" => Nit,
            _ => throw new ArgumentException("Tipo de documento inválido.")
        };

    public override string ToString() => Codigo;
}