using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class TiposDeAranceles
    {
        //3 Atributos
        [Key] public int? Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaVigencia { get; set; }
        //Envia 1
       // public List<Aranceles>? Aranceles { get; set; }
    }
}
