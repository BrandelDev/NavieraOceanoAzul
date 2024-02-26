using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NavieraOceanoAzul.Models
{
    public partial class Ruta
    {
        public int IdRutas { get; set; }

        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }

        [JsonPropertyName("puertoOrigen")]
        public int? PuertoOrigen { get; set; }

        [JsonPropertyName("puertoDestino")]
        public int? PuertoDestino { get; set; }

        [JsonPropertyName("distancia")]
        public string? Distancia { get; set; }

        [JsonPropertyName("frecuenciaRuta")]
        public string? FrecuenciaRuta { get; set; }

        [JsonPropertyName("estadoRuta")]
        public string? EstadoRuta { get; set; }

        [JsonIgnore]
        public virtual Puerto? PuertoDestinoNavigation { get; set; }

        [JsonIgnore]
        public virtual Puerto? PuertoOrigenNavigation { get; set; }
    }
}
