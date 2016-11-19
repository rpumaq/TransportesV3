using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;
using TransportesV3.Aplicacion;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportesV3.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService _EmpresaService;

        public EmpresaController(IEmpresaService EmpresaService)
        {
            _EmpresaService = EmpresaService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Empresa_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = _EmpresaService.Empresa_Read(request);
            return Json(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Empresa_Create([DataSourceRequest]DataSourceRequest request, Aplicacion.DTOs.Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                var entity = new Movie
                {
                    Title = movie.Title,
                    ReleaseDate = movie.ReleaseDate,
                    Genre = movie.Genre,
                    Price = movie.Price
                };

                db.Movies.Add(entity);
                db.SaveChanges();
                movie.ID = entity.ID;
            }

            return Json(new[] { movie }.ToDataSourceResult(request, ModelState));
        }
    }
}
