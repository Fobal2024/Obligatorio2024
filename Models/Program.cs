using Obligatorio2024;
using System;                                      //contiene una gran cantidad de funcionalidades 
using System.Diagnostics.CodeAnalysis;       // Suprime advertencias del compilador o para especificar opciones de análisis de código

static void Main(string[] args) //static=Main pertenece a la Clase, no a una instancia y (string[] args)= parámetro recibe argumentos
{
    try
    {
        Console.WriteLine("Hola Mundo");

        Responsable responsable = new Responsable();      // Creo una instancia de Responsable


    Socio nuevoSocio = new Socio  // Agrego nuevo socio. Nueva instancia clase Socio, usa el constructor predeterminado(sin argumentos) de la clase.
    {
        Id = "",
        Nombre = "",                // Propiedades
        Telefono = "",
        Tipo = "",
        Email = "",
        LocalAsociado = new Local       // Este objeto se instancia utilizando el constructor de la clase Local.
        {                              
            Nombre = "",      //Asigno valores a los diferentes atributos del objeto.
            Ciudad = "",
            Direccion = "",
            Telefono = "",
            Responsable = new Persona   //Nuevo objeto de tipo Persona y asignándolo al atributo Responsable del objeto LocalAsociado.
            {
                Nombre = "",
                Telefono = ""
            }
        }
    };
    responsable.AgregarSocio(nuevoSocio); //método AgregarSocio en un objeto llamado responsable, pasándole como argumento el objeto nuevoSocio


    Console.WriteLine("Lista de todos los socios:");  // Obtener todos los socios
    foreach (Socio socio in responsable.ObtenerTodosLosSocios()) //Itera una colección de socios que se obtienen del método ObtenerTodosLosSocios() del objeto responsable
    {
        Console.WriteLine($"Nombre: {socio.Nombre}, Tipo: {socio.Tipo}, Email: {socio.Email}");
    }

   
    string tipoAFiltrar = "premium";   // Filtrar socios por tipo, ingreso Premium o Estandar
    Console.WriteLine($"Lista de socios de tipo '{tipoAFiltrar}':"); 
    foreach (Socio socio in responsable.FiltrarSociosPorTipo(tipoAFiltrar))
    {
        Console.WriteLine($"Nombre: {socio.Nombre}, Tipo: {socio.Tipo}, Email: {socio.Email}");
    }

    
    Console.WriteLine("Lista de tipos de máquina:");  // Obtener tipos de máquina
    foreach (TipoDeMaquina tipoDeMaquina in responsable.ObtenerTiposDeMaquina())
    {
        Console.WriteLine($"Nombre: {tipoDeMaquina.Nombre}");
    }

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Se produjo una excepción: {ex.Message}");
    }
}