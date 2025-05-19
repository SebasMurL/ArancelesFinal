using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Paises
    {
        [Key] public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Moneda { get; set; }

        //Envia 3

       //public List<Empresas>? Empresas { get; set; }
       // public List<Ordenes>? OrdenesDestinos { get; set; }
      // public List<Ordenes>? OrdenesOrigenes { get; set; }
    }
}
