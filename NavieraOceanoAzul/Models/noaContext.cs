using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NavieraOceanoAzul.Models
{
    public partial class noaContext : DbContext
    {
        public noaContext()
        {
        }

        public noaContext(DbContextOptions<noaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barco> Barcos { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Habitacion> Habitaciones { get; set; } = null!;
        public virtual DbSet<Tiquete> Tiquetes { get; set; } = null!;

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Barco>(entity =>
            {
                entity.HasKey(e => e.Idbarco)
                    .HasName("PRIMARY");

                entity.ToTable("barco");

                entity.Property(e => e.Idbarco)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idbarco");

                entity.Property(e => e.CapacidadCarga)
                    .HasPrecision(20)
                    .HasColumnName("capacidad_carga");

                entity.Property(e => e.CapacidadPersonas)
                    .HasColumnType("int(11)")
                    .HasColumnName("capacidad_personas");

                entity.Property(e => e.Idtiquete)
                    .HasColumnType("int(11)")
                    .HasColumnName("idtiquete");

                entity.Property(e => e.NombreBarco)
                    .HasMaxLength(45)
                    .HasColumnName("nombre_barco");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("PRIMARY");

                entity.ToTable("clientes");

                entity.Property(e => e.Idcliente)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idcliente");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(45)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(45)
                    .HasColumnName("primer_apellido");

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(45)
                    .HasColumnName("primer_nombre");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(45)
                    .HasColumnName("segundo_apellido");

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(45)
                    .HasColumnName("segundo_nombre");
            });

            modelBuilder.Entity<Habitacion>(entity =>
            {
                entity.HasKey(e => e.Idhabitacion)
                    .HasName("PRIMARY");

                entity.ToTable("habitaciones");

                entity.HasIndex(e => e.Idbarco, "habitacion_barco_idx");

                entity.Property(e => e.Idhabitacion)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idhabitacion");

                entity.Property(e => e.Capacidad)
                    .HasColumnType("int(11)")
                    .HasColumnName("capacidad");

                entity.Property(e => e.Idbarco)
                    .HasColumnType("int(11)")
                    .HasColumnName("idbarco");

                entity.Property(e => e.NumeroHabitacion)
                    .HasColumnType("int(11)")
                    .HasColumnName("numero_habitacion");

                entity.Property(e => e.UbicacionHabitacion)
                    .HasMaxLength(45)
                    .HasColumnName("ubicacion_habitacion");

                entity.HasOne(d => d.IdbarcoNavigation)
                    .WithMany(p => p.Habitaciones)
                    .HasForeignKey(d => d.Idbarco)
                    .HasConstraintName("habitacion_barco");
            });

            modelBuilder.Entity<Tiquete>(entity =>
            {
                entity.HasKey(e => e.Idtiquete)
                    .HasName("PRIMARY");

                entity.ToTable("tiquetes");

                entity.HasIndex(e => e.Idbarco, "idbarco_idx");

                entity.HasIndex(e => e.Idcliente, "idcliente_idx");

                entity.Property(e => e.Idtiquete)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idtiquete");

                entity.Property(e => e.FechaEmision)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_emision");

                entity.Property(e => e.FechaLlegada)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_llegada");

                entity.Property(e => e.FechaSalida)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_salida");

                entity.Property(e => e.Idbarco)
                    .HasColumnType("int(11)")
                    .HasColumnName("idbarco");

                entity.Property(e => e.Idcliente)
                    .HasColumnType("int(11)")
                    .HasColumnName("idcliente");

                entity.Property(e => e.Precio)
                    .HasMaxLength(45)
                    .HasColumnName("precio");

                entity.Property(e => e.PuertoDestino)
                    .HasMaxLength(45)
                    .HasColumnName("puerto_destino");

                entity.Property(e => e.PuertoOrigen)
                    .HasMaxLength(45)
                    .HasColumnName("puerto_origen");

                entity.HasOne(d => d.IdbarcoNavigation)
                    .WithMany(p => p.Tiquetes)
                    .HasForeignKey(d => d.Idbarco)
                    .HasConstraintName("idbarco");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Tiquetes)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("idcliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
