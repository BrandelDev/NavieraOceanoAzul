using System;
using System.Collections.Generic;

namespace NavieraOceanoAzul.Models
{
    public partial class Puerto
    {
        public Puerto()
        {
            AsignacionPuertoBarcos = new HashSet<AsignacionPuertoBarco>();
            Ruta = new HashSet<Ruta>();
        }

        public int IdPuertos { get; set; }
        public string? Nombre { get; set; }
        public string? Ciudad { get; set; }

        public virtual ICollection<AsignacionPuertoBarco> AsignacionPuertoBarcos { get; set; }
        public virtual ICollection<Ruta> Ruta { get; set; }
    }
}
