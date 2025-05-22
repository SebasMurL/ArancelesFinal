using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface IEmpresasAplicacion
    {
        void Configurar(string StringConexion);
        List<Empresas> PorNombre(Empresas? entidad);
        List<Empresas> Listar();
        Empresas? Guardar(Empresas? entidad);
        Empresas? Modificar(Empresas? entidad);
        Empresas? Borrar(Empresas? entidad);
        //---------------------------------------//
        Paises? Borrar(Paises? entidad);//


    }
}
