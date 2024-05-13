using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Obligatorio2024
{
    public class Socio : Persona
    {
        public string Id { get; set; }
        public string Tipo { get; set; } 
        public string Email { get; set; }
        public Local LocalAsociado { get; set; }
    }
}
