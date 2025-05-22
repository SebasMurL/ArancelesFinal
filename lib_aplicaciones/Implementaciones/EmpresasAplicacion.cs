using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Implementaciones
{
    public class EmpresasAplicacion : IEmpresasAplicacion
    {
        private IConexion? IConexion = null;
        public EmpresasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Empresas? Borrar(Empresas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Empresas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        //------------------------------------------------
        public Paises? Borrar(Paises? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Paises!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        //---------------------------------------------------------
        public Empresas? Guardar(Empresas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            // if (entidad.Id != 0)
                // throw new Exception("lbYaSeGuardo"); Esto no es necesario ya que guardo varios datos
            //Operacion -----------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------------------
            this.IConexion!.Empresas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Empresas> Listar()
        {
            return this.IConexion!.Empresas!.Take(20).ToList();
        }
        //Organizar ------------------------------------------------------------------------------------------
        public List<Empresas> PorNombre(Empresas? entidad)
        {
            return this.IConexion!.Empresas!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .ToList();
        }
        //Modificar ----------------------------------------------------------------------------------------------
        public Empresas? Modificar(Empresas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            //Modificacion-----------------------------------------------------------------------
            if (entidad.Nombre!= null)
            {
                entidad!.Nombre ="Modificacion";
            }
            var entry = this.IConexion!.Entry<Empresas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;

        }
        //----------------------------------------------------------------------------------------------
    }
}
