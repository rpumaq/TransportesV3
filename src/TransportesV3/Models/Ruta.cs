using System;
using System.Collections.Generic;

namespace TransportesV3.Models
{
    public partial class Ruta
    {
        public Ruta()
        {
            Horario = new HashSet<Horario>();
            RutaDetalle = new HashSet<RutaDetalle>();
        }

        public Guid Id { get; set; }
        public Guid? Origen { get; set; }
        public Guid? Destino { get; set; }
        public decimal? PrecioDefecto { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual ICollection<Horario> Horario { get; set; }
        public virtual ICollection<RutaDetalle> RutaDetalle { get; set; }
        public virtual Destino DestinoNavigation { get; set; }
        public virtual Destino OrigenNavigation { get; set; }
    }
}
