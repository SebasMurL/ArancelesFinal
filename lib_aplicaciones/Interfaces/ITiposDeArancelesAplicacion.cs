using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface ITiposDeArancelesAplicacion
    {
        void Configurar(string StringConexion);
        List<TiposDeAranceles> PorFecha(TiposDeAranceles? entidad);
        List<TiposDeAranceles> Listar();
        TiposDeAranceles? Guardar(TiposDeAranceles? entidad);
        TiposDeAranceles? Modificar(TiposDeAranceles? entidad);
        TiposDeAranceles? Borrar(TiposDeAranceles? entidad);
        //---------------------------------------//

    }
}
