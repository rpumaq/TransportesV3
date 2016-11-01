using System;
using System.Collections.Generic;

namespace TransportesV3.Models
{
    public partial class Unidad
    {
        public Unidad()
        {
            HorarioHora = new HashSet<HorarioHora>();
        }

        public string Placa { get; set; }
        public string NroCertificado { get; set; }
        public Guid? FkModelo { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual ICollection<HorarioHora> HorarioHora { get; set; }
        public virtual UnidadModelo FkModeloNavigation { get; set; }
    }
}
