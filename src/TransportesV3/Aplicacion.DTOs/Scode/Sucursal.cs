using System;
using System.Collections.Generic;

namespace TransportesV3.Aplicacion.DTOs
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            BoletoViajeFkSucursalNavigation = new HashSet<BoletoViaje>();
            BoletoViajeFkSucursalPagoNavigation = new HashSet<BoletoViaje>();
            SucursalComprobante = new HashSet<SucursalComprobante>();
        }

        public Guid Id { get; set; }
        public string FkEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string ColorVenta { get; set; }
        public string ColorReserva { get; set; }
        public string Descripcion { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public int? Coddistrito { get; set; }
        public int? Codprovincia { get; set; }
        public short? Coddepartam { get; set; }
        public string Direccion { get; set; }
        public string HorarioLv { get; set; }
        public string HorarioSab { get; set; }
        public string HorarioDom { get; set; }
        public string Telefono { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual ICollection<BoletoViaje> BoletoViajeFkSucursalNavigation { get; set; }
        public virtual ICollection<BoletoViaje> BoletoViajeFkSucursalPagoNavigation { get; set; }
        public virtual ICollection<SucursalComprobante> SucursalComprobante { get; set; }
        public virtual Empresa FkEmpresaNavigation { get; set; }
    }
}
