using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NavieraOceanoAzul.Models
{
    public partial class Habitacion
    {
        public int Idhabitaciones { get; set; }

        [JsonPropertyName("numeroHabitacion")]
        public string? NumeroHabitacion { get; set; }

        [JsonPropertyName("capacidad")]
        public string? Capacidad { get; set; }

        [JsonPropertyName("ubicacionHabitacion")]
        public string? UbicacionHabitacion { get; set; }

        [JsonIgnore]
        public int? Idbarco { get; set; }

        [JsonIgnore]
        public virtual Barco? IdbarcoNavigation { get; set; }
    }
}