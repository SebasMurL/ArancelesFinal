using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
using ut_presentaciones.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class FacturasPrueba
    {
        private readonly IConexion? iConexion;
        private List<Facturas>? lista;
        private Facturas? entidad;
        private Aranceles? entidad8;
        private Empresas? entidad1;
        private Ordenes? entidad3;
        private Paises? entidad4;
        private Productos? entidad5;
        private TiposDeAranceles? entidad6;
        private TiposDeProductos? entidad7;

        public FacturasPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar() // 
        {
            Assert.AreEqual(true, Cargar());
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar()); //El orden de los borrar importan absudamente
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
            this.lista = this.iConexion!.Facturas!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            for (int i = 0; i < 6; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                this.entidad = ListaNucleo.Lista_Facturas[i];
                this.iConexion!.Facturas!.Add(this.entidad); //¿?

                //Sera que lo saco afuera?
            }
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad = ListaNucleo.Lista_Facturas[0]; //
            this.entidad!.PagoTotalCop = 10000000.00m;

            var entry = this.iConexion!.Entry<Facturas>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            for (int i = 0; i < 6; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                entidad = ListaNucleo.Lista_Facturas[i]; //
                iConexion!.Facturas!.Remove(entidad!);
                iConexion!.SaveChanges();
                //Sera que lo saco afuera?
            }
            for (int i = 0; i < 6; i++) //
            {
                this.entidad8 = ListaNucleo.Lista_Aranceles[i]; //
                this.iConexion!.Aranceles!.Remove(entidad8!);
                this.iConexion!.SaveChanges();
                //Sera que lo saco afuera?
            }
          
            for (int i = 0; i < 6; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                entidad3 = ListaNucleo.Lista_Ordenes[i]; //
                iConexion!.Ordenes!.Remove(entidad3!);
                iConexion!.SaveChanges();
                //Sera que lo saco afuera?
            }
            
            for (int i = 0; i < 6; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                entidad5 = ListaNucleo.Lista_Productos[i]; //
                iConexion!.Productos!.Remove(entidad5!);
                iConexion!.SaveChanges();
                //Sera que lo saco afuera?
            }
            for (int i = 0; i < 3; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                entidad6 = ListaNucleo.Lista_TiposDeAranceles[i]; //
                iConexion!.TiposDeAranceles!.Remove(entidad6!);
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
            for (int i = 0; i < 6; i++) //
            {
                this.entidad1 = ListaNucleo.Lista_Empresas[i]; //
                this.iConexion!.Empresas!.Remove(entidad1!);
                this.iConexion!.SaveChanges();
                //Sera que lo saco afuera?
            }
            for (int i = 0; i < 4; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                entidad4 = ListaNucleo.Lista_Paises[i]; //
                iConexion!.Paises!.Remove(entidad4!);
                iConexion!.SaveChanges();
                //Sera que lo saco afuera?
            }
            return true;
        }
    }
}