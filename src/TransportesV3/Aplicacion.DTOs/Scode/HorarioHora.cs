using System;
using System.Collections.Generic;

namespace TransportesV3.Aplicacion.DTOs
{
    public partial class HorarioHora
    {
        public HorarioHora()
        {
            BoletoViaje = new HashSet<BoletoViaje>();
        }

        public Guid Id { get; set; }
        public Guid? FkHorario { get; set; }
        public TimeSpan? Hora { get; set; }
        public decimal? Precio { get; set; }
        public string FkUnidad { get; set; }
        public string FkConductor { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual ICollection<BoletoViaje> BoletoViaje { get; set; }
        public virtual Conductor FkConductorNavigation { get; set; }
        public virtual Horario FkHorarioNavigation { get; set; }
        public virtual Unidad FkUnidadNavigation { get; set; }
    }
}
