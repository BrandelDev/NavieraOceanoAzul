using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NavieraOceanoAzul.Models
{
    public partial class Habitacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idhabitacion { get; set; }
        public int? Idbarco { get; set; }
        public int? NumeroHabitacion { get; set; }
        public int? Capacidad { get; set; }
        public string? UbicacionHabitacion { get; set; }

        public virtual Barco? IdbarcoNavigation { get; set; }
    }
}
