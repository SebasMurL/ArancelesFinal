using asp_Servicios.Controllers;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;
namespace asp_Servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static IConfiguration? Configuration { set; get; }
        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services) //Ojo con los errores al pegar
        {
            services.Configure<KestrelServerOptions>(x => {
                x.AllowSynchronousIO =
           true;
            });
            services.Configure<IISServerOptions>(x => {
                x.AllowSynchronousIO = true;
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
            // Repositorios
            services.AddScoped<IConexion, Conexion>();
            // Aplicaciones
            services.AddScoped<IArancelesAplicacion, ArancelesAplicacion>(); //Aqui Agregamos todas las entidades
            services.AddScoped<IEmpresasAplicacion, EmpresasAplicacion>();
            services.AddScoped<IFacturasAplicacion, FacturasAplicacion>();
            services.AddScoped<IOrdenesAplicacion, OrdenesAplicacion>();
            services.AddScoped<IPaisesAplicacion, PaisesAplicacion>();
            services.AddScoped<IProductosAplicacion, ProductosAplicacion>();
            services.AddScoped<ITiposDeArancelesAplicacion, TiposDeArancelesAplicacion>();
            services.AddScoped<ITiposDeProductosAplicacion, TiposDeProductosAplicacion>();
            // Controladores
            services.AddScoped<TokenController, TokenController>();
            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}