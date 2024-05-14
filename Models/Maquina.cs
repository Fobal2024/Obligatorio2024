using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio2024
{
    public class Maquina
    {
        public Local LocalAsociado { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal PrecioCompra { get; set; }
        public int VidaUtil { get; set; } 
        public TipoDeMaquina Tipo { get; set; }
        public bool Disponible { get; set; }
    }
}

