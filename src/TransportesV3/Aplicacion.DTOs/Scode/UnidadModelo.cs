using System;
using System.Collections.Generic;

namespace TransportesV3.Aplicacion.DTOs
{
    public partial class UnidadModelo
    {
        public UnidadModelo()
        {
            ModeloDetalle = new HashSet<ModeloDetalle>();
            Unidad = new HashSet<Unidad>();
        }

        public Guid Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Anio { get; set; }
        public int Filas { get; set; }
        public int Columnas { get; set; }
        public int NumeroAsientos { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual ICollection<ModeloDetalle> ModeloDetalle { get; set; }
        public virtual ICollection<Unidad> Unidad { get; set; }
    }
}
