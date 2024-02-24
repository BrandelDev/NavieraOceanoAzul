using System;
using System.Collections.Generic;

namespace NavieraOceanoAzul.Models
{
    public partial class Barco
    {
        public Barco()
        {
            Habitaciones = new HashSet<Habitacione>();
            Tiquetes = new HashSet<Tiquete>();
        }

        public int Idbarco { get; set; }
        public int? CapacidadPersonas { get; set; }
        public decimal? CapacidadCarga { get; set; }
        public string? NombreBarco { get; set; }
        public int? Idtiquete { get; set; }

        public virtual ICollection<Habitacione> Habitaciones { get; set; }
        public virtual ICollection<Tiquete> Tiquetes { get; set; }
    }
}
