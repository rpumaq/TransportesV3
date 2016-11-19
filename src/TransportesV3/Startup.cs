using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TransportesV3.Models;
using TransportesV3.Aplicacion;

namespace TransportesV3
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer().AddDbContext<transportesv3Context>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add framework services.
            services.AddMvc();

            // Add Kendo UI services to the services container
            services.AddKendo();

            // Add app services
            services.AddScoped<IBoletoViajeService, BoletoViajeServiceImpl>();
            services.AddScoped<IClienteService, ClienteServiceImpl>();
            services.AddScoped<IComprobanteService, ComprobanteServiceImpl>();
            services.AddScoped<IConductorService, ConductorServiceImpl>();
            services.AddScoped<IDatosReniecService, DatosReniecServiceImpl>();
            services.AddScoped<IDestinoService, DestinoServiceImpl>();
            services.AddScoped<IEmpresaService, EmpresaServiceImpl>();
            services.AddScoped<IHorarioService, HorarioServiceImpl>();
            services.AddScoped<IHorarioHoraService, HorarioHoraServiceImpl>();
            services.AddScoped<IModeloDetalleService, ModeloDetalleServiceImpl>();
            services.AddScoped<IPersonalService, PersonalServiceImpl>();
            services.AddScoped<IRutaService, RutaServiceImpl>();
            services.AddScoped<IRutaDetalleService, RutaDetalleServiceImpl>();
            services.AddScoped<ISucursalService, SucursalServiceImpl>();
            services.AddScoped<ISucursalComprobanteService, SucursalComprobanteServiceImpl>();
            services.AddScoped<ITipoDocumentoService, TipoDocumentoServiceImpl>();
            services.AddScoped<IUnidadService, UnidadServiceImpl>();
            services.AddScoped<IUnidadModeloService, UnidadModeloServiceImpl>();
            services.AddScoped<IUsuarioService, UsuarioServiceImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Configure Kendo UI

            app.UseKendo(env);
        }
    }
}
