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
    public class ArancelesPrueba
    {
        private readonly IArancelesAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<Aranceles>? lista;
        private Aranceles? entidad;
        private Empresas? entidad1;
        private Ordenes? entidad3;
        private Paises? entidad4;
        private Productos? entidad5;
        private TiposDeAranceles? entidad6;
        private TiposDeProductos? entidad7;
        public ArancelesPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iAplicacion = new ArancelesAplicacion(iConexion);
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
            while (ListaNucleo.Lista_Aranceles.Count > i) // RECUERDA HACERLO WHILE
            {
                if (ListaNucleo.Lista_Aranceles[i] != null)
                {
                    this.entidad = ListaNucleo.Lista_Aranceles[i];
                    this.iAplicacion!.Guardar(this.entidad); //¿?
                }
                i = i + 1;
                //Sera que lo saco afuera?
            }
            return true;
        }
        public bool Modificar()//Modificado
        {
            this.entidad = ListaNucleo.Lista_Aranceles[0]; //
            this.entidad!.PorcentajeDelArancel = 15;
            this.iAplicacion!.Modificar(this.entidad);
            return true;
        }

        public bool Borrar()
        {
            int i = 0;
            while (ListaNucleo.Lista_Aranceles.Count > i) //
            {
                this.entidad = ListaNucleo.Lista_Aranceles[i]; //
                this.iAplicacion!.Borrar(this.entidad!);
                //Sera que lo saco afuera?
                i = i + 1;
            }
            i = 0;
            while (ListaNucleo.Lista_Ordenes.Count > i) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                entidad3 = ListaNucleo.Lista_Ordenes[i]; //
                this.iAplicacion!.Borrar(entidad3!);
                //Sera que lo saco afuera?
                i = i + 1;
            }
            i = 0;
            while (ListaNucleo.Lista_Productos.Count > i) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                entidad5 = ListaNucleo.Lista_Productos[i]; //
                this.iAplicacion!.Borrar(entidad5!);
                //Sera que lo saco afuera?
                i = i + 1;
            }
            i = 0;
            while (ListaNucleo.Lista_TiposDeAranceles.Count > i) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                entidad6 = ListaNucleo.Lista_TiposDeAranceles[i]; //
                this.iAplicacion!.Borrar(entidad6!);
                //Sera que lo saco afuera?
                i = i + 1;
            }
            i = 0;
            while (ListaNucleo.Lista_TiposDeProductos.Count > i) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                entidad7 = ListaNucleo.Lista_TiposDeProductos[i]; //
                this.iAplicacion!.Borrar(entidad7!);
                //Sera que lo saco afuera?
                i = i + 1;
            }
            i = 0;
            while (ListaNucleo.Lista_Empresas.Count > i) //
            {
                this.entidad1 = ListaNucleo.Lista_Empresas[i]; //
                this.iAplicacion!.Borrar(entidad1!);
                //Sera que lo saco afuera?
                i = i + 1;
            }
            i = 0;
            while (ListaNucleo.Lista_Paises.Count > i) // Por falta de tiempo, me toco colocarlo asi mientras :/
            {
                entidad4 = ListaNucleo.Lista_Paises[i]; //
                this.iAplicacion!.Borrar(entidad4!);
                //Sera que lo saco afuera?
                i = i + 1;
            }
            return true;
        }
    }
}
