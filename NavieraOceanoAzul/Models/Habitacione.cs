using System;
using System.Collections.Generic;

namespace NavieraOceanoAzul.Models
{
    public partial class Habitacione
    {
        public int Idhabitacion { get; set; }
        public int? Idbarco { get; set; }
        public int? NumeroHabitacion { get; set; }
        public int? Capacidad { get; set; }
        public string? UbicacionHabitacion { get; set; }

        public virtual Barco? IdbarcoNavigation { get; set; }
    }
}
