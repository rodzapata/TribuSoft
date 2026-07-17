using System;
using System.Collections.Generic;
using System.Text;

namespace TribuSoft.Domain.Entities
{
    public class Municipio
    {
        // Usamos 'init' ya que el código suele ser la llave primaria natural y no cambia tras crearse.
        public string Codigo { get; private init; }
        public string Nombre { get; private set; }
        public string CodigoDepartamento { get; private set; }

        // Respaldamos la lista en un campo privado
        private readonly List<Tercero> _terceros = [];

        // Exponemos la colección como de solo lectura para proteger la consistencia del dominio
        public IReadOnlyCollection<Tercero> Terceros => _terceros;

        // Constructor requerido por Entity Framework Core para la materialización
        private Municipio() { }

        // Constructor recomendado para crear la entidad de forma controlada
        public Municipio(string codigo, string nombre, string codigoDepartamento)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(codigo);
            ArgumentException.ThrowIfNullOrWhiteSpace(nombre);
            ArgumentException.ThrowIfNullOrWhiteSpace(codigoDepartamento);

            Codigo = codigo;
            Nombre = nombre;
            CodigoDepartamento = codigoDepartamento;
        }

        public void CambiarNombre(string nombre)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nombre);

            Nombre = nombre;
        }

    }
}
