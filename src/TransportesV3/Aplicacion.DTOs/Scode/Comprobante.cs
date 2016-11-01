using System;
using System.Collections.Generic;

namespace TransportesV3.Aplicacion.DTOs
{
    public partial class Comprobante
    {
        public Comprobante()
        {
            SucursalComprobante = new HashSet<SucursalComprobante>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual ICollection<SucursalComprobante> SucursalComprobante { get; set; }
    }
}
