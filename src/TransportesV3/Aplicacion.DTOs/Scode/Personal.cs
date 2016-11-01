using System;
using System.Collections.Generic;

namespace TransportesV3.Aplicacion.DTOs
{
    public partial class Personal
    {
        public Personal()
        {
            Conductor = new HashSet<Conductor>();
            Usuario = new HashSet<Usuario>();
        }

        public Guid Id { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public short? Coddepartam { get; set; }
        public int? Coddistrito { get; set; }
        public int? Codprovincia { get; set; }
        public string Direccion { get; set; }
        public bool Sexo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string CelularPersonal { get; set; }
        public string CelularEmpresa { get; set; }
        public string Email { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual ICollection<Conductor> Conductor { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
