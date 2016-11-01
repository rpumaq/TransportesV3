using System;
using System.Collections.Generic;

namespace TransportesV3.Models
{
    public partial class ModeloDetalle
    {
        public Guid Id { get; set; }
        public Guid? FkModelo { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
        public int NumeroAsiento { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual UnidadModelo FkModeloNavigation { get; set; }
    }
}
