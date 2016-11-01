using System;
using System.Collections.Generic;

namespace TransportesV3.Aplicacion.DTOs
{
    public partial class Usuario
    {
        public string Usuario1 { get; set; }
        public Guid? FkPersonal { get; set; }

        public virtual Personal FkPersonalNavigation { get; set; }
    }
}
