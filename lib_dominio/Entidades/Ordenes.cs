﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Ordenes
    {
        //7 Atributos
        public int? Id { get; set; }
        public int? Id_PaisOrigen { get; set; }
        public int? Id_PaisDestino { get; set; }
        public int? Id_Producto { get; set; }
        public string? Cod { get; set; }
        public int? CantidadUnidades { get; set; }
        public DateTime? Fecha { get; set; }
        //Recibe 3

       [ForeignKey("Id_PaisDestino")] public Paises? _PaisDestino { get; set; }
       [ForeignKey("Id_PaisOrigen")] public Paises? _PaisOrigen { get; set; }
       [ForeignKey("Id_Producto")]  public Productos? _Producto { get; set; }

        //Envia 1

        //public Aranceles? Aranceles { get; set; }
    }
}
