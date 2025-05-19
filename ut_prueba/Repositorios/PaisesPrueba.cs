using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
using ut_presentaciones.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class PaisesPrueba
    {
        private readonly IConexion? iConexion;
        private List<Paises>? lista;
        private Paises? entidad;

        public PaisesPrueba()
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
            this.lista = this.iConexion!.Paises!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()           //Recuerda borrar los "//" de Paises,Empresas y Ordenes
        {
            for (int i = 0; i < 4; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                this.entidad = ListaNucleo.Lista_Paises[i];
                this.iConexion!.Paises!.Add(this.entidad); //¿?

                 //Sera que lo saco afuera?
            }
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad = ListaNucleo.Lista_Paises[0]; //
            this.entidad!.Moneda = "renminbi";

            var entry = this.iConexion!.Entry<Paises>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            for (int i = 0; i < 4; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                entidad = ListaNucleo.Lista_Paises[i]; //
                iConexion!.Paises!.Remove(entidad!);
                iConexion!.SaveChanges();
                //Sera que lo saco afuera?
            }
            return true;
        }
    }
}