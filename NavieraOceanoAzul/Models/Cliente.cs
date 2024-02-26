using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NavieraOceanoAzul.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Tiquetes = new HashSet<Tiquete>();
        }

        public int Idcliente { get; set; }

        [JsonPropertyName("primerNombre")]
        public string? PrimerNombre { get; set; }

        [JsonPropertyName("segundoNombre")]
        public string? SegundoNombre { get; set; }

        [JsonPropertyName("primerApellido")]
        public string? PrimerApellido { get; set; }

        [JsonPropertyName("segundoApellido")]
        public string? SegundoApellido { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonIgnore]
        public string? Contrasena { get; set; }

        [JsonIgnore]
        public virtual ICollection<Tiquete> Tiquetes { get; set; }
    }
}