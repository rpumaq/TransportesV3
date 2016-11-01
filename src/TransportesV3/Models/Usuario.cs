using System;
using System.Collections.Generic;

namespace TransportesV3.Models
{
    public partial class Usuario
    {
        public string Usuario1 { get; set; }
        public Guid? FkPersonal { get; set; }

        public virtual Personal FkPersonalNavigation { get; set; }
    }
}
