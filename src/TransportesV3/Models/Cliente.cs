using System;
using System.Collections.Generic;

namespace TransportesV3.Models
{
    public partial class Cliente
    {
        public Guid Id { get; set; }
        public Guid? FkTipoDocumento { get; set; }
        public string Dni { get; set; }
        public string OtroDocumento { get; set; }
        public int? NroViajes { get; set; }
        public int? NroFallas { get; set; }

        public virtual TipoDocumento FkTipoDocumentoNavigation { get; set; }
    }
}
