using System;
using System.Collections.Generic;

namespace NavieraOceanoAzul.Models
{
    public partial class Ruta
    {
        public int IdRutas { get; set; }
        public string? Nombre { get; set; }
        public string? PuertoOrigen { get; set; }
        public string? PuertoDestino { get; set; }
        public string? Distancia { get; set; }
        public string? FrecuenciaRuta { get; set; }
        public string? EstadoRuta { get; set; }
        public int? Idpuerto { get; set; }

        public virtual Puerto? IdpuertoNavigation { get; set; }
    }
}
