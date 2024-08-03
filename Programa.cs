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
            string[] personajesNombres = { "Harry Potter", "Hermione Granger", "Ron Weasley", "Severus Snape" };

            // Crear y guardar las habilidades de los personajes
            foreach (string nombre in personajesNombres)
            {
                Personaje personaje = habilidadesDePersonajes.CrearPersonaje(nombre);
                personajes.Add(personaje);
            }

            // Guardar personajes en un archivo JSON
            string nombreArchivo = "personajes.json";
            PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);

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

            // Realizar enfrentamientos sucesivos
            while (personajes.Count > 0)
            {
                Personaje contrincante = personajes[0];
                personajes.RemoveAt(0);
                Console.WriteLine($"\n{personaje1.Nombre} se enfrentará a {contrincante.Nombre}");
                MostrarHabilidades(contrincante);

                // Realizar el combate
                string resultado = await habilidadesDePersonajes.Combatir(personaje1, contrincante);
                Console.WriteLine(resultado);

                // Determinar el ganador
                personaje1 = personaje1.Salud > 0 ? personaje1 : contrincante;
                Console.WriteLine("\nHabilidades del personaje ganador después del combate:");
                MostrarHabilidades(personaje1);
            }

            // Declarar el ganador final
            Console.WriteLine("\n¡El ganador final y merecedor del Calis de Fuego es:");
            MostrarHabilidades(personaje1);
            Console.WriteLine($"{personaje1.Nombre}, ¡felicitaciones!");
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
    }
}
