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
    public class PaisesAplicacion : IPaisesAplicacion
    {
        private IConexion? IConexion = null;
        public PaisesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Paises? Borrar(Paises? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            Paises[] Prueba = this.IConexion!.Paises!.ToArray<Paises>();
            List<String> IDs = Prueba.Select(Prueba => Prueba?.Id?.ToString() ?? "null").ToList(); //no se guarda el nombre interno antes, sino que se guarda el link
            if (IDs.Contains(entidad.Id.ToString())) //DIOS QUE DOLOR no me funciona el contains si lo uso directamente
            {
                this.IConexion!.Paises!.Remove(entidad);
                this.IConexion.SaveChanges();
                return entidad;
            }
            return entidad;
        }
        //------------------------------------------------
       
        //---------------------------------------------------------
        public Paises? Guardar(Paises? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            // if (entidad.Id != 0)
            // throw new Exception("lbYaSeGuardo"); Esto no es necesario ya que guardo varios datos
            //Operacion -----------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------------------
            this.IConexion!.Paises!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Paises> Listar()
        {
            return this.IConexion!.Paises!.Take(20).ToList();
        }
        //Organizar ------------------------------------------------------------------------------------------
        public List<Paises> PorNombre(Paises? entidad)
        {
            return this.IConexion!.Paises!
                    .Where(x => x.Nombre.ToString()!.Contains(entidad!.Nombre.ToString()!))
                    .ToList();
        }
        //Modificar ----------------------------------------------------------------------------------------------
        public Paises? Modificar(Paises? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            //Modificacion-----------------------------------------------------------------------
            if (entidad.Nombre != null)
            {
                entidad!.Nombre = "Modificacion";
            }
            var entry = this.IConexion!.Entry<Paises>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;

        }
        //----------------------------------------------------------------------------------------------
    }
}
