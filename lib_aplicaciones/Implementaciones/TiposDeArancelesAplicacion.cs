using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ut_presentaciones.Nucleo;

namespace lib_aplicaciones.Implementaciones
{
    public class TiposDeArancelesAplicacion : ITiposDeArancelesAplicacion
    {
        private IConexion? IConexion = null;
        public TiposDeArancelesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public TiposDeAranceles? Borrar(TiposDeAranceles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            TiposDeAranceles[] Prueba = this.IConexion!.TiposDeAranceles!.ToArray<TiposDeAranceles>();
            List<String> IDs = Prueba.Select(Prueba => Prueba?.Id?.ToString() ?? "null").ToList(); //no se guarda el nombre interno antes, sino que se guarda el link
            if (IDs.Contains(entidad.Id.ToString())) //DIOS QUE DOLOR no me funciona el contains si lo uso directamente
            {
                this.IConexion!.TiposDeAranceles!.Remove(entidad);
                this.IConexion.SaveChanges();
                return entidad;
            }
            return entidad;
        }
        //------------------------------------------------
        //---------------------------------------------------------
        public TiposDeAranceles? Guardar(TiposDeAranceles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            // if (entidad.Id != 0)
            // throw new Exception("lbYaSeGuardo"); Esto no es necesario ya que guardo varios datos
            //Operacion -----------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------------------
            this.IConexion!.TiposDeAranceles!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<TiposDeAranceles> Listar()
        {
            return this.IConexion!.TiposDeAranceles!.Take(20).ToList();
        }
        //Organizar ------------------------------------------------------------------------------------------
        public List<TiposDeAranceles> PorFecha(TiposDeAranceles? entidad)
        {
            return this.IConexion!.TiposDeAranceles!
                    .Where(x => x.FechaVigencia.ToString()!.Contains(entidad!.FechaVigencia.ToString()!))
                    .ToList();
        }
        //Modificar ----------------------------------------------------------------------------------------------
        public TiposDeAranceles? Modificar(TiposDeAranceles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            //Modificacion-----------------------------------------------------------------------
            if (entidad.Nombre!= null)
            {
                entidad!.Nombre ="Prueba";
            }
            var entry = this.IConexion!.Entry<TiposDeAranceles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;

        }
        //----------------------------------------------------------------------------------------------
    }
}
