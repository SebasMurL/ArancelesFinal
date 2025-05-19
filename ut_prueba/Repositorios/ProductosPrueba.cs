using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
using ut_presentaciones.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ProductosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Productos>? lista;
        private Productos? entidad;
        private Empresas? entidad1;
        private Paises? entidad4;
        private TiposDeProductos? entidad7;

        public ProductosPrueba()
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
            this.lista = this.iConexion!.Productos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            for (int i = 0; i < 6; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                this.entidad = ListaNucleo.Lista_Productos[i];
                this.iConexion!.Productos!.Add(this.entidad); //¿?

                 //Sera que lo saco afuera?
            }
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad = ListaNucleo.Lista_Productos[0]; //
            this.entidad!.PrecioUnitario = 35000.00m;

            var entry = this.iConexion!.Entry<Productos>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {


            for (int i = 0; i < 6; i++) //
            {
                this.entidad1 = ListaNucleo.Lista_Empresas[i]; //
                this.iConexion!.Empresas!.Remove(this.entidad1!);
                this.iConexion!.SaveChanges();
                //Sera que lo saco afuera?
            }
            for (int i = 0; i < 4; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                if(i==2)
                {
                    i = 3;
                }
                entidad4 = ListaNucleo.Lista_Paises[i]; //
                iConexion!.Paises!.Remove(entidad4!);
                iConexion!.SaveChanges();
                //Sera que lo saco afuera?
            }
            for (int i = 0; i < 6; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                entidad = ListaNucleo.Lista_Productos[i]; //
                iConexion!.Productos!.Remove(entidad!);
                iConexion!.SaveChanges();
                //Sera que lo saco afuera?
            }
            for (int i = 0; i < 3; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                entidad7 = ListaNucleo.Lista_TiposDeProductos[i]; //
                iConexion!.TiposDeProductos!.Remove(entidad7!);
                iConexion!.SaveChanges();
                //Sera que lo saco afuera?
            }
            return true;
        }
    }
}