using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonPropertyName("capacidadPersonas")]
        public int? CapacidadPersonas { get; set; }

        [JsonPropertyName("capacidadCarga")]
        public decimal? CapacidadCarga { get; set; }

        [JsonPropertyName("nombreBarco")]
        public string? NombreBarco { get; set; }

        [JsonIgnore]
        public virtual ICollection<AsignacionPuertoBarco> AsignacionPuertoBarcos { get; set; }

        [JsonIgnore]
        public virtual ICollection<Habitacion> Habitaciones { get; set; }

        [JsonIgnore]
        public virtual ICollection<Tiquete> Tiquetes { get; set; }
    }
}