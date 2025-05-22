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
    public class OrdenesPrueba
    {
        private readonly IOrdenesAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<Ordenes>? lista;
        private Paises? entidad4;
        private Empresas? entidad1;
        private Ordenes? entidad;
        private Productos? entidad5;
        private TiposDeProductos? entidad7;
        public OrdenesPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iAplicacion = new OrdenesAplicacion(iConexion);
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
            while (ListaNucleo.Lista_Ordenes.Count > i) // RECUERDA HACERLO WHILE
            {
                if (ListaNucleo.Lista_Ordenes[i] != null)
                {
                    this.entidad = ListaNucleo.Lista_Ordenes[i];
                    this.iAplicacion!.Guardar(this.entidad); //¿?
                }
                i = i + 1;
                //Sera que lo saco afuera?
            }
            return true;
        }
        public bool Modificar()//Modificado
        {
            this.entidad = ListaNucleo.Lista_Ordenes[0]; //
            this.entidad!.Cod= "Modificacion";
            this.iAplicacion!.Modificar(this.entidad);
            return true;
        }

        public bool Borrar()
        {
            int i = 0;
            while (ListaNucleo.Lista_Ordenes.Count > i) //
            {
                if (ListaNucleo.Lista_Ordenes[i] != null)
                {
                    this.entidad = ListaNucleo.Lista_Ordenes[i];
                    this.iAplicacion!.Borrar(this.entidad); //¿?
                }
                i = i + 1;
                //Sera que lo saco afuera?
            }
            i = 0;
            while (ListaNucleo.Lista_Productos.Count > i) //
            {
                if (ListaNucleo.Lista_Productos[i] != null)
                {
                    this.entidad5 = ListaNucleo.Lista_Productos[i];
                    this.iAplicacion!.Borrar(this.entidad5); //¿?
                }
                i = i + 1;
                //Sera que lo saco afuera?
            }
            i = 0;
            while (ListaNucleo.Lista_TiposDeProductos.Count > i) //
            {
                if (ListaNucleo.Lista_TiposDeProductos[i] != null)
                {
                    this.entidad7 = ListaNucleo.Lista_TiposDeProductos[i];
                    this.iAplicacion!.Borrar(this.entidad7); //¿?
                }
                i = i + 1;
                //Sera que lo saco afuera?
            }
            i = 0;
            while (ListaNucleo.Lista_Empresas.Count > i) //
            {
                if (ListaNucleo.Lista_Empresas[i] != null)
                {
                    this.entidad1 = ListaNucleo.Lista_Empresas[i];
                    this.iAplicacion!.Borrar(this.entidad1); //¿?
                }
                i = i + 1;
                //Sera que lo saco afuera?
            }
            i = 0;
            while (ListaNucleo.Lista_Paises.Count > i) //
            {
                if (ListaNucleo.Lista_Paises[i] != null)
                {
                    this.entidad4 = ListaNucleo.Lista_Paises[i];
                    this.iAplicacion!.Borrar(this.entidad4); //¿?
                }
                i = i + 1;
                //Sera que lo saco afuera?
            }
            return true;
        }
    }
}
