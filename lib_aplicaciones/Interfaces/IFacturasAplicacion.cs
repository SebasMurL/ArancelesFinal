using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface IFacturasAplicacion
    {
        void Configurar(string StringConexion);
        List<Facturas> PorFecha(Facturas? entidad);
        List<Facturas> Listar();
        Facturas? Guardar(Facturas? entidad);
        Facturas? Modificar(Facturas? entidad);
        Facturas? Borrar(Facturas? entidad);
        //---------------------------------------//
        Paises? Borrar(Paises? entidad);//
        Aranceles? Borrar(Aranceles? entidad);//
        Ordenes? Borrar(Ordenes? entidad);//
        Empresas? Borrar(Empresas? entidad);//
        Productos? Borrar(Productos? entidad);//
        TiposDeProductos? Borrar(TiposDeProductos? entidad);//
        TiposDeAranceles? Borrar(TiposDeAranceles? entidad);

    }
}
