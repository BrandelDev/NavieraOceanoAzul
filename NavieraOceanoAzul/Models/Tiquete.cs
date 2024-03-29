﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NavieraOceanoAzul.Models
{
    public partial class Tiquete
    {
        [JsonPropertyName("idtiquete")]
        public int Idtiquete { get; set; }



        [JsonPropertyName("idcliente")]
        public int? Idcliente { get; set; }

        [JsonPropertyName("fechaEmision")]
        public DateTime? FechaEmision { get; set; }

        [JsonPropertyName("fechaSalida")]
        public DateTime? FechaSalida { get; set; }

        [JsonPropertyName("precio")]
        public string? Precio { get; set; }

        [JsonPropertyName("idbarco")]
        public int? Idbarco { get; set; }

        [JsonPropertyName("fechaLlegada")]
        public DateTime? FechaLlegada { get; set; }
        [JsonPropertyName("idRuta")]
        public int? Idruta { get; set; }


        [JsonIgnore]
        public virtual Barco? IdbarcoNavigation { get; set; }

        [JsonIgnore]
        public virtual Cliente? IdclienteNavigation { get; set; }

        [JsonIgnore]
        public virtual Ruta? IdrutaNavigation { get; set; }
    }
}
