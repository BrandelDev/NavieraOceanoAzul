using System;
using System.Collections.Generic;

namespace NavieraOceanoAzul.Models
{
    public partial class Barco
    {
        public Barco()
        {
            AsignacionPuertoBarcos = new HashSet<AsignacionPuertoBarco>();
            Habitaciones = new HashSet<Habitacion>();
            Tiquetes = new HashSet<Tiquete>();
        }

        public int Idbarco { get; set; }
        public int? CapacidadPersonas { get; set; }
        public decimal? CapacidadCarga { get; set; }
        public string? NombreBarco { get; set; }

        public virtual ICollection<AsignacionPuertoBarco> AsignacionPuertoBarcos { get; set; }
        public virtual ICollection<Habitacion> Habitaciones { get; set; }
        public virtual ICollection<Tiquete> Tiquetes { get; set; }
    }
}
