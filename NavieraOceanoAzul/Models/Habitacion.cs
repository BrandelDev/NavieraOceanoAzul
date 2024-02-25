using System;
using System.Collections.Generic;

namespace NavieraOceanoAzul.Models
{
    public partial class Habitacion
    {
        public int Idhabitaciones { get; set; }
        public string? NumeroHabitacion { get; set; }
        public string? Capacidad { get; set; }
        public string? UbicacionHabitacion { get; set; }
        public int? Idbarco { get; set; }
        public virtual Barco? IdbarcoNavigation { get; set; }
    }
}
