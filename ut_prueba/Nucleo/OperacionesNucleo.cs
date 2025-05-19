using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;

namespace ut_presentaciones.Nucleo
{
    public class OperacionesNucleo
    {
        public static decimal CalcularPorcentajeDeArancel(int Id_TipoArancel, Ordenes Orden)
        {
            decimal result = 0;
            decimal TipoArancel = 0;
            switch (Id_TipoArancel)
            {
                case (1): { TipoArancel = 15;} break;
                case (2): { TipoArancel = 20; } break;
                case (3): { TipoArancel = 25; } break;
                default: {TipoArancel= 0;} break;
            }
            decimal OriDes=0;
            if (Orden.Id_PaisDestino.Equals(Orden.Id_PaisOrigen))
            {
                OriDes = 0;
            }
            else if (Orden.Id_PaisDestino == 1)
            {
                if (Orden.Id_PaisOrigen == 2){ OriDes = 10; }
                else if (Orden.Id_PaisOrigen == 3) { OriDes = 16; }
                else if (Orden.Id_PaisOrigen == 4) { OriDes = 15; }
            }
            else if (Orden.Id_PaisDestino == 2)
            {
                if (Orden.Id_PaisOrigen == 1) { OriDes = 19; }
                else if (Orden.Id_PaisOrigen == 3) { OriDes = 20; }
                else if (Orden.Id_PaisOrigen == 4) { OriDes = 25; }
            }
            else if (Orden.Id_PaisDestino == 3)
            {
                if (Orden.Id_PaisOrigen == 1) { OriDes = 20; }
                else if (Orden.Id_PaisOrigen == 2) { OriDes = 9; }
                else if (Orden.Id_PaisOrigen == 4) { OriDes = 10; }
            }
            else if (Orden.Id_PaisDestino == 4)
            {
                if (Orden.Id_PaisOrigen == 1) { OriDes = 15; }
                else if (Orden.Id_PaisOrigen == 2) { OriDes = 23; }
                else if (Orden.Id_PaisOrigen == 3) { OriDes = 30; }
            }
            result = OriDes + TipoArancel;
            return result;
        }
        public static decimal? CalcularPagoTotal(Aranceles arancele)
        {
            decimal? total = (arancele.PorcentajeDelArancel)*(arancele._Orden.CantidadUnidades);
            return total;
        }
        
    }
}
