using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using lib_dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IArancelesPresentacion
    {
        Task<List<Aranceles>> Listar();
        Task<List<Aranceles>> PorPorcentajeDelArancel(Aranceles? entidad);
        Task<Aranceles?> Guardar(Aranceles? entidad);
        Task<Aranceles?> Modificar(Aranceles? entidad);
        Task<Aranceles?> Borrar(Aranceles? entidad);
    }
}