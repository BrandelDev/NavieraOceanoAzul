using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NavieraOceanoAzul.Models
{
    public partial class Puerto
    {
          public Puerto()
        {
            AsignacionPuertoBarcos = new HashSet<AsignacionPuertoBarco>();
            RutaPuertoDestinoNavigations = new HashSet<Ruta>();
            RutaPuertoOrigenNavigations = new HashSet<Ruta>();
        }

        public int IdPuertos { get; set; }
        
        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }
        
        [JsonPropertyName("ciudad")]
        public string? Ciudad { get; set; }

        [JsonIgnore]
        public virtual ICollection<AsignacionPuertoBarco> AsignacionPuertoBarcos { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Ruta> RutaPuertoDestinoNavigations { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Ruta> RutaPuertoOrigenNavigations { get; set; }
    }
}
