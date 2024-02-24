using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NavieraOceanoAzul.Models
{
    public partial class Tiquete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idtiquete { get; set; }
        public string? PuertoDestino { get; set; }
        public string? PuertoOrigen { get; set; }
        public int? Idcliente { get; set; }
        public DateTime? FechaEmision { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string? Precio { get; set; }
        public int? Idbarco { get; set; }
        public DateTime? FechaLlegada { get; set; }

        public virtual Barco? IdbarcoNavigation { get; set; }
        public virtual Cliente? IdclienteNavigation { get; set; }
    }
}
