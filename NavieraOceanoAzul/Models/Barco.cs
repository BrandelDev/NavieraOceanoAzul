using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NavieraOceanoAzul.Models
{
    public partial class Barco
    {
        public Barco()
        {
            Habitaciones = new HashSet<Habitacion>();
            Tiquetes = new HashSet<Tiquete>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idbarco { get; set; }
        public int? CapacidadPersonas { get; set; }
        public decimal? CapacidadCarga { get; set; }
        public string? NombreBarco { get; set; }
        public int? Idtiquete { get; set; }

        public virtual ICollection<Habitacion> Habitaciones { get; set; }
        public virtual ICollection<Tiquete> Tiquetes { get; set; }
    }
}
