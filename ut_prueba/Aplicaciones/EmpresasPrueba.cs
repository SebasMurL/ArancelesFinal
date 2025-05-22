using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ut_presentacion.Nucleo;
using ut_presentaciones.Nucleo;

namespace ut_presentaciones.Aplicaciones
{
    [TestClass]
    public class EmpresasPrueba
    {
        private readonly IEmpresasAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<Empresas>? lista;
        private Empresas? entidad;
        private Paises? entidad4;
        public EmpresasPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iAplicacion = new EmpresasAplicacion(iConexion);
        }
        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Cargar()); //
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
            this.lista = this.iAplicacion!.Listar();
            return lista.Count > 0;
        }
        public bool Guardar() //Modificada
        {
            int i = 0;
            while (ListaNucleo.Lista_Empresas[i]!=null && ListaNucleo.Lista_Empresas[i+1]==null) // RECUERDA HACERLO WHILE
            {
                this.entidad = ListaNucleo.Lista_Empresas[i];
                this.iAplicacion!.Guardar(this.entidad); //¿?
                i = i + 1;
                //Sera que lo saco afuera?
            }
            return true;
        }
        public bool Modificar()//Modificado
        {
            this.entidad = ListaNucleo.Lista_Empresas[0]; //
            this.entidad!.Nombre= "Modificacion";
            this.iAplicacion!.Modificar(this.entidad);
            return true;
        }

        public bool Borrar()
        {
            int i = 0;
            while (ListaNucleo.Lista_Empresas[i] != null && ListaNucleo.Lista_Empresas[i + 1] == null) //
            {
                this.entidad = ListaNucleo.Lista_Empresas[i]; //
                this.iAplicacion!.Borrar(this.entidad!);
                i = i + 1;
                //Sera que lo saco afuera?
            }
            i = 0;
            while (ListaNucleo.Lista_Paises[i] != null && ListaNucleo.Lista_Paises[i + 1] == null)
            {
                entidad4 = ListaNucleo.Lista_Paises[i]; //
                this.iAplicacion!.Borrar(entidad4!);
                i = i + 1;
                //Sera que lo saco afuera?
            }
            return true;
        }
    }
}
