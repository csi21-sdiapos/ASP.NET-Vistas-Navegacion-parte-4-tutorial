using System;
using System.Collections.Generic;

namespace Webb_app_MVC_PostgreSQL_DAL.Modelos;

/// <summary>
/// Entidad que regula las asignaturas de los alumnos
/// </summary>
public partial class Asignatura
{
    public long Id { get; set; }

    public string NombreAsignatura { get; set; } = null!;

    public virtual EjemploAlumno? EjemploAlumno { get; set; }
}
