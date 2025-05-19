using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class TiposDeProductos
    {
        //3 Atributos
        [Key] public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? EntidadRegulatoria { get; set; }
        //Envio 1
        // public List<Productos>? Productos { get; set; }
    }
}
