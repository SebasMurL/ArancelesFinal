using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Aranceles
    {
        //4 Atributos
        public int? Id { get; set; }
        public int? Id_Orden { get; set; }
        public int? Id_TipoDeArancel { get; set; }
        public decimal? PorcentajeDelArancel { get; set; }
        // Recibe 2
        [ForeignKey("Id_Orden")] public Ordenes? _Orden { get; set; }
        [ForeignKey("Id_TipoDeArancel")] public TiposDeAranceles? _TipoArancel { get; set; }
        //Envia 1
        // public Facturas? Factura { get; set; }
    }
}
