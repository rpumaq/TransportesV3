using System;
using System.Collections.Generic;

namespace TransportesV3.Aplicacion.DTOs
{
    public partial class RutaDetalle
    {
        public Guid Id { get; set; }
        public Guid? FkRuta { get; set; }
        public Guid? Origen { get; set; }
        public Guid? Destino { get; set; }
        public decimal? Precio { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual Ruta FkRutaNavigation { get; set; }
    }
}
