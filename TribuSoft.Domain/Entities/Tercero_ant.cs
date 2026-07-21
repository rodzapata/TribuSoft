using System;
using System.Collections.Generic;
using System.Text;
using TribuSoft.Domain.ValueObjects;

namespace TribuSoft.Domain.Entities;

public sealed class Tercero_ant
{
    // Id autoincremental manejado por EF Core
    public long Id { get; private set; }

    // Propiedades de Solo Lectura tras la creación (Inmutabilidad de Identidad)
    public TipoDocumento TipoDocumento { get; private set; }
    public string NumeroDocumento { get; private set; }

    // Propiedades de Estado (Encapsuladas)
    public string? PrimerApellido { get; private set; }
    public string? SegundoApellido { get; private set; }
    public string? PrimerNombre { get; private set; }
    public string? OtrosNombres { get; private set; }
    public string? RazonSocial { get; private set; }
    public string Direccion { get; private set; } = null!;
    public string CodigoMunicipio { get; private set; } = null!;

    // Relaciones EF Core
    public Municipio Municipio { get; private set; } = null!;

    // Constructor vacío para persistencia / ORM (EF Core)
    [Obsolete("Usar solo para EF Core", error: false)]
    private Tercero_ant() { }

    // Único Constructor Público: Fuerza un estado inicial válido según reglas de negocio
    public Tercero_ant(
        TipoDocumento tipoDocumento,
        string numeroDocumento,
        string direccion,
        string codigoMunicipio,
        string? primerNombre = null,
        string? primerApellido = null,
        string? segundoApellido = null,
        string? otrosNombres = null,
        string? razonSocial = null)
    {
        // Validaciones transversales
        ArgumentNullException.ThrowIfNull(tipoDocumento);
        ArgumentException.ThrowIfNullOrWhiteSpace(numeroDocumento);
        ArgumentException.ThrowIfNullOrWhiteSpace(direccion);
        ArgumentException.ThrowIfNullOrWhiteSpace(codigoMunicipio);

        // Validación de Reglas de Negocio Específicas
        if (tipoDocumento == TipoDocumento.CedulaCiudadania) // Persona Natural (Cédula de Ciudadanía)
        {
            if (string.IsNullOrWhiteSpace(primerNombre) || string.IsNullOrWhiteSpace(primerApellido))
            {
                throw new ArgumentException("Para personas naturales (Tipo '13'), el Primer Nombre y Primer Apellido son obligatorios.");
            }

            PrimerNombre = primerNombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            OtrosNombres = otrosNombres;
            RazonSocial = null; // No aplica
        }
        else if (tipoDocumento == TipoDocumento.Nit) // Persona Jurídica (NIT)
        {
            if (string.IsNullOrWhiteSpace(razonSocial))
            {
                throw new ArgumentException("Para personas jurídicas (Tipo '31'), la Razón Social es obligatoria.");
            }

            RazonSocial = razonSocial;
            // Limpieza explícita de campos de persona natural
            PrimerNombre = null;
            PrimerApellido = null;
            SegundoApellido = null;
            OtrosNombres = null;
        }
        else
        {
            // Opcional: Manejo de otros tipos de documento intermedios o lanzar excepción
            throw new ArgumentException($"Tipo de documento '{tipoDocumento}' no soportado.");
        }

        TipoDocumento = tipoDocumento;
        NumeroDocumento = numeroDocumento;
        Direccion = direccion;
        CodigoMunicipio = codigoMunicipio;
    }

    // Métodos de Comportamiento (Cambio de estado seguro)

    public void ActualizarUbicacion(string nuevaDireccion, string nuevoCodigoMunicipio)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nuevaDireccion);
        ArgumentException.ThrowIfNullOrWhiteSpace(nuevoCodigoMunicipio);

        Direccion = nuevaDireccion;
        CodigoMunicipio = nuevoCodigoMunicipio;
    }

    // Si el tercero es Persona Natural, permitimos mutar sus nombres bajo validación
    public void ModificarNombres(string primerNombre, string? otrosNombres, string primerApellido, string? segundoApellido)
    {
        if (TipoDocumento != TipoDocumento.CedulaCiudadania)
        {
            throw new InvalidOperationException("No se pueden modificar nombres individuales en una persona jurídica.");
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(primerNombre);
        ArgumentException.ThrowIfNullOrWhiteSpace(primerApellido);

        PrimerNombre = primerNombre;
        OtrosNombres = otrosNombres;
        PrimerApellido = primerApellido;
        SegundoApellido = segundoApellido;
    }

    // Si el tercero es Persona Jurídica, permitimos mutar la Razón Social bajo validación
    public void ModificarRazonSocial(string nuevaRazonSocial)
    {
        if (TipoDocumento != TipoDocumento.Nit)
        {
            throw new InvalidOperationException("No se puede asignar una razón social a una persona natural.");
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(nuevaRazonSocial);

        RazonSocial = nuevaRazonSocial;
    }


}
