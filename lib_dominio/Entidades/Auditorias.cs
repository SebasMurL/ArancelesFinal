using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Auditorias
    {
        [Key] public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public string? Modificacion { get; set; }
        public string? InformacionDelElemento { get; set; }
        public DateTime Fecha { get; set; }

        //Recibe 1
        [ForeignKey("Id_Usuario")] public Usuarios? _Usuario { get; set; }
    }
}
