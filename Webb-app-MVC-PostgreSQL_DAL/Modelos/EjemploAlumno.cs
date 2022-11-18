using System;
using System.Collections.Generic;

namespace Webb_app_MVC_PostgreSQL_DAL.Modelos;

/// <summary>
/// Entidad de ejemplo para los alumnos
/// </summary>
public partial class EjemploAlumno
{
    public long Id { get; set; }

    public string AlumnoNombre { get; set; } = null!;

    public string AlumnoApellido { get; set; } = null!;

    public string AlumnoApellido2 { get; set; } = null!;

    public long? IdAsignatura { get; set; }

    public virtual Asignatura IdNavigation { get; set; } = null!;
}
