using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface IOrdenesAplicacion
    {
        void Configurar(string StringConexion);
        List<Ordenes> PorCodigo(Ordenes? entidad);
        List<Ordenes> Listar();
        Ordenes? Guardar(Ordenes? entidad);
        Ordenes? Modificar(Ordenes? entidad);
        //---------------------------------------//
        Paises? Borrar(Paises? entidad);//
        Ordenes? Borrar(Ordenes? entidad);//
        Empresas? Borrar(Empresas? entidad);//
        Productos? Borrar(Productos? entidad);//
        TiposDeProductos? Borrar(TiposDeProductos? entidad);//

    }
}
