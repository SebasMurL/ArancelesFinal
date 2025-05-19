﻿using lib_dominio.Entidades;
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
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.Paises!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()           //Recuerda borrar los "//" de Paises,Empresas y Ordenes
        {
            this.entidad = EntidadesNucleo.Paises();
            this.iConexion!.Paises!.Add(this.entidad); //¿?
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Moneda = "renminbi";

            var entry = this.iConexion!.Entry<Paises>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Paises!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}