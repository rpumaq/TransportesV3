using System;
using System.Collections.Generic;

namespace TransportesV3.Models
{
    public partial class Destino
    {
        public Destino()
        {
            RutaDestinoNavigation = new HashSet<Ruta>();
            RutaOrigenNavigation = new HashSet<Ruta>();
        }

        public Guid Id { get; set; }
        public short? Coddepartam { get; set; }
        public int? Coddistrito { get; set; }
        public int? Codprovincia { get; set; }
        public int? Codcentropob { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual ICollection<Ruta> RutaDestinoNavigation { get; set; }
        public virtual ICollection<Ruta> RutaOrigenNavigation { get; set; }
    }
}
