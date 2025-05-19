using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
using ut_presentaciones.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class EmpresasPruebas
    {
        private readonly IConexion? iConexion;
        private List<Empresas>? lista;
        private Empresas? entidad;
        private Paises? entidad4;

        public EmpresasPruebas()
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
            this.lista = this.iConexion!.Empresas!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            for (int i = 0; i < 6; i++) //
            {
                this.entidad = ListaNucleo.Lista_Empresas[i];
                this.iConexion!.Empresas!.Add(this.entidad); //¿?
                this.iConexion!.SaveChanges();
                //Sera que lo saco afuera?
            }
            return true;
        }

        public bool Modificar()
        {
            this.entidad = ListaNucleo.Lista_Empresas[0]; //
            this.entidad!.Nombre = "Ekni";

            var entry = this.iConexion!.Entry<Empresas>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            for (int i = 0; i < 6; i++) //
            {
                this.entidad = ListaNucleo.Lista_Empresas[i]; //
                this.iConexion!.Empresas!.Remove(this.entidad!);
                this.iConexion!.SaveChanges();
                //Sera que lo saco afuera?
            }
            for (int i = 0; i < 4; i++) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                if(i==2)
                { i = 3; } // ...........
                entidad4 = ListaNucleo.Lista_Paises[i]; //
                iConexion!.Paises!.Remove(entidad4!);
                iConexion!.SaveChanges();
                //Sera que lo saco afuera?
            }
            return true;
        }
    }
}