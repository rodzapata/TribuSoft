using System;
using System.Collections.Generic;
using System.Text;

namespace TribuSoft.Infrastructure.Persistence.Entities
{
    internal class Departamento2
    {
        // Usamos 'init' ya que el código suele ser la llave primaria natural y no cambia tras crearse.
        public string Codigo { get; private init; }
        public string Nombre { get; private set; }

        // Respaldamos la lista en un campo privado
        private readonly List<Municipio> _municipios = [];

        // Exponemos la colección como de solo lectura para proteger la consistencia del dominio
        public IReadOnlyCollection<Municipio> Municipios => _municipios;

        // Constructor requerido por Entity Framework Core para la materialización
        private Departamento2() { }

        // Constructor recomendado para crear la entidad de forma controlada
        public Departamento2(string codigo, string nombre)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(codigo);
            ArgumentException.ThrowIfNullOrWhiteSpace(nombre);

            Codigo = codigo;
            Nombre = nombre;
        }
        public void CambiarNombre(string nombre)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nombre);

            Nombre = nombre;
        }

        // Método de negocio para encapsular cómo se añade un municipio
        public void RegistrarMunicipio(Municipio municipio)
        {
            ArgumentNullException.ThrowIfNull(municipio);

            // Aquí podrías agregar validaciones de negocio antes de insertar
            _municipios.Add(municipio);
        }
    }
}
