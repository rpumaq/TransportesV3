using System;
using System.Collections.Generic;

namespace TransportesV3.Models
{
    public partial class SucursalComprobante
    {
        public Guid IdSucursal { get; set; }
        public Guid IdComprobante { get; set; }
        public int? Serie { get; set; }
        public int? Numero { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual Comprobante IdComprobanteNavigation { get; set; }
        public virtual Sucursal IdSucursalNavigation { get; set; }
    }
}
