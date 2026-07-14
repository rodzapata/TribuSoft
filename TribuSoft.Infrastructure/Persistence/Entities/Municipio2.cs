using System;
using System.Collections.Generic;
using System.Text;

namespace TribuSoft.Infrastructure.Persistence.Entities
{
    public class Municipio2
    {
        // Usamos 'init' ya que el código suele ser la llave primaria natural y no cambia tras crearse.
        public required string Codigo { get; init; }
        public required string Nombre { get; set; }
        public required string CodigoDepartamento { get; set; }

        // Respaldamos la lista en un campo privado
        private readonly List<Tercero> _terceros = [];

        // Exponemos la colección como de solo lectura para proteger la consistencia del dominio
        public IReadOnlyCollection<Tercero> Terceros => _terceros.AsReadOnly();

        // Constructor requerido por Entity Framework Core para la materialización
        private Municipio2() { }

        // Constructor recomendado para crear la entidad de forma controlada
        public Municipio2(string codigo, string nombre, string codigoDepartamento)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(codigo);
            ArgumentException.ThrowIfNullOrWhiteSpace(nombre);
            ArgumentException.ThrowIfNullOrWhiteSpace(codigoDepartamento);

            Codigo = codigo;
            Nombre = nombre;
            CodigoDepartamento = codigoDepartamento;
        }

    }
}
