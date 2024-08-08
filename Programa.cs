using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace HarryPotterApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            // Solicitar nombre de usuario
            Console.Write("Por favor, ingrese su nombre de usuario: ");
            string nombreUsuario = Console.ReadLine();

            // Crear una instancia de HabilidadesDePersonajes
            HabilidadesDePersonajes habilidadesDePersonajes = new HabilidadesDePersonajes();
            List<Personaje> personajes = new List<Personaje>();

            // Definir los nombres de los personajes
            string[] personajesNombres = { "Harry Potter", "Hermione Granger", "Ron Weasley", "Severus Snape", "Albus Dumbledore", "Draco Malfoy", "Luna Lovegood", "Sirius Black" };

            // Crear y guardar las habilidades de los personajes
            foreach (string nombre in personajesNombres)
            {
                Personaje personaje = habilidadesDePersonajes.CrearPersonaje(nombre);
                personajes.Add(personaje);
            }

            // Guardar personajes en un archivo JSON
            string nombreArchivoPersonajes = "personajes.json";
            PersonajesJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);

            // Elegir el primer personaje
            Console.WriteLine("Elija un personaje:");
            for (int i = 0; i < personajesNombres.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {personajesNombres[i]}");
            }

            int eleccion1 = Convert.ToInt32(Console.ReadLine());
            Personaje personaje1 = personajes[eleccion1 - 1];
            personajes.RemoveAt(eleccion1 - 1);
            Console.WriteLine($"Has elegido a: {personaje1.Nombre}");
            MostrarHabilidades(personaje1);

            // Obtener y mostrar los datos adicionales del personaje elegido desde la API
            await MostrarDatosAdicionales(personaje1.Nombre);

            // Realizar enfrentamientos sucesivos
            while (personajes.Count > 0)
            {
                Personaje contrincante = personajes[0];
                personajes.RemoveAt(0);
                Console.WriteLine($"\n{personaje1.Nombre} se enfrentará a {contrincante.Nombre}");
                MostrarHabilidades(contrincante);
                Thread.Sleep(1000);

                // Realizar el combate
                string resultado = habilidadesDePersonajes.Combatir(personaje1, contrincante);
                Console.WriteLine(resultado);
                Thread.Sleep(1000);


                // Determinar el ganador
                personaje1 = personaje1.Salud > 0 ? personaje1 : contrincante;
                Console.WriteLine("\nHabilidades del personaje ganador después del combate:");
                Thread.Sleep(1000);
                MostrarHabilidades(personaje1);
            }

            // Declarar el ganador final
            Console.WriteLine("\n¡El ganador final y merecedor del Calix de Fuego es:");
            Thread.Sleep(1000);
            MostrarHabilidades(personaje1);
            Thread.Sleep(1000);
            Console.WriteLine($"{personaje1.Nombre}, ¡felicitaciones!");

            // Guardar el ganador en el historial
            string nombreArchivoHistorial = "historial_ganadores.json";
            Thread.Sleep(1000);
            string informacion = $"{nombreUsuario} eligió a {personaje1.Nombre} y ganó la competencia.";
            RegistroJson.GuardarGanador(personaje1, informacion, nombreArchivoHistorial);

            // Leer y mostrar el historial de ganadores
            if (RegistroJson.Existe(nombreArchivoHistorial))
            {
                List<Registro> ganadores = RegistroJson.LeerGanadores(nombreArchivoHistorial);
                Console.WriteLine("\nHistorial de Ganadores:");
                foreach (var entry in ganadores)
                {
                    Console.WriteLine($"{entry.Fecha}: {entry.Nombre} - {entry.Informacion}");
                }
            }
        }

        static void MostrarHabilidades(Personaje personaje)
        {
            Console.WriteLine("\nPersonaje: " + personaje.Nombre);
            Console.WriteLine("Varita: " + personaje.Varita);
            Console.WriteLine("Magia: " + personaje.Magia);
            Console.WriteLine("Nivel: " + personaje.Nivel);
            Console.WriteLine("Efectividad: " + personaje.Efectividad);
            Console.WriteLine("Hechizo de defensa: " + personaje.HechizoDefensa);
            Console.WriteLine("Reflejos: " + personaje.Reflejos);
            Console.WriteLine("Salud: " + personaje.Salud);
        }

        static async Task MostrarDatosAdicionales(string nombre)
        {
            var api = new HarryPotterAPI();
            var datosAdicionales = await api.ObtenerDatosPersonaje(nombre);
            if (datosAdicionales != null)
            {
                Console.WriteLine("\nDatos adicionales del personaje elegido:");
                Console.WriteLine("Casa: " + datosAdicionales.Casa);
                Console.WriteLine("Fecha de nacimiento: " + datosAdicionales.FechaDeNacimiento);
                Console.WriteLine("Ascendencia: " + datosAdicionales.Ascendencia);
                Console.WriteLine("Patronus: " + datosAdicionales.Patronus);
            }
            else
            {
                Console.WriteLine("No se encontraron datos adicionales para el personaje seleccionado.");
            }
        }
    }
}
