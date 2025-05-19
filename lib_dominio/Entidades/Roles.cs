using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Roles
    {
        [Key] public int Id { get; set; }
        public int Id_Permiso { get; set; }
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }


        //Recibe 1
        [ForeignKey("Id_Permiso")] public Permisos? _Permisos { get; set; }
        
        //Envia 1

        //public List<Usuarios>? Usuarios { get; set; }
    }
}
