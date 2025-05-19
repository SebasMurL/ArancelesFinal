using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Usuarios
    {
        [Key] public int Id { get; set; }
        public int Id_Rol { get; set; }
        public string? Codigo { get; set; }


        //Recibe 1
        [ForeignKey("Id_Rol")] public Roles? _Roles { get; set; }

        //Envia 1

        //public List<Auditorias>? Auditorias { get; set; }
    }
}
