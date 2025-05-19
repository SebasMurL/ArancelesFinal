using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
using ut_presentaciones.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class TiposDeArancelesPrueba
    {
        private readonly IConexion? iConexion;
        private List<TiposDeAranceles>? lista;
        private TiposDeAranceles? entidad;

        public TiposDeArancelesPrueba()
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
            this.lista = this.iConexion!.TiposDeAranceles!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            for (int i = 0; i < 3; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                this.entidad = ListaNucleo.Lista_TiposDeAranceles[i];
                this.iConexion!.TiposDeAranceles!.Add(this.entidad); //¿?

                 //Sera que lo saco afuera?
            }
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad = ListaNucleo.Lista_TiposDeAranceles[0]; //
            this.entidad!.Nombre = "Ab";

            var entry = this.iConexion!.Entry<TiposDeAranceles>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            for (int i = 0; i < 3; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                entidad = ListaNucleo.Lista_TiposDeAranceles[i]; //
                iConexion!.TiposDeAranceles!.Remove(entidad!);
                iConexion!.SaveChanges();
                //Sera que lo saco afuera?
            }
            return true;
        }
    }
}