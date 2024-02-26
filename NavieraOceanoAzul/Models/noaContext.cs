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

        public virtual DbSet<AsignacionPuertoBarco> AsignacionPuertoBarcos { get; set; } = null!;
        public virtual DbSet<Barco> Barcos { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Habitacion> Habitaciones { get; set; } = null!;
        public virtual DbSet<Puerto> Puertos { get; set; } = null!;
        public virtual DbSet<Ruta> Rutas { get; set; } = null!;
        public virtual DbSet<Tiquete> Tiquetes { get; set; } = null!;

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<AsignacionPuertoBarco>(entity =>
            {
                entity.HasKey(e => e.IdAsignacionPuertoBarco)
                    .HasName("PRIMARY");

                entity.ToTable("asignacion_puerto_barco");

                entity.HasIndex(e => e.Idbarco, "ABFK_idx");

                entity.HasIndex(e => e.Idpuerto, "APFK_idx");

                entity.Property(e => e.IdAsignacionPuertoBarco)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAsignacionPuertoBarco");

                entity.Property(e => e.Idbarco)
                    .HasColumnType("int(11)")
                    .HasColumnName("idbarco");

                entity.Property(e => e.Idpuerto)
                    .HasColumnType("int(11)")
                    .HasColumnName("idpuerto");

                entity.HasOne(d => d.IdbarcoNavigation)
                    .WithMany(p => p.AsignacionPuertoBarcos)
                    .HasForeignKey(d => d.Idbarco)
                    .HasConstraintName("ABFK");

                entity.HasOne(d => d.IdpuertoNavigation)
                    .WithMany(p => p.AsignacionPuertoBarcos)
                    .HasForeignKey(d => d.Idpuerto)
                    .HasConstraintName("APFK");
            });

            modelBuilder.Entity<Barco>(entity =>
            {
                entity.HasKey(e => e.Idbarco)
                    .HasName("PRIMARY");

                entity.ToTable("barco");

                entity.Property(e => e.Idbarco)
                    .HasColumnType("int(11)")
                    .HasColumnName("idbarco");

                entity.Property(e => e.CapacidadCarga)
                    .HasPrecision(20)
                    .HasColumnName("capacidad_carga");

                entity.Property(e => e.CapacidadPersonas)
                    .HasColumnType("int(11)")
                    .HasColumnName("capacidad_personas");

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
                    .HasColumnName("idcliente");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(255)
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
                entity.HasKey(e => e.Idhabitaciones)
                    .HasName("PRIMARY");

                entity.ToTable("habitaciones");

                entity.HasIndex(e => e.Idbarco, "barcoFk_idx");

                entity.Property(e => e.Idhabitaciones)
                    .HasColumnType("int(11)")
                    .HasColumnName("idhabitaciones");

                entity.Property(e => e.Capacidad)
                    .HasMaxLength(45)
                    .HasColumnName("capacidad");

                entity.Property(e => e.Idbarco)
                    .HasColumnType("int(11)")
                    .HasColumnName("idbarco");

                entity.Property(e => e.NumeroHabitacion)
                    .HasMaxLength(45)
                    .HasColumnName("numero_habitacion");

                entity.Property(e => e.UbicacionHabitacion)
                    .HasMaxLength(45)
                    .HasColumnName("ubicacion_habitacion");

                entity.HasOne(d => d.IdbarcoNavigation)
                    .WithMany(p => p.Habitaciones)
                    .HasForeignKey(d => d.Idbarco)
                    .HasConstraintName("BarcoFk_1");
            });

            modelBuilder.Entity<Puerto>(entity =>
            {
                entity.HasKey(e => e.IdPuertos)
                    .HasName("PRIMARY");

                entity.ToTable("puertos");

                entity.Property(e => e.IdPuertos)
                    .HasColumnType("int(11)")
                    .HasColumnName("idPuertos");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(45)
                    .HasColumnName("ciudad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Ruta>(entity =>
            {
                entity.HasKey(e => e.IdRutas)
                    .HasName("PRIMARY");

                entity.ToTable("rutas");

                entity.HasIndex(e => e.PuertoDestino, "PuertoDestinoFk_idx");

                entity.HasIndex(e => e.PuertoOrigen, "PuertoOrigenFk_idx");

                entity.Property(e => e.IdRutas)
                    .HasColumnType("int(11)")
                    .HasColumnName("idRutas");

                entity.Property(e => e.Distancia)
                    .HasMaxLength(45)
                    .HasColumnName("distancia");

                entity.Property(e => e.EstadoRuta)
                    .HasMaxLength(45)
                    .HasColumnName("estado_ruta");

                entity.Property(e => e.FrecuenciaRuta)
                    .HasMaxLength(45)
                    .HasColumnName("frecuencia_ruta");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.Property(e => e.PuertoDestino)
                    .HasColumnType("int(11)")
                    .HasColumnName("puerto_destino");

                entity.Property(e => e.PuertoOrigen)
                    .HasColumnType("int(11)")
                    .HasColumnName("puerto_origen");

                entity.HasOne(d => d.PuertoDestinoNavigation)
                    .WithMany(p => p.RutaPuertoDestinoNavigations)
                    .HasForeignKey(d => d.PuertoDestino)
                    .HasConstraintName("PuertoDestinoFk");

                entity.HasOne(d => d.PuertoOrigenNavigation)
                    .WithMany(p => p.RutaPuertoOrigenNavigations)
                    .HasForeignKey(d => d.PuertoOrigen)
                    .HasConstraintName("PuertoOrigenFk");
            });

            modelBuilder.Entity<Tiquete>(entity =>
            {
                entity.HasKey(e => e.Idtiquete)
                    .HasName("PRIMARY");

                entity.ToTable("tiquetes");

                entity.HasIndex(e => e.Idruta, "RutaFK_idx");

                entity.HasIndex(e => e.Idbarco, "idbarco_idx");

                entity.HasIndex(e => e.Idcliente, "idcliente_idx");

                entity.Property(e => e.Idtiquete)
                    .HasColumnType("int(11)")
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

                entity.Property(e => e.Idruta)
                    .HasColumnType("int(11)")
                    .HasColumnName("idruta");

                entity.Property(e => e.Precio)
                    .HasMaxLength(45)
                    .HasColumnName("precio");

                entity.HasOne(d => d.IdbarcoNavigation)
                    .WithMany(p => p.Tiquetes)
                    .HasForeignKey(d => d.Idbarco)
                    .HasConstraintName("BarcoFk");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Tiquetes)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("ClienteFK");

                entity.HasOne(d => d.IdrutaNavigation)
                    .WithMany(p => p.Tiquetes)
                    .HasForeignKey(d => d.Idruta)
                    .HasConstraintName("RutaFK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
