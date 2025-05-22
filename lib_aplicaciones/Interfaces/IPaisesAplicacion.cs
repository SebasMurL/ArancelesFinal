using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface IPaisesAplicacion
    {
        void Configurar(string StringConexion);
        List<Paises> PorNombre(Paises? entidad);
        List<Paises> Listar();
        Paises? Guardar(Paises? entidad);
        Paises? Modificar(Paises? entidad);
        Paises? Borrar(Paises? entidad);
        //---------------------------------------//

    }
}
