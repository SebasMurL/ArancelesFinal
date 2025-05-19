using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Permisos
    {
        [Key] public int Id { get; set; }
        public string? Codigo { get; set; }
        public List<string>? EntidadesModificables { get; set; }

        //Envia 1
        //public List<Roles>? Roles { get; set; }
    }
}
