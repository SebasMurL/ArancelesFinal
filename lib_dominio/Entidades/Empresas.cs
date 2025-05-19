using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Empresas
    {
        // 3 Atributos
        [Key] public int? Id { get; set; }
        public int? Id_Pais { get; set; }
        public string? Nombre { get; set; }

        //Recibe 1
        [ForeignKey("Id_Pais")] public Paises? _Pais { get; set; }
    }
}
