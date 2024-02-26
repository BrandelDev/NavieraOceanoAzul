using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NavieraOceanoAzul.Models
{
    public partial class AsignacionPuertoBarco
    {
        public int IdAsignacionPuertoBarco { get; set; }

        [JsonPropertyName("idbarco")]
        public int? Idbarco { get; set; }

        [JsonPropertyName("idpuerto")]
        public int? Idpuerto { get; set; }

        [JsonIgnore]
        public virtual Barco? IdbarcoNavigation { get; set; }

        [JsonIgnore]
        public virtual Puerto? IdpuertoNavigation { get; set; }
    }
}