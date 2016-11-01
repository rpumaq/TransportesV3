using System;
using System.Collections.Generic;

namespace TransportesV3.Aplicacion.DTOs
{
    public partial class BoletoViaje
    {
        public Guid Id { get; set; }
        public Guid? FkSucursal { get; set; }
        public Guid? FkHorarioHora { get; set; }
        public string FkCliente { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc { get; set; }
        public int? AsientoNumero { get; set; }
        public string Reservado { get; set; }
        public DateTime? FechaEmision { get; set; }
        public decimal? ValorVenta { get; set; }
        public decimal? PrecioVenta { get; set; }
        public decimal? ValorIgv { get; set; }
        public bool? EsCancelado { get; set; }
        public Guid? FkSucursalPago { get; set; }
        public bool? EsMenorEdad { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual HorarioHora FkHorarioHoraNavigation { get; set; }
        public virtual Sucursal FkSucursalNavigation { get; set; }
        public virtual Sucursal FkSucursalPagoNavigation { get; set; }
    }
}
