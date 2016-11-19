using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportesV3.Models;

namespace TransportesV3.Aplicacion
{
    public class EmpresaServiceImpl : IEmpresaService
    {
        private readonly transportesv3Context ctx;
        public EmpresaServiceImpl(transportesv3Context ctx_)
        {
            ctx = ctx_;
        }

        public DataSourceResult Empresa_Read([DataSourceRequest]DataSourceRequest request)
        {
            return ctx.Empresa.Where(x => x.Estado == true)
                .Select(x => new DTOs.Empresa
                {
                    Ruc = x.Ruc
                }).ToDataSourceResult(request);
        }
    }
}
