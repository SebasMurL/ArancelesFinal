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
    public class ArancelesAplicacion : IArancelesAplicacion
    {
        private IConexion? IConexion = null;
        public ArancelesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Aranceles? Borrar(Aranceles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            Aranceles[] Prueba = this.IConexion!.Aranceles!.ToArray<Aranceles>();
            List<String> IDs = Prueba.Select(Prueba => Prueba?.Id?.ToString() ?? "null").ToList(); //no se guarda el nombre interno antes, sino que se guarda el link
            if (IDs.Contains(entidad.Id.ToString())) //DIOS QUE DOLOR no me funciona el contains si lo uso directamente
            {
                this.IConexion!.Aranceles!.Remove(entidad);
                this.IConexion.SaveChanges();
                return entidad;
            }
            return entidad;
        }
        //------------------------------------------------
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
        //---------------------------------------------------------
        public Aranceles? Guardar(Aranceles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            // if (entidad.Id != 0)
                // throw new Exception("lbYaSeGuardo"); Esto no es necesario ya que guardo varios datos
            //Operacion -----------------------------------------------------------------------------------
            if (entidad.Id_TipoDeArancel != null && entidad._Orden != null)
            {
                entidad!.PorcentajeDelArancel = ut_presentaciones.Nucleo.OperacionesNucleo.CalcularPorcentajeDeArancel(entidad.Id_TipoDeArancel, entidad._Orden);
            }
            //----------------------------------------------------------------------------------------------
            this.IConexion!.Aranceles!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Aranceles> Listar()
        {
            return this.IConexion!.Aranceles!.Take(20).ToList();
        }
        //Organizar ------------------------------------------------------------------------------------------
        public List<Aranceles> PorPorcentajeDelArancel(Aranceles? entidad)
        {
            return this.IConexion!.Aranceles!
            .Where(x => x.PorcentajeDelArancel.ToString()!.Contains(entidad!.PorcentajeDelArancel.ToString()!))
            .ToList();
        }
        //Modificar ----------------------------------------------------------------------------------------------
        public Aranceles? Modificar(Aranceles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            //Modificacion-----------------------------------------------------------------------
            if (entidad.Id_TipoDeArancel != null && entidad._Orden != null)
            {
                entidad!.PorcentajeDelArancel = (ut_presentaciones.Nucleo.OperacionesNucleo.CalcularPorcentajeDeArancel(entidad.Id_TipoDeArancel, entidad._Orden)+(1/10));
            }
            var entry = this.IConexion!.Entry<Aranceles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;

        }
        //----------------------------------------------------------------------------------------------
    }
}
