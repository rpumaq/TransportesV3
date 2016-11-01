using System;
using System.Collections.Generic;

namespace TransportesV3.Aplicacion.DTOs
{
    public partial class Conductor
    {
        public Conductor()
        {
            HorarioHora = new HashSet<HorarioHora>();
        }

        public string Licencia { get; set; }
        public Guid? FkPersonal { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual ICollection<HorarioHora> HorarioHora { get; set; }
        public virtual Personal FkPersonalNavigation { get; set; }
    }
}
