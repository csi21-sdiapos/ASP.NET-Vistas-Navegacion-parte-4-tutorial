using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Webb_app_MVC_PostgreSQL_DAL.Modelos;

public partial class AlumnosContext : DbContext
{
    public AlumnosContext()
    {
    }

    public AlumnosContext(DbContextOptions<AlumnosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<EjemploAlumno> EjemploAlumnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Alumnos;User Id=postgres;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Asignaturas_pkey");

            entity.ToTable("Asignaturas", "EjemploRutas", tb => tb.HasComment("Entidad que regula las asignaturas de los alumnos"));

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.NombreAsignatura)
                .HasColumnType("character varying")
                .HasColumnName("nombre_asignatura");
        });

        modelBuilder.Entity<EjemploAlumno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ejemploAlumno_pkey");

            entity.ToTable("ejemploAlumno", "EjemploRutas", tb => tb.HasComment("Entidad de ejemplo para los alumnos"));

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.AlumnoApellido)
                .HasColumnType("character varying")
                .HasColumnName("alumno_apellido");
            entity.Property(e => e.AlumnoApellido2)
                .HasColumnType("character varying")
                .HasColumnName("alumno_apellido2");
            entity.Property(e => e.AlumnoNombre)
                .HasColumnType("character varying")
                .HasColumnName("alumno_nombre");
            entity.Property(e => e.IdAsignatura).HasColumnName("id_asignatura");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.EjemploAlumno)
                .HasForeignKey<EjemploAlumno>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_asignatura");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
