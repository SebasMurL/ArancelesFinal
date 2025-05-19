using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;

namespace ut_presentaciones.Nucleo
{
    public class EntidadesNucleo
    {
        public static Paises? Paises()
        {
            var entidad = new Paises();
            entidad.Id = 1;
            entidad.Nombre = "China";
            entidad.Moneda = "Yuan Chino";
            return entidad;
        }
        public static TiposDeAranceles? TiposDeAranceles()
        {
            var entidad = new TiposDeAranceles();
            entidad.Id = 1;
            entidad.Nombre = "Ad Valorem";
            entidad.FechaVigencia = DateTime.Now;
            return entidad;
        }
        public static TiposDeProductos? TiposDeProductos()
        {
            var entidad = new TiposDeProductos();
            entidad.Id = 1;
            entidad.Nombre = "Ropa";
            entidad.EntidadRegulatoria = "SIC";
            return entidad;
        }
        public static Aranceles? Aranceles() //Falta relaciones Aqui
        {
            var entidad = new Aranceles();
            entidad.Id = 1;
            entidad.PorcentajeDelArancel = 10;
            return entidad;
        }
        public static Empresas? Empresas()
        {
            var entidad = new Empresas();
            entidad.Id = 1;
            entidad.Nombre = "Nike";
            return entidad;
        }
        public static Facturas? Facturas()
        {
            var entidad = new Facturas();
            entidad.Id = 1;
            entidad.Fecha=DateTime.Now;
            entidad.PagoTotalCop=432000000m;
            return entidad;
        }
        public static Ordenes? Ordenes()
        {
            var entidad = new Ordenes();
            entidad.Id = 1;
            entidad.Cod = "IGI001";
            entidad.CantidadUnidades = 560;
            entidad.Fecha= DateTime.Now;
            return entidad;
        }
        public static Productos? Productos()
        {
            var entidad = new Productos();
            entidad.Id =1 ;
            entidad.Nombre = "Sudadera";
            entidad.PrecioUnitario = 70000.00m;
            return entidad;
        }
}
}
