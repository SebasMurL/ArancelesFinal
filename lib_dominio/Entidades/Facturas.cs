using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Facturas
    {
        //4 Atributos
        public int? Id { get; set; }
        public int? Id_Arancel { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? PagoTotalCop { get; set; }
        //Recibe 1
        [ForeignKey("Id_Arancel")] public Aranceles? _Arancel { get; set; }
    }
}
