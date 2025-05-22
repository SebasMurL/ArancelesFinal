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
    public class TiposDeProductosPrueba
    {
        private readonly ITiposDeProductosAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<TiposDeProductos>? lista;
        private TiposDeProductos? entidad;

        public TiposDeProductosPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iAplicacion = new TiposDeProductosAplicacion(iConexion);
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
            while (ListaNucleo.Lista_TiposDeProductos.Count > i) // RECUERDA HACERLO WHILE
            {
                if (ListaNucleo.Lista_TiposDeProductos[i] != null)
                {
                    this.entidad = ListaNucleo.Lista_TiposDeProductos[i];
                    this.iAplicacion!.Guardar(this.entidad); //¿?
                }
                i = i + 1;
                //Sera que lo saco afuera?
            }
            return true;
        }
        public bool Modificar()//Modificado
        {
            this.entidad = ListaNucleo.Lista_TiposDeProductos[0]; //
            this.entidad!.Nombre="Prueba";
            this.iAplicacion!.Modificar(this.entidad);
            return true;
        }

        public bool Borrar()
        {
            int i = 0;
            while (ListaNucleo.Lista_TiposDeProductos.Count > i) //
            {
                if (ListaNucleo.Lista_TiposDeProductos[i] != null)
                {
                    this.entidad = ListaNucleo.Lista_TiposDeProductos[i];
                    this.iAplicacion!.Borrar(this.entidad); //¿?
                }
                i = i + 1;
                //Sera que lo saco afuera?
            }
            return true;
        }
    }
}
