using System;
using System.Collections.Generic;

namespace NavieraOceanoAzul.Models
{
    public partial class AsignacionPuertoBarco
    {
        public int IdAsignacionPuertoBarco { get; set; }
        public int? Idbarco { get; set; }
        public int? Idpuerto { get; set; }

        public virtual Barco? IdbarcoNavigation { get; set; }
        public virtual Puerto? IdpuertoNavigation { get; set; }
    }
}
