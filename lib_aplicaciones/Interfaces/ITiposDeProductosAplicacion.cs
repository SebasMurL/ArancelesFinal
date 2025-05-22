using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface ITiposDeProductosAplicacion
    {
        void Configurar(string StringConexion);
        List<TiposDeProductos> PorNombre(TiposDeProductos? entidad);
        List<TiposDeProductos> Listar();
        TiposDeProductos? Guardar(TiposDeProductos? entidad);
        TiposDeProductos? Modificar(TiposDeProductos? entidad);
        TiposDeProductos? Borrar(TiposDeProductos? entidad);
        //---------------------------------------//

    }
}
