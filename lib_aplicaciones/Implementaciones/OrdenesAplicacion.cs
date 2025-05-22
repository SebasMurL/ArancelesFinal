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
    public class OrdenesAplicacion : IOrdenesAplicacion
    {
        private IConexion? IConexion = null;
        public OrdenesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        //------------------------------------------------
        public Ordenes? Borrar(Ordenes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            Ordenes[] Prueba = this.IConexion!.Ordenes!.ToArray<Ordenes>();
            List<String> IDs = Prueba.Select(Prueba => Prueba?.Id?.ToString() ?? "null").ToList(); //no se guarda el nombre interno antes, sino que se guarda el link
            if (IDs.Contains(entidad.Id.ToString())) //DIOS QUE DOLOR no me funciona el contains si lo uso directamente
            {
                this.IConexion!.Ordenes!.Remove(entidad);
                this.IConexion.SaveChanges();
                return entidad;
            }
            return entidad; ;
        }
        public Productos? Borrar(Productos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            Productos[] Prueba = this.IConexion!.Productos!.ToArray<Productos>();
            List<String> IDs = Prueba.Select(Prueba => Prueba?.Id?.ToString() ?? "null").ToList(); //no se guarda el nombre interno antes, sino que se guarda el link
            if (IDs.Contains(entidad.Id.ToString())) //DIOS QUE DOLOR no me funciona el contains si lo uso directamente
            {
                this.IConexion!.Productos!.Remove(entidad);
                this.IConexion.SaveChanges();
                return entidad;
            }
            return entidad;
        }
        public Empresas? Borrar(Empresas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            Empresas[] Prueba = this.IConexion!.Empresas!.ToArray<Empresas>();
            List<String> IDs = Prueba.Select(Prueba => Prueba?.Id?.ToString() ?? "null").ToList(); //no se guarda el nombre interno antes, sino que se guarda el link
            if (IDs.Contains(entidad.Id.ToString())) //DIOS QUE DOLOR no me funciona el contains si lo uso directamente
            {
                this.IConexion!.Empresas!.Remove(entidad);
                this.IConexion.SaveChanges();
                return entidad;
            }
            return entidad;
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
        //---------------------------------------------------------
        public Ordenes? Guardar(Ordenes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            // if (entidad.Id != 0)
            // throw new Exception("lbYaSeGuardo"); Esto no es necesario ya que guardo varios datos
            //Operacion -----------------------------------------------------------------------------------
            if (entidad.Cod!=null)
            {
                entidad!.Cod="Modificacion";
            }
            //----------------------------------------------------------------------------------------------
            this.IConexion!.Ordenes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Ordenes> Listar()
        {
            return this.IConexion!.Ordenes!.Take(20).ToList();
        }
        //Organizar ------------------------------------------------------------------------------------------
        public List<Ordenes> PorCodigo(Ordenes? entidad)
        {
            return this.IConexion!.Ordenes!
                    .Where(x => x.Cod!.Contains(entidad!.Cod!))
                    .ToList();
        }
        //Modificar ----------------------------------------------------------------------------------------------
        public Ordenes? Modificar(Ordenes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            //Modificacion-----------------------------------------------------------------------
            if (entidad.Cod!= null)
            {
                entidad!.Cod = "Modificacion";
            }
            var entry = this.IConexion!.Entry<Ordenes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;

        }
        //----------------------------------------------------------------------------------------------
    }
}
