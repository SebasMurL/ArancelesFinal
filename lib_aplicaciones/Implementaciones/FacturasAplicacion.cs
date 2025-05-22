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
    public class FacturasAplicacion : IFacturasAplicacion
    {
        private IConexion? IConexion = null;
        public FacturasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Facturas? Borrar(Facturas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Facturas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        //------------------------------------------------
        public Aranceles? Borrar(Aranceles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Aranceles!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Ordenes? Borrar(Ordenes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Ordenes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Productos? Borrar(Productos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Productos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
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
        public TiposDeProductos? Borrar(TiposDeProductos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.TiposDeProductos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public TiposDeAranceles? Borrar(TiposDeAranceles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.TiposDeAranceles!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
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
        public Facturas? Guardar(Facturas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            // if (entidad.Id != 0)
                // throw new Exception("lbYaSeGuardo"); Esto no es necesario ya que guardo varios datos
            //Operacion -----------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------------------
            this.IConexion!.Facturas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Facturas> Listar()
        {
            return this.IConexion!.Facturas!.Take(20).ToList();
        }
        //Organizar ------------------------------------------------------------------------------------------
        public List<Facturas> PorFecha(Facturas? entidad)
        {
            return this.IConexion!.Facturas!
                    .Where(x => x.Fecha.ToString()!.Contains(entidad!.Fecha.ToString()!))
                    .ToList();
        }
        //Modificar ----------------------------------------------------------------------------------------------
        public Facturas? Modificar(Facturas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            //Modificacion-----------------------------------------------------------------------
            if (entidad.PagoTotalCop!= null)
            {
                entidad!.PagoTotalCop =00000000;
            }
            var entry = this.IConexion!.Entry<Facturas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;

        }
        //----------------------------------------------------------------------------------------------
    }
}
