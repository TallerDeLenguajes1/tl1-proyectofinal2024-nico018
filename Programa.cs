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

            // Mostrar menú de personajes
            Console.WriteLine("Elija un personaje:");
            Console.WriteLine("1. Harry Potter");
            Console.WriteLine("2. Hermione Granger");
            Console.WriteLine("3. Ron Weasley");
            Console.WriteLine("4. Severus Snape");

            // Leer la elección del usuario
            int eleccion = Convert.ToInt32(Console.ReadLine());
            string personajeElegido = "";
            string[] personajesNombres = { "Harry Potter", "Hermione Granger", "Ron Weasley", "Severus Snape" };

            // Asignar el personaje elegido según la opción seleccionada
            if (eleccion >= 1 && eleccion <= 4)
            {
                personajeElegido = personajesNombres[eleccion - 1];
            }
            else
            {
                Console.WriteLine("Opción no válida");
                return;
            }

            // Crear una instancia de HabilidadesDePersonajes
            HabilidadesDePersonajes habilidadesDePersonajes = new HabilidadesDePersonajes();
            List<Personaje> personajes = new List<Personaje>();

            // Crear y guardar las habilidades de los personajes
            foreach (string nombre in personajesNombres)
            {
                Personaje personaje = habilidadesDePersonajes.CrearPersonaje(nombre);
                personajes.Add(personaje);
            }

            // Guardar personajes en un archivo JSON
            string nombreArchivo = "personajes.json";
            PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);

            // Mostrar las habilidades del personaje elegido
            Personaje personajeElegidoObj = personajes.Find(p => p.Nombre == personajeElegido);
            Console.WriteLine("\nUsuario: " + nombreUsuario);
            Console.WriteLine("Has elegido a: " + personajeElegidoObj.Nombre);
            MostrarHabilidades(personajeElegidoObj);

            // Obtener y mostrar los datos adicionales del personaje elegido desde la API
            await MostrarDatosAdicionales(personajeElegido);

            // Leer personajes del archivo JSON y mostrar sus habilidades
            if (PersonajesJson.Existe(nombreArchivo))
            {
                List<Personaje> personajesLeidos = PersonajesJson.LeerPersonajes(nombreArchivo);
                Console.WriteLine("\nHabilidades de los personajes no elegidos:");
                foreach (Personaje personaje in personajesLeidos)
                {
                    if (personaje.Nombre != personajeElegido)
                    {
                        MostrarHabilidades(personaje);
                    }
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
            using (HttpClient client = new HttpClient())
            {
                string url = "https://hp-api.onrender.com/api/characters";
                string json = await client.GetStringAsync(url);
                JArray personajes = JArray.Parse(json);

                var personaje = personajes.FirstOrDefault(p => (string)p["name"] == nombre);
                if (personaje != null)
                {
                    Console.WriteLine("\nDatos adicionales del personaje elegido:");
                    Console.WriteLine("Casa: " + personaje["house"]);
                    Console.WriteLine("Fecha de nacimiento: " + personaje["dateOfBirth"]);
                    Console.WriteLine("Ascendencia: " + personaje["ancestry"]);
                    Console.WriteLine("Patronus: " + personaje["patronus"]);
                }
                else
                {
                    Console.WriteLine("No se encontraron datos adicionales para el personaje seleccionado.");
                }
            }
        }
    }
}
