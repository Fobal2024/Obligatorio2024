using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Obligatorio2024
{
    
    public class Responsable : Persona
    {
        
        private List<Socio> socios = new List<Socio>(); //socios es una lista vacía de objetos del tipo Socio, private solo es accesible dentro de la clase donde se declara.
        private List<Local> locales = new List<Local>();
        private List<Maquina> maquinas = new List<Maquina>();
        private List<TipoDeMaquina> tiposDeMaquina = new List<TipoDeMaquina>();

        
        public void AgregarSocio(Socio socio) // Métodos CRUD para Socios
        {
            socios.Add(socio);
        }

        public void ActualizarSocio(Socio socioActualizado)  
        {
            Socio socio = socios.Find(s => s.Id == socioActualizado.Id);  // Busco el socio a actualizar en la lista de socios

            if (socio != null)
            {
                socio.Nombre = socioActualizado.Nombre;   // Actualiza los datos del socio existente con los del socio actualizado
                socio.Telefono = socioActualizado.Telefono;
                socio.Tipo = socioActualizado.Tipo;
                socio.Email = socioActualizado.Email;
                socio.LocalAsociado = socioActualizado.LocalAsociado;
            }
            else
            {
                throw new InvalidOperationException("El socio a actualizar no existe.");  // Si el socio no se encuentra en la lista, lanzo un mensaje de excepción
            }
        }

        public void EliminarSocio(Socio socio)
        {
            socios.Remove(socio);
        }

        public List<Socio> ObtenerTodosLosSocios()
        {
            return socios;
        }

        // Métodos para consultas
        public List<Socio> FiltrarSociosPorTipo(string tipo) // devuelve una lista de objetos de tipo Socio, cuyo parámetro coincida
        {
            return socios.FindAll(s => s.Tipo == tipo); //verifica que el atributo Tipo de cada elemento coincida con el criterio de filtro
        }

        public List<TipoDeMaquina> ObtenerTiposDeMaquina()
        {
            return tiposDeMaquina;  // Devuelve una lista de los diferentes tipos de máquinas que hay en el gimnasio
        }

        public Dictionary<TipoDeMaquina, int> ObtenerCantidadMaquinasPorTipo() //La clave es de tipo TipoDeMaquina y el valor es un entero (int), da cuantas máquinas hay de cada tipo
        {
            Dictionary<TipoDeMaquina, int> cantidadMaquinasPorTipo = new Dictionary<TipoDeMaquina, int>();

            foreach (Maquina maquina in maquinas)
            {
                if (!cantidadMaquinasPorTipo.ContainsKey(maquina.Tipo)) // a los tipos que no coincidan con el criterio, les va a asignar el valor 0
                {
                    cantidadMaquinasPorTipo[maquina.Tipo] = 0;
                }

                cantidadMaquinasPorTipo[maquina.Tipo]++; // contador de las que existen
            }

            return cantidadMaquinasPorTipo; // devuelve un diccionario con los datos buscados
        }

        public int CalcularAniosVidaUtilRestantes(Maquina maquina)
        {
            int aniosTranscurridos = DateTime.Now.Year - maquina.FechaCompra.Year;
            return maquina.VidaUtil - aniosTranscurridos;
        }

        public List<Maquina> OrdenarMaquinasPorFechaCompra(bool ascendente)
        {
            if (ascendente)
            {
                maquinas.Sort((m1, m2) => m1.FechaCompra.CompareTo(m2.FechaCompra));
            }
            else
            {
                maquinas.Sort((m1, m2) => m2.FechaCompra.CompareTo(m1.FechaCompra));
            }

            return maquinas;
        }
    }

}
