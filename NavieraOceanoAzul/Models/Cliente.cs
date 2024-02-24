using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NavieraOceanoAzul.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Tiquetes = new HashSet<Tiquete>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idcliente { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? Email { get; set; }
        public string? Contrasena { get; set; }

        public virtual ICollection<Tiquete> Tiquetes { get; set; }
    }
}
