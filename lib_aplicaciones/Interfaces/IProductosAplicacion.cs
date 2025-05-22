﻿using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface IProductosAplicacion
    {
        void Configurar(string StringConexion);
        List<Productos> PorNombre(Productos? entidad);
        List<Productos> Listar();
        Productos? Guardar(Productos? entidad);
        Productos? Modificar(Productos? entidad);
        Productos? Borrar(Productos? entidad);
        //---------------------------------------//
        Paises? Borrar(Paises? entidad);//
        Empresas? Borrar(Empresas? entidad);//
        TiposDeProductos? Borrar(TiposDeProductos? entidad);//

    }
}
