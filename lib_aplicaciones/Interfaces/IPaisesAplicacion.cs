using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface IArancelesAplicacion
    {
        void Configurar(string StringConexion);
        List<Aranceles> PorPorcentajeDelArancel(Aranceles? entidad);
        List<Aranceles> Listar();
        Aranceles? Guardar(Aranceles? entidad);
        Aranceles? Modificar(Aranceles? entidad);
        Aranceles? Borrar(Aranceles? entidad);
        //---------------------------------------//
        Paises? Borrar(Paises? entidad);//
        Ordenes? Borrar(Ordenes? entidad);//
        Empresas? Borrar(Empresas? entidad);//
        Productos? Borrar(Productos? entidad);//
        TiposDeProductos? Borrar(TiposDeProductos? entidad);//
        TiposDeAranceles? Borrar(TiposDeAranceles? entidad);

    }
}
