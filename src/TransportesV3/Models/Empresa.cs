using System;
using System.Collections.Generic;

namespace TransportesV3.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Sucursal = new HashSet<Sucursal>();
        }

        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string Logo { get; set; }
        public string Icono { get; set; }
        public string DireccionPrincipal { get; set; }
        public string Telefono { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Email { get; set; }
        public string UrlWeb { get; set; }
        public string UrlFacebook { get; set; }
        public string UrlYoutube { get; set; }
        public string UrlTwitter { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual ICollection<Sucursal> Sucursal { get; set; }
    }
}
