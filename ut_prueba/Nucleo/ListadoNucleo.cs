using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;
using ut_presentaciones.Nucleo;
namespace ut_presentaciones.Nucleo
{
    public class ListaNucleo
    {
        public static List<Paises> Lista_Paises = new List<Paises>();
        public static List<Empresas> Lista_Empresas = new List<Empresas>();
        public static List<TiposDeProductos> Lista_TiposDeProductos = new List<TiposDeProductos>();
        public static List<Productos> Lista_Productos = new List<Productos>();
        public static List<Ordenes> Lista_Ordenes = new List<Ordenes>();
        public static List<TiposDeAranceles> Lista_TiposDeAranceles = new List<TiposDeAranceles>();
        public static List<Aranceles> Lista_Aranceles = new List<Aranceles>();
        public static List<Facturas> Lista_Facturas = new List<Facturas>();
        public static bool Cargado = false;
        public static void CargarTodo()
        {
            //Tabla 2 Lista
            /**/
            Lista_Paises.Add(new Paises { Id = 1, Nombre = "China", Moneda = "Yuan Chino" });
            Lista_Paises.Add(new Paises { Id = 2, Nombre = "Colombia", Moneda = "PesoColombiano" });
            Lista_Paises.Add(new Paises { Id = 3, Nombre = "Mexico", Moneda = "PesoMexicano" });
            Lista_Paises.Add(new Paises { Id = 4, Nombre = "Estados Unidos", Moneda = "DollarEstadounidense" });
            /**/
        

            //Tabla 1 Lista
            /**/
            Lista_Empresas.Add(new Empresas { Id = 1, Id_Pais = 4, Nombre = "Nike", _Pais = Lista_Paises.FirstOrDefault(x => x.Id == 4) });
            Lista_Empresas.Add(new Empresas { Id = 2, Id_Pais = 1, Nombre = "Huawei", _Pais = Lista_Paises.FirstOrDefault(x => x.Id == 1) });
            Lista_Empresas.Add(new Empresas { Id = 3, Id_Pais = 2, Nombre = "Alpina", _Pais = Lista_Paises.FirstOrDefault(x => x.Id == 2) });
            Lista_Empresas.Add(new Empresas { Id = 4, Id_Pais = 2, Nombre = "ArturoCalle", _Pais = Lista_Paises.FirstOrDefault(x => x.Id == 2) });
            Lista_Empresas.Add(new Empresas { Id = 5, Id_Pais = 2, Nombre = "Colombina", _Pais = Lista_Paises.FirstOrDefault(x => x.Id == 2) });
            Lista_Empresas.Add(new Empresas { Id = 6, Id_Pais = 2, Nombre = "JuanValdez", _Pais = Lista_Paises.FirstOrDefault(x => x.Id == 2) });
            /**/
 
        


            //Tabla 4 Lista
            /**/
            Lista_TiposDeProductos.Add(new TiposDeProductos { Id = 3, Nombre = "Ropa",EntidadRegulatoria="SIC" });
            Lista_TiposDeProductos.Add(new TiposDeProductos { Id = 2, Nombre = "Celulares", EntidadRegulatoria="SIC" });
            Lista_TiposDeProductos.Add(new TiposDeProductos { Id = 1, Nombre = "Alimentos",EntidadRegulatoria="Invima" });
            /**/
        

            //Tabla 3 Lista
            /**/
            Lista_Productos.Add(new Productos { Id = 1, Nombre = "Sudadera", Id_Empresa = 1, Id_TipoProducto = 1, _Empresa = Lista_Empresas.FirstOrDefault(x => x.Id == 1), _TipoProducto = Lista_TiposDeProductos.FirstOrDefault(x => x.Id == 1), PrecioUnitario = 65000.00m});
            Lista_Productos.Add(new Productos { Id = 2, Nombre = "Nova13X", Id_Empresa = 2, Id_TipoProducto = 2, _Empresa = Lista_Empresas.FirstOrDefault(x => x.Id == 2), _TipoProducto = Lista_TiposDeProductos.FirstOrDefault(x => x.Id == 2), PrecioUnitario = 150000.00m });
            Lista_Productos.Add(new Productos { Id = 3, Nombre = "Yogurt Alpina", Id_Empresa = 3, Id_TipoProducto = 3, _Empresa = Lista_Empresas.FirstOrDefault(x => x.Id == 3), _TipoProducto = Lista_TiposDeProductos.FirstOrDefault(x => x.Id == 3), PrecioUnitario = 2500.00m });
            Lista_Productos.Add(new Productos { Id = 4, Nombre = "Camisa para hombre ArturoCalle", Id_Empresa = 4, Id_TipoProducto = 1, _Empresa = Lista_Empresas.FirstOrDefault(x => x.Id == 4), _TipoProducto = Lista_TiposDeProductos.FirstOrDefault(x => x.Id == 1), PrecioUnitario = 45000.00m });
            Lista_Productos.Add(new Productos { Id = 5, Nombre = "BonBonBum", Id_Empresa = 5, Id_TipoProducto = 3, _Empresa = Lista_Empresas.FirstOrDefault(x => x.Id == 5), _TipoProducto = Lista_TiposDeProductos.FirstOrDefault(x => x.Id == 3), PrecioUnitario = 500.00m });
            Lista_Productos.Add(new Productos { Id = 6, Nombre = "Cafe Juan Valdez", Id_Empresa = 6, Id_TipoProducto = 3, _Empresa = Lista_Empresas.FirstOrDefault(x => x.Id == 6), _TipoProducto = Lista_TiposDeProductos.FirstOrDefault(x => x.Id == 3), PrecioUnitario = 32000.00m });
            /**/
        


            //Tabla 5 Lista
            /**/
            Lista_Ordenes.Add(new Ordenes { Id = 1, Cod = "IGI001", CantidadUnidades = 560, Id_PaisDestino = 2, Id_PaisOrigen = 1, Id_Producto = 1, Fecha = new DateTime(2025, 01, 26), _PaisDestino = Lista_Paises.FirstOrDefault(x => x.Id == 2), _PaisOrigen = Lista_Paises.FirstOrDefault(x => x.Id == 1), _Producto = Lista_Productos.FirstOrDefault(x => x.Id == 1) });
            Lista_Ordenes.Add(new Ordenes { Id = 2, Cod = "IGI002", CantidadUnidades = 320, Id_PaisDestino = 2, Id_PaisOrigen = 1, Id_Producto = 2, Fecha = new DateTime(2025, 01, 28), _PaisDestino = Lista_Paises.FirstOrDefault(x => x.Id == 2), _PaisOrigen = Lista_Paises.FirstOrDefault(x => x.Id == 1), _Producto = Lista_Productos.FirstOrDefault(x => x.Id == 2) });
            Lista_Ordenes.Add(new Ordenes { Id = 3, Cod = "IGE001", CantidadUnidades = 1200, Id_PaisDestino = 4, Id_PaisOrigen = 2, Id_Producto = 3, Fecha = new DateTime(2025, 01, 28), _PaisDestino = Lista_Paises.FirstOrDefault(x => x.Id == 4), _PaisOrigen = Lista_Paises.FirstOrDefault(x => x.Id == 2), _Producto = Lista_Productos.FirstOrDefault(x => x.Id == 3) });
            Lista_Ordenes.Add(new Ordenes { Id = 4, Cod = "IGI003", CantidadUnidades = 430, Id_PaisDestino = 3, Id_PaisOrigen = 1, Id_Producto = 4, Fecha = new DateTime(2025, 01, 29), _PaisDestino = Lista_Paises.FirstOrDefault(x => x.Id == 3), _PaisOrigen = Lista_Paises.FirstOrDefault(x => x.Id == 1), _Producto = Lista_Productos.FirstOrDefault(x => x.Id == 4) });
            Lista_Ordenes.Add(new Ordenes { Id = 5, Cod = "IGE002", CantidadUnidades = 7200, Id_PaisDestino = 3, Id_PaisOrigen = 2, Id_Producto = 5, Fecha = new DateTime(2025, 01, 30), _PaisDestino = Lista_Paises.FirstOrDefault(x => x.Id == 3), _PaisOrigen = Lista_Paises.FirstOrDefault(x => x.Id == 2), _Producto = Lista_Productos.FirstOrDefault(x => x.Id == 5) });
            Lista_Ordenes.Add(new Ordenes { Id = 6, Cod = "IGE003", CantidadUnidades = 1000, Id_PaisDestino = 1, Id_PaisOrigen = 2, Id_Producto = 6, Fecha = new DateTime(2025, 01, 30), _PaisDestino = Lista_Paises.FirstOrDefault(x => x.Id == 1), _PaisOrigen = Lista_Paises.FirstOrDefault(x => x.Id == 2), _Producto = Lista_Productos.FirstOrDefault(x => x.Id == 6) });
            /**/
        


            //Tabla 6 Lista
            /**/
            Lista_TiposDeAranceles.Add(new TiposDeAranceles { Id = 1, Nombre = "Ad Valorem", FechaVigencia = new DateTime(2025, 01, 1) });
            Lista_TiposDeAranceles.Add(new TiposDeAranceles { Id = 2, Nombre = "Impuesto Exportacion", FechaVigencia = new DateTime(2025, 01, 1) });
            Lista_TiposDeAranceles.Add(new TiposDeAranceles { Id = 3, Nombre = "Arancel Compuesto", FechaVigencia = new DateTime(2025, 01, 1) });
            /**/
        


            //Tabla 7 Lista
            /**/
            Lista_Aranceles.Add(new Aranceles { Id = 1, PorcentajeDelArancel = OperacionesNucleo.CalcularPorcentajeDeArancel(1, Lista_Ordenes[0]), Id_Orden = 1, Id_TipoDeArancel = 1,_Orden=Lista_Ordenes.FirstOrDefault(x => x.Id == 1),_TipoArancel= Lista_TiposDeAranceles.FirstOrDefault(x => x.Id == 1) });
            Lista_Aranceles.Add(new Aranceles { Id = 2, PorcentajeDelArancel = OperacionesNucleo.CalcularPorcentajeDeArancel(1, Lista_Ordenes[1]), Id_Orden = 2, Id_TipoDeArancel = 1, _Orden = Lista_Ordenes.FirstOrDefault(x => x.Id == 2), _TipoArancel = Lista_TiposDeAranceles.FirstOrDefault(x => x.Id == 1) });
            Lista_Aranceles.Add(new Aranceles { Id = 3, PorcentajeDelArancel = OperacionesNucleo.CalcularPorcentajeDeArancel(2, Lista_Ordenes[2]), Id_Orden = 3, Id_TipoDeArancel = 2, _Orden = Lista_Ordenes.FirstOrDefault(x => x.Id == 3), _TipoArancel = Lista_TiposDeAranceles.FirstOrDefault(x => x.Id == 2) });
            Lista_Aranceles.Add(new Aranceles { Id = 4, PorcentajeDelArancel = OperacionesNucleo.CalcularPorcentajeDeArancel(3, Lista_Ordenes[3]), Id_Orden = 4, Id_TipoDeArancel = 3, _Orden = Lista_Ordenes.FirstOrDefault(x => x.Id == 4), _TipoArancel = Lista_TiposDeAranceles.FirstOrDefault(x => x.Id == 3) });
            Lista_Aranceles.Add(new Aranceles { Id = 5, PorcentajeDelArancel = OperacionesNucleo.CalcularPorcentajeDeArancel(2, Lista_Ordenes[4]), Id_Orden = 5, Id_TipoDeArancel = 2, _Orden = Lista_Ordenes.FirstOrDefault(x => x.Id == 5), _TipoArancel = Lista_TiposDeAranceles.FirstOrDefault(x => x.Id == 2) });
            Lista_Aranceles.Add(new Aranceles { Id = 6, PorcentajeDelArancel = OperacionesNucleo.CalcularPorcentajeDeArancel(2, Lista_Ordenes[5]), Id_Orden = 6, Id_TipoDeArancel = 2, _Orden = Lista_Ordenes.FirstOrDefault(x => x.Id == 6), _TipoArancel = Lista_TiposDeAranceles.FirstOrDefault(x => x.Id == 2) });
            /**/
        


            //Tabla 8 Lista
            /**/
            Lista_Facturas.Add(new Facturas { Id = 1, PagoTotalCop = OperacionesNucleo.CalcularPagoTotal(Lista_Aranceles[0]), Fecha = (new DateTime(2025, 02, 20)), Id_Arancel = 1,_Arancel=Lista_Aranceles.FirstOrDefault(x => x.Id == 1) });
            Lista_Facturas.Add(new Facturas { Id = 2, PagoTotalCop = OperacionesNucleo.CalcularPagoTotal(Lista_Aranceles[1]), Fecha = new DateTime(2025, 02, 20), Id_Arancel = 2, _Arancel = Lista_Aranceles.FirstOrDefault(x => x.Id == 2) });
            Lista_Facturas.Add(new Facturas { Id = 3, PagoTotalCop = OperacionesNucleo.CalcularPagoTotal(Lista_Aranceles[2]), Fecha = new DateTime(2025, 02, 22), Id_Arancel = 3, _Arancel = Lista_Aranceles.FirstOrDefault(x => x.Id == 3) });
            Lista_Facturas.Add(new Facturas { Id = 4, PagoTotalCop = OperacionesNucleo.CalcularPagoTotal(Lista_Aranceles[3]), Fecha = new DateTime(2025, 02, 24), Id_Arancel = 4, _Arancel = Lista_Aranceles.FirstOrDefault(x => x.Id == 4) });
            Lista_Facturas.Add(new Facturas { Id = 5, PagoTotalCop = OperacionesNucleo.CalcularPagoTotal(Lista_Aranceles[4]), Fecha = new DateTime(2025, 02, 25), Id_Arancel = 5, _Arancel = Lista_Aranceles.FirstOrDefault(x => x.Id == 5) });
            Lista_Facturas.Add(new Facturas { Id = 6, PagoTotalCop = OperacionesNucleo.CalcularPagoTotal(Lista_Aranceles[5]), Fecha = new DateTime(2025, 02, 26), Id_Arancel = 6, _Arancel = Lista_Aranceles.FirstOrDefault(x => x.Id == 6) });

            Cargado = true;
        }
        public static Empresas ListaEmpresas(int i) { return Lista_Empresas[i]; }
        public static Paises ListaPaises(int i) { return Lista_Paises[i]; }
        public static TiposDeProductos ListaTiposDeProductos(int i) { return Lista_TiposDeProductos[i]; }
        public static Productos ListaProductos(int i) { return Lista_Productos[i]; }
        public static Ordenes ListaOrdenes(int i) { return Lista_Ordenes[i]; }
        public static TiposDeAranceles ListaTiposDeAranceles(int i) { return Lista_TiposDeAranceles[i]; }
        public static Aranceles ListaAranceles(int i) { return Lista_Aranceles[i]; }
        public static Facturas ListaFacturas(int i) { return Lista_Facturas[i]; }
    }
}
