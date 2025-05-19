using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
using ut_presentaciones.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class TiposDeProductosPrueba
    {
        private readonly IConexion? iConexion;
        private List<TiposDeProductos>? lista;
        private TiposDeProductos? entidad;

        public TiposDeProductosPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Cargar());
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }
        public bool Cargar()
        {
            if (!ListaNucleo.Cargado)
            {
                ListaNucleo.CargarTodo();
            }
            return true;
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.TiposDeProductos.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            for (int i = 0; i < 3; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                this.entidad = ListaNucleo.Lista_TiposDeProductos[i];
                this.iConexion!.TiposDeProductos!.Add(this.entidad); //¿?

                 //Sera que lo saco afuera?
            }
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad = ListaNucleo.Lista_TiposDeProductos[0]; //
            this.entidad!.EntidadRegulatoria = "MINCIT";

            var entry = this.iConexion!.Entry<TiposDeProductos>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            for (int i = 0; i < 3; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                entidad = ListaNucleo.Lista_TiposDeProductos[i]; //
                iConexion!.TiposDeProductos!.Remove(entidad!);
                iConexion!.SaveChanges();
                //Sera que lo saco afuera?
            }
            return true;
        }
    }
}