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
    public class TiposDeProductosAplicacion : ITiposDeProductosAplicacion
    {
        private IConexion? IConexion = null;
        public TiposDeProductosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public TiposDeProductos? Borrar(TiposDeProductos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            TiposDeProductos[] Prueba = this.IConexion!.TiposDeProductos!.ToArray<TiposDeProductos>();
            List<String> IDs = Prueba.Select(Prueba => Prueba?.Id?.ToString() ?? "null").ToList(); //no se guarda el nombre interno antes, sino que se guarda el link
            if (IDs.Contains(entidad.Id.ToString())) //DIOS QUE DOLOR no me funciona el contains si lo uso directamente
            {
                this.IConexion!.TiposDeProductos!.Remove(entidad);
                this.IConexion.SaveChanges();
                return entidad;
            }
            return entidad;
        }
        //------------------------------------------------
        //---------------------------------------------------------
        public TiposDeProductos? Guardar(TiposDeProductos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            // if (entidad.Id != 0)
            // throw new Exception("lbYaSeGuardo"); Esto no es necesario ya que guardo varios datos
            //Operacion -----------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------------------
            this.IConexion!.TiposDeProductos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<TiposDeProductos> Listar()
        {
            return this.IConexion!.TiposDeProductos!.Take(20).ToList();
        }
        //Organizar ------------------------------------------------------------------------------------------
        public List<TiposDeProductos> PorNombre(TiposDeProductos? entidad)
        {
            return this.IConexion!.TiposDeProductos!
                    .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                    .ToList();
        }
        //Modificar ----------------------------------------------------------------------------------------------
        public TiposDeProductos? Modificar(TiposDeProductos? entidad)
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
            var entry = this.IConexion!.Entry<TiposDeProductos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;

        }
        //----------------------------------------------------------------------------------------------
    }
}
