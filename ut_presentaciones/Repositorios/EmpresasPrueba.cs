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

        public EmpresasPruebas()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.Empresas!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Empresas();
            this.iConexion!.Empresas!.Add(this.entidad); //
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Nombre = "Ekni";

            var entry = this.iConexion!.Entry<Empresas>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Empresas!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}